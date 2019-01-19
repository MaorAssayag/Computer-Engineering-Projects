#-------------------------------------------#
# Students ID : Maor Assayag     318550746  #
#               Refahel Shetrit  204654891  #
#
# generateVerilog - genrate include file in verilog that assign to register file 3 values
#                   each row (signed integers) from text file (1 value each row).
#-------------------------------------------#
import sys

file_to_read = "WeightsPrecision16.txt"
file_to_write = 'include_file_16.v'

orig_stdout = sys.stdout
f = open(file_to_write, 'w')
sys.stdout = f

def to_twoscomplement(bits, value):
    if value < 0:
        value = ( 1<<bits ) + value;
    formatstring = '{:0%ib}' % bits;
    return formatstring.format(value)

def LoadTextFile():
	with open(file_to_read, "r") as ins:
	    array = []
	    for line in ins:
	        array.append(int(line))
	return array

def generateVerilog(DataWidth, array):
    s = "";
    j=0;
    for i in range(0, len(array)):
        s = s + to_twoscomplement(int(DataWidth/3), array[i]);
        if ((i > 0) and ((i+1)%3==0)):
            print ("\t\tRegisterBank[%d] <= %d'b%s;" % (j,DataWidth,s))
            j=j+1;
            s = "";

generateVerilog(3 * 16, LoadTextFile())

sys.stdout = orig_stdout
f.close()
