###################################
#                                 #
#   UNITS                         #
#                                 #
###################################

# The unit of time in this library is 1ns 
# The unit of capacitance in this library is 1pF 
#


###################################
#                                 #
#   CLEAN-UP                      #
#                                 #
###################################

# Remove any existing constraints and attributes
#
reset_design


###################################
#                                 #
#   CLOCK DEFINITION              #
#                                 #
###################################

# A 33Mhz clock is a 30.0ns period:
#
create_clock -period 30.0 -name my_clk -waveform {0 15} [get_ports clk]


# External clock source latency is 700ps or 0.7ns
#
set_clock_latency -source  -max 0.7 [get_clocks my_clk] 


# The maximum internal clock network insertion delay or latency is 300ps or 0.3 ns:
#
set_clock_latency -max 0.3 [get_clocks my_clk]


# The +/-30ps internal clock delay variation to register clock pins results in a 60ps worst case skew or uncertainty, if you launch
# late (+30ps) and capture early (-30ps)r; Add 40ps due to jitter and 50ps for setup margin;
# This equals 150ps or 0.15 ns of total uncertainty.
#
set_clock_uncertainty -setup 0.15 [get_clocks my_clk]


# The maximum clock transition is 120ps or 0.12ns
#
set_clock_transition 0.12 [get_clocks my_clk]

## set the clock as a don't touch - don't put buffers
set_dont_touch_network [get_clocks my_clk]

###################################
#                                 #
#   INPUT TIMING                  #
#                                 #
###################################

# The maximum "input delay" (external) on ports  data_in  is: 
# clock period - clock uncertainty - delay of S - register setup time = 
#     3.0      -      0.15         -     2.2   -      0.2            = 0.45ns
# 
set_input_delay -max  27.45 -clock my_clk [get_ports -filter "@port_direction == in"]  



###################################
#                                 #
#   OUTPUT TIMING                 #
#                                 #
###################################

# The output delay at port result is 420 + 80ps = 500ps or 0.50ns
#
#set_output_delay -max  0.50 -clock my_clk [get_ports -filter "@port_direction == out"]



###################################
#                                 #
#   DESIGN AREA                   #
#                                 #
###################################


# Area Constraint
#
set_max_area 0


###################################
#                                 #
#   INPUT DRIVER CELL             #
#                                 #
###################################
#input driver to all inputs is the smallest buffer (look in the reference manual)
set_driving_cell -lib_cell BUFX1 -library slow [get_ports -filter "@port_direction == in"]

###################################
#                                 #
#       LOAD ATTRIBUTE            #
#                                 #
###################################
#option 1 the output load is 25fF, or .025 pF
#set_load 0.025 [get_ports fibout]
#option 2 the output load is the input port of the largest buffer (look in the reference manual)
#set_load [load_of slow/BUFX20/A]  [get_ports fibout]

###################################
#                                 #
#   INPUT TRANSITION              #
#                                 #
###################################

# Port data_in is a chip level input and has an input transition of 120ps or 0.12 ns
#
set_input_transition 0.12 [get_ports -filter "@port_direction == in"]

###################################
#                                 #
#         FALSE PATH              #
#                                 #
###################################
#Don't try and run timing on paths running from reset pin
set_false_path  -from { reset }


###################################
#                                 #
#   ENVIRONMENTAL ATTRIBUTES      #
#                                 #
###################################
# From the wireload model selection table, a design size between 200 and 
# 8000 area units uses the model called "8000"; The default wireload 
# mode in this library in "enclosed"
#
set auto_wire_load_selection false
set_wire_load_model -name tsmc18_wl50