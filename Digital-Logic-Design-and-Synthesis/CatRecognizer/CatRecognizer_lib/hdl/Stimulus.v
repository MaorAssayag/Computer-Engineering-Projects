// ====================================================================
//	File Name:		Stimulus.v
//	Description:	Stimulus file
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ==================================================================== 
`resetall
`timescale 1ns/1ns
`include "Parameters.v"
import classes::*; 
module Stimulus (APB_interface.Stimulus_net APB);

  // LOCAL vars
  reg [`Amba_Addr_Depth:0]	 APB_address;
	reg [`Amba_Word-1:0]		    APB_WriteData;
  integer i = 0;
  integer j = 0;
  integer flag = 0;
  integer tmp1, tmp2, fd;
  integer imageNumber = 0;
  reg [8*4:1] str;
  reg [15:0] data;
  reg [7:0] mem [12287:0];
  
  // Randomizer
  Randomizer #(.Amba_Word(`Amba_Word)) RandomDataGenerator =new();
  
  // System clocks
  always begin : generate_clock #2 APB.clk = ~APB.clk;
  end
  
// Main Body
initial begin : init
  
  // =============
  // Test Reset Active High
  // =============
  APB.clk = 0;
  APB.PENABLE = 0;
  APB.rst = 1;
  #10 APB.rst = 0; 
  #15 APB.rst = 1;
  #5 APB.rst  = 0;
  #5 APB.rst  = 1;
  #5 APB.rst  = 0;
  
  // =============
  // Reset signals
  // =============
  APB.PSEL <= 1'b0;
  APB.PWRITE <= 1'b0;
  
  // =============
  // Insert Start_work = 0 - CatRecognizre will not start computing
  // =============
  APB_address = 0;
  APB_WriteData = {`Amba_Word{1'b0}};
  Write2APB(APB_address, APB_WriteData);
  APB_address = APB_address + 1;
  
  // =============
  // Randomize WriteData value
  // =============
  assert(RandomDataGenerator.randomize());
  RandomDataGenerator.print();
  APB_WriteData <= RandomDataGenerator.RandomData; 
  
  // =============
  // Fill Register File with random values
  // =============
  for(i = 1; i<`iteration; i=i+1)
	begin
		  assert(RandomDataGenerator.randomize()); 
			APB_WriteData <= RandomDataGenerator.RandomData;
			Write2APB(i, APB_WriteData);
			APB_address <= i;
	end
  
  // =============
  // Insert Start_work = 1 - CatRecognizre will start computing
  // =============
  APB_address = 0;
  APB_WriteData = {{(`Amba_Word-1){1'b0}},1'b1};
  Write2APB(APB_address, APB_WriteData);
  
  // =============
  // Check 40 images
  // =============
  while (imageNumber <40)
  begin
  // Write image #imageNumber & Compute result
  j = 0;
  APB.PWRITE = 0;
  #35000 ResetDesign();
  //fd = $fopen($sformatf("../TestBenchInputFiles/Image%0d.txt",imageNumber),"r");
  fd = $fopen($sformatf("C:/Users/MaorA/Desktop/CatRecognizer/CatRecognizer/CatRecognizer_lib/TestBenchInputFiles/Image%0d.txt",imageNumber),"r");
  imageNumber = imageNumber + 1;
  while (!$feof(fd)) begin
       tmp1 = $fgets(str, fd);
       tmp2 = $sscanf(str, "%d", data);
       mem[j] = data;      
       if ((j>0) && ((j+1)%3==0)) begin
         APB_address = (j+1)/3;
         APB_WriteData = {mem[j-2],mem[j-1],mem[j]};
         Write2APB(APB_address, APB_WriteData);
       end
       j=j+1;
       if ($feof(fd)) begin
         flag = 1; //end of this while
       end
  end
  // Insert Start_work = 1 - CatRecognizre will start computing
  APB_address = 0;
  APB_WriteData = {{(`Amba_Word-1){1'b0}},1'b1};
  Write2APB(APB_address, APB_WriteData);
end
   
end

// ===================
//  TASK
//  Write to APB task
// ===================
task Write2APB;
	input [`Amba_Addr_Depth:0]	 APB_address;
	input [`Amba_Word-1:0]		    APB_WriteData;
	begin
		@(posedge APB.clk)
		begin
    		APB.PSEL = 1'b1;
    		APB.PWRITE = 1'b1;
    		APB.PADDR = APB_address;
    		APB.PWDATA = APB_WriteData;
    		#3 APB.PENABLE = 1'b1;
    		#4 APB.PENABLE = 1'b0;
		end
	end
endtask

// ===================
//  TASK
//  Reset Design
// ===================
task ResetDesign;
	begin
  APB_address = 0;
  APB_WriteData = {`Amba_Word{1'b0}};
  Write2APB(APB_address, APB_WriteData);
  #20 APB.rst <= 1'b1;
  #40 APB.rst <= 1'b0;
	end
endtask
    
endmodule
