// ====================================================================
// File Name: Neuron.v
// Description: Basic multiplier of 8bit pixel data and 5/8/16 bit corresponding weight.
//
// Date: 28/11/2018
// Designers: Maor Assayag, Refael Shetrit
// using Mentor Graphics HDL Designer(TM) 2012.1 (Build 6)
// ====================================================================
`include "Parameters.v"
module Neuron (p, w, result);
  
  // DEFINE INPUTS VARS
   input  wire signed  [`PixelWidth:0]    p; // pixel data, padding MSB 0 - enable us using signed
   input  wire signed  [`WeightPrecision-1:0] w; // weight data
  
  // DEFINE OUTPUTS VARS
   output wire signed  [(2*(`WeightPrecision + `PixelWidth)):0] result;
  
  // BODY
   assign result = p * w;

endmodule
