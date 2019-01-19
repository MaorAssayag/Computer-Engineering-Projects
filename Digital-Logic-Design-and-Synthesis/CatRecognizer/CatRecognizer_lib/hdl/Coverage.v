// ====================================================================
//	File Name:		Coverage.v
//	Description:	Coverage file
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ==================================================================== 
module Coverage#(`include "Parameters.v")
(APB_interface.Coverage_net Covergae_interface);

covergroup CatRecognizer_clk @(posedge Covergae_interface.clk);
  // Reset active low
  rst_check : coverpoint Covergae_interface.rst {
    bins rst_bins[2]= {[0:1]};		// STANDARD CASE
  }
  
  // Amba_Addr , Amba_Addr_illegal
  PADDR_check 	:	coverpoint Covergae_interface.PADDR {
	 bins PADDR_bins[4]= {[0:(2**`Amba_Addr_Depth)/4 -1],
	                      [(2**`Amba_Addr_Depth)/4:2*(2**`Amba_Addr_Depth)/4 - 1],
	                      [2*(2**`Amba_Addr_Depth)/4:3*(2**`Amba_Addr_Depth)/4 - 1],
	                      [3*(2**`Amba_Addr_Depth)/4:4*(2**`Amba_Addr_Depth)/4 - 1]};
	}
	
	// APB Bus Enable
	PENABLE_check		:	coverpoint Covergae_interface.PENABLE {
	 bins PENABLE_bins[] = {0,1};
	}
  
  // APB Bus Select 
  PSEL_check		:	coverpoint Covergae_interface.PSEL {
	 bins PSEL_bins[] = {0,1};
	}
	
	// APB Write Data Bus  
	PWDATA_check		:	coverpoint Covergae_interface.PWDATA {
	 bins PWDATA_bins[4]= {[0:(2**`Amba_Word)/4 -1],
	                      [(2**`Amba_Word)/4:2*(2**`Amba_Word)/4 - 1],
	                      [2*(2**`Amba_Word)/4:3*(2**`Amba_Word)/4 - 1],
	                      [3*(2**`Amba_Word)/4:4*(2**`Amba_Word)/4 - 1]};
	}
	
	// APB Bus Write   
	PWRITE_check		:	coverpoint Covergae_interface.PWRITE {
	 bins PWRITE_bins[] = {0,1};
	}
	
	// APB Read Data Bus  
	PRDATA_check		:	coverpoint Covergae_interface.PRDATA {
	 bins PRDATA_bins[4]= {[0:(2**`Amba_Word)/4 -1],
	                      [(2**`Amba_Word)/4:2*(2**`Amba_Word)/4 - 1],
	                      [2*(2**`Amba_Word)/4:3*(2**`Amba_Word)/4 - 1],
	                      [3*(2**`Amba_Word)/4:4*(2**`Amba_Word)/4 - 1]};
	} 
	
	// CatRegonizer results
	CatRecOut_check		:	coverpoint Covergae_interface.CatRecOut {
	 bins CatRecOutt_bins[]		=	{0,1};
	}
endgroup

//=================================================
// Instance of covergroup CarRecCoverage_Clk
//=================================================
CatRecognizer_clk CarRecCoverageClk = new();

endmodule
