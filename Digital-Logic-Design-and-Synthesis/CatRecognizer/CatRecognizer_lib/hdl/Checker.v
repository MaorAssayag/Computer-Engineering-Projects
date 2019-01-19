// ====================================================================
//	File Name:		Checker.v
//	Description:	Checker file
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ====================================================================
`include "Parameters.v" 
`resetall
`timescale 1ns/1ns
module Checker (APB_interface.Checker_net APB,
   input [(`Amba_Word -1):0] RegisterBankAPB [(2**`Amba_Addr_Depth)-1:0],
   input [(`WeightRowWidth - 1):0] RegisterBankWeights [(2**`Amba_Addr_Depth)- 1:0],
   input signed [`resultWidth - 1: 0] currentResult,
   input doneFlag,
   input doneRead,
   input doneIteration,
   input [`Amba_Word-1:0] Start_work_reg);
   
   // =================================================================
   //  LOCAL vars
   // =================================================================
   reg reset; // System reset
   reg signed [15:0] bias [2:0]; // Bias bank
   reg [`Amba_Word-1:0] currentRead;
   reg [`Amba_Addr_Depth:0] currentAddress = 1; // current address to fetch data from
   reg [`Amba_Word-1:0] currentReadData;
   reg signed [`resultWidth - 1: 0] CheckerCurrentResult = 0;
   reg start_outputChecker = 0;
   reg first_check = 1'b1;
  
   //APB regs
   reg [`Amba_Word-1:0] APB_WriteData;
   reg [`Amba_Addr_Depth:0] APB_address;
   wire [`Amba_Word-1:0] APB_ReadData;
  
   //WeightsBank regs
   wire [`WeightRowWidth-1:0] Weights_ReadData; 
   reg [`Amba_Addr_Depth:0] Weights_address;
  
   reg [(`Amba_Word-1):0] PixelData_temp;// current row of data of pixels
   reg [(`WeightRowWidth-1):0] WeightsData_temp;// current row of data of weights
   reg signed [(2*(`WeightPrecision+`PixelWidth)):0] Result_1;
   reg signed [(2*(`WeightPrecision+`PixelWidth)):0] Result_2;
   reg signed [(2*(`WeightPrecision+`PixelWidth)):0] Result_3;
   reg signed [`PixelWidth:0]    p1;
   reg signed [`WeightPrecision-1:0] w1;
   reg signed [`PixelWidth:0]    p2;
   reg signed [`WeightPrecision-1:0] w2;
   reg signed [`PixelWidth:0]    p3;
   reg signed [`WeightPrecision-1:0] w3; 
   
  // =================================================================
  // Propertes
  // =================================================================
  // =============
  // Property
  // Reset Active
  // =============
  property rst_check;
         @(posedge APB.clk) (APB.rst==1) |=> APB.CatRecOut===1'bz && APB.PRDATA === {(`Amba_Word){1'bz}};
  endproperty
  assert property(rst_check)
    else $error("Error during rst_check");
  cover property (rst_check); 
   
  // =============
  // Property
  // APB Stable
  // =============
  property stable_apb_check;
          @(posedge APB.clk) APB.PSEL && APB.PWRITE && APB.PENABLE==1'b0 
                         |-> $stable(APB.PWRITE) && $stable(APB.PWDATA) && $stable(APB.PADDR);
  endproperty
  assert property(stable_apb_check) 
    else $error("Error during stable_apb_check");
  cover property (stable_apb_check); 
  
  // =============
  // Property
  // CatRecognizer output validation
  // =============
  property CatRecOut_positive_check;
          @(posedge APB.clk)  APB.CatRecOut == 1'b1 |->  (currentResult > 0);
  endproperty
  assert property(CatRecOut_positive_check)
    else $error("Error during CatRecOut_positive_check");
  cover property (CatRecOut_positive_check);
  
  property CatRecOut_negative_check;
          @(posedge APB.clk)  APB.CatRecOut == 1'b0 |->  (currentResult < 0);
  endproperty
  assert property(CatRecOut_negative_check)
    else $error("Error during CatRecOut_negative_check");
  cover property (CatRecOut_negative_check); 
  
  // =============
  // Property
  // Accumulate currentResult checker
  // =============
  property currentResult_check;
          @(posedge APB.clk)  start_outputChecker == 1'b1 |->  (CheckerCurrentResult == currentResult);
  endproperty
  assert property(currentResult_check)
    else $error("Error during currentResult_check");
  cover property (currentResult_check);
  
  // =================================================================
  // Computing & TASKS
  // =================================================================
  // =============
  // Computing current Result
  // =============
  always @(posedge APB.clk)
    begin
	  CheckerCurrentResult_compute;
	end
	 
   // =============
   // TASK
   // CheckerCurrentResult_compute task - accumulate the current Result
   // =============
  task CheckerCurrentResult_compute;
    begin
    if ((Start_work_reg == 1'b1) & (doneFlag == 0)) 
        begin  
        if (doneIteration == 0) 
            begin 
            if (first_check == 1'b1)
              begin
              #14 first_check = 1'b0;    
            end 
            start_outputChecker = 1'b1;    
            // Compute sigma of 12,288 multiplication
            //READ data
            APB_address = currentAddress; 
            Weights_address = currentAddress-1; // weights start from address 0           
            //Update current pixelData and WeightsData
            PixelData_temp = RegisterBankAPB[APB_address];
            WeightsData_temp = RegisterBankWeights[Weights_address];
             
            // Accumulate current Result - all signed, avoid accumulate 'z' or 'x'
            if (PixelData_temp >= 0) 
              begin
              p1 = {1'b0,PixelData_temp[`PixelWidth-1 :0]};
              w1 = WeightsData_temp[`WeightPrecision -1 :0] ; 
              p2 = {1'b0,PixelData_temp[(2*`PixelWidth)-1 : `PixelWidth]};
              w2 = WeightsData_temp[(2*`WeightPrecision)-1 : `WeightPrecision];
              p3 = {1'b0,PixelData_temp[(3*`PixelWidth)-1 :(2*`PixelWidth)]};
              w3 = WeightsData_temp[(3*`WeightPrecision)-1 :(2*`WeightPrecision)];
              Result_1 =  p1 * w1;
              Result_2 =  p2 * w2;
              Result_3 =  p3 * w3;
              CheckerCurrentResult = CheckerCurrentResult + Result_1 + Result_2 + Result_3;
            end  
            
            // Check if we done with the accumulation
            if (currentAddress == `iteration)
              begin 
              start_outputChecker = 1'b0;
              first_check = 1'b1;
              CheckerCurrentResult = 0;
              currentAddress = 1;
            end
            if (start_outputChecker == 1'b1)
            begin
             currentAddress = currentAddress + {{(`Amba_Addr_Depth){1'b0}},1'b1}; 
            end 
          end  
        end  
    end   
  endtask
                                            
endmodule