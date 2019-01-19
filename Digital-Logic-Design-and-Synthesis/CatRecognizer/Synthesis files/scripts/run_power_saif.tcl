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
#power report -all -bsaif /users/agnon/year2001/kolaman/Lab3/Final/rtl/tst.saif

#reading power tuggle information from simulation
read_saif -input rtl/tst.saif -instance_name "tb_CatRecognizer/CatRec/CatRecognizer_1" -verbose

##############################################################
####################Compile the Design########################
##############################################################


compile

#clock gating
#compile -gate_clock 

report_power

