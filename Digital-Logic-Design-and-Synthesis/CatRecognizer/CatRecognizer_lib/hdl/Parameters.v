// ====================================================================
//	File Name:		CatRecognizer.v
//	Description:	Parameters include file
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ====================================================================

  // GLOBAL PARAMETERS
   `define Amba_Word 24 // Part of the Amba standard at moodle site
   `define Amba_Addr_Depth 12 // Part of the Amba standard at moodle site
   `define WeightPrecision 5 // Bit depth of the weights and bias
  
   // LOCAL PARAMETERS
   `define pixelNumber 12288 // How many pixel we expect
   `define PixelWidth  8 // Width of Data row in the data file 
   `define resultWidth (14 + `Amba_Word + `WeightPrecision) // Bit depth of the weights and bias
   `define iteration   4096 // Local var to keep track of the process
   `define WeightRowWidth (3 * `WeightPrecision) // Width of Data row in the weight bank
