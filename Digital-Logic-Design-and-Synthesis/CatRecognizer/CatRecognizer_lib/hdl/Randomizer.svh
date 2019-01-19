// ====================================================================
// ====================================================================
//	File Name:		Randomizer.class
//	Description:	Generate Random Data for APB Register File
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ==================================================================== 
// ==================================================================== 
package classes;

  //**********************Begin Class*************************************
  // This is the class that we will randomize.
class Randomizer #(int Amba_Word = 24);
    
  rand  reg [Amba_Word-1:0] RandomData; //regular random variable

  // Randomization constraints.
  constraint UpperLimit {
    RandomData<(1<<(Amba_Word)-1);
  }
 
  // Print out the items.
  function void print();
    $display("RandomData = %0b", RandomData);
  endfunction
  
endclass
  //**********************End Class*************************************

endpackage 
