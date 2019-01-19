##############################################################
#################Read The Design and check it#################
##############################################################

read_verilog {CatRecognizer.v, APB.v, Neuron.v, WeightsBank.v}
current_design catrec
link

##############################################################
#################Read The Design and check it#################
##############################################################


##############################################################
##########Constraint the Design and check them################
##############################################################
source constraints.tcl


##############################################################
##################Read in the power toggle report file #######
##############################################################
#created the saif file in questasim using the following commands 
#power add /UUT/*
#run 1000
#power report -all -bsaif /users/agnon/year2006/maoryak/lab3/cat/rtl/tst.saif

#reading power tuggle information from simulation
#read_saif -input rtl/tst.saif -instance_name "fibgen_tb/UUT" -verbose

##############################################################
####################Compile the Design########################
##############################################################

compile

#clock gating option
#compile -gate_clock 

report_power

