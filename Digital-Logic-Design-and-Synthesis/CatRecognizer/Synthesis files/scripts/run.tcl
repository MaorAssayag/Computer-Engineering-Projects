##############################################################
#################Read The Design and check it#################
##############################################################
#set power_preserve_rtl_hier_names "true"

read_verilog {CatRecognizer.v, APB.v, Neuron.v, Accumulator.v, WeightsBank.v}
current_design catrec
link
check_design
##############################################################
#################Read The Design and check it#################
##############################################################


##############################################################
##########Constraint the Design and check them################
##############################################################
source constraints.tcl

check_design
check_timing
#report_design
#report_clock
#report_port -verbose
##############################################################
##################Constraint the Design#######################
##############################################################


##############################################################
####################Compile the Design########################
##############################################################
compile -gate_clock 

#report_power
#report_constraint -all_violators
#report_area
#report_timing


## Save the design
write -format ddc -hier -out mapped/catrec.ddc

# save the design in "verilog" format inside mapped directory
write -f verilog -hierarchy -output mapped/catrec_GLV.v

#save the SDF file
write_sdf mapped/catrec.sdf 

