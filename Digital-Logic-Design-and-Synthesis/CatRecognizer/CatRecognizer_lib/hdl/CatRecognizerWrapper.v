// ====================================================================
//	File Name:		CatRecognizerWrapper.v
//	Description:	CatRecognizer Wrapper with APB interface
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ==================================================================== 
module CatRecognizerWrapper (APB_interface.Cat_net interface_APB);

CatRecognizer CatRecognizer_1(
        .clk (interface_APB.clk),
        .rst(interface_APB.rst),
        .PENABLE(interface_APB.PENABLE),
        .PSEL(interface_APB.PSEL),
        .PWRITE(interface_APB.PWRITE),
        .PADDR(interface_APB.PADDR),
        .PWDATA(interface_APB.PWDATA),
        .PRDATA(interface_APB.PRDATA),
        .CatRecOut(interface_APB.CatRecOut));
        
endmodule