// ====================================================================
//	File Name:		APB.v
//	Description:	Register file for the pixels data. The value extracted by the cpu (or test bench)
//              from image text data file. Each register stores 3 lines of total 24 bits.
//
// Parameters :   Amba_Word = 24/32
//                Amba_Addr_Depth = 12/13/14
//
//	Date:			28/11/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ====================================================================
`include "Parameters.v"
module APB (clock, reset, control, address, WriteData, ReadData, Start_work_reg);
  
  // DEFINE INPUTS VARS
  input wire clock;
  input wire reset;
  input wire [1:0] control;
  input wire [(`Amba_Addr_Depth):0] address;
  input wire [(`Amba_Word -1):0]       WriteData;
  
  // DEFINE OUTPUTS VARS
  output wire [(`Amba_Word -1):0] ReadData;
  output wire [(`Amba_Word -1):0] Start_work_reg;
  
  // LOCAL vars
  reg [(`Amba_Word -1):0] RegisterBank [(2**(`Amba_Addr_Depth+1))-1:0]; // Register file storage, each register stores #amba_word bits
  reg [`Amba_Word -1:0]   out_val;
  reg [`Amba_Word -1:0]   out_start_work;
  reg en_read;
  
  // BODY
  // Read and write from register file
  // control = 01 -> Write at least 3 pixels to the register
  // control = 10 -> Read 1 data address of Pixels for the CPU
  always @(posedge clock) begin : PixelBankOperation
    if (reset)
      begin
      out_start_work <= {(`Amba_Word){1'b0}};
      out_val <= {(`Amba_Word){1'b0}};
      en_read <= 1'b0;
      RegisterBank[0] <= {(`Amba_Word){1'b0}};
    end
    else 
      begin
      en_read <= control[1];
      out_start_work <= RegisterBank[0];   
      case (control)
      2'b01 :   RegisterBank[address] <= WriteData; // Write pixel data
      2'b10 :   out_val <= RegisterBank[address]; // Read pixel data
      default : out_val <= {`Amba_Word{1'bz}};
      endcase
    end
  end
  
  // Output data if not writing. If we are writing,
  // do not drive output pins. This is denoted
  // by assigning 'z' to the output pins.
  assign ReadData = (en_read) ?  out_val : {`Amba_Word{1'bz}};
  assign Start_work_reg = out_start_work;
endmodule