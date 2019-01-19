// ====================================================================
// ====================================================================
//	File Name:		Stimulus_tb.v
//	Description:	Stimulus test bench - coverage & Checker
//
//
//	Date:			19/12/2018
//	Designers:		Maor Assayag, Refael Shetrit
// ==================================================================== 
// ==================================================================== 
`resetall
`timescale 1ns/1ns
module tb_CatRecognizer ;

APB_interface APB_inter();

CatRecognizerWrapper CatRec(.interface_APB(APB_inter)); 
Coverage Coverager(.Covergae_interface(APB_inter)); 
Stimulus Stimulus(.APB(APB_inter)); 
Checker check(.APB(APB_inter),
              .RegisterBankAPB(CatRec.CatRecognizer_1.APB_Bank.RegisterBank),
              .RegisterBankWeights(CatRec.CatRecognizer_1.Weights_Bank.RegisterBank),
              .currentResult(CatRec.CatRecognizer_1.currentResult),
              .doneFlag(CatRec.CatRecognizer_1.doneFlag),
              .doneRead(CatRec.CatRecognizer_1.doneRead),
              .doneIteration(CatRec.CatRecognizer_1.doneIteration),
              .Start_work_reg(CatRec.CatRecognizer_1.Start_work_reg));
endmodule
