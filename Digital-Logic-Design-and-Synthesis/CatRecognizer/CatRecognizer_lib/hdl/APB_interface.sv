// ====================================================================
//	File Name:		APB_interface.sv
//	Description:	APB interface for the Coverage, Stimulus and Checker
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ====================================================================
`include "Parameters.v"
interface APB_interface();           
    
    logic                      clk;      // system clock
    logic                      rst;      // Reset active low
    logic                      PENABLE;  // APB Bus Enable/clk
    logic                      PSEL;     // APB Bus Select
    logic                      PWRITE;   // APB Bus Write
    logic [`Amba_Addr_Depth:0] PADDR;    // APB Address Bus
    logic [`Amba_Word-1:0]     PWDATA;   // APB Write Data Bus
    logic [`Amba_Word-1:0]     PRDATA;   // APB Read Data Bus
    logic                      CatRecOut;// CatRecognizer result
  
    modport Coverage_net(input  clk,
                          rst,
                          PENABLE,
                          PSEL,
                          PWRITE, 
                          PADDR,
                          PWDATA,
                          PRDATA,
                          CatRecOut);

    modport Stimulus_net (output clk,
                          rst,
                          PENABLE,
                          PSEL,
                          PWRITE, 
                          PADDR,
                          PWDATA,
                          PRDATA,
                          CatRecOut);
                             
    modport Checker_net(input clk,
                          rst,
                          PENABLE,
                          PSEL,
                          PWRITE, 
                          PADDR,
                          PWDATA,
                          PRDATA,
                          CatRecOut);
                          
    modport Cat_net(input clk,
    rst,
    PENABLE,
    PSEL,
    PWRITE, 
    PADDR,
    PWDATA,
    output PRDATA,CatRecOut);
endinterface