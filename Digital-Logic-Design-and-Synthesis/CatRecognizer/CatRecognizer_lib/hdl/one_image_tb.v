`timescale 1ns/1ns
// ====================================================================
//	File Name: CatRecognizer_tb.v
//	Description: Simulate a CPU. First extract the correct answears from a text file, then send
//              an image and check the output of CatRecognizer. This test bench cover 1 provided
//              image.
//
// Parameters : WeightPrecision = 5/8/16
//              Amba_Addr_Depth = 12/13/14
//              WeightRowWidth = WeightPrecision * 3 = 15/24/48
//
//	Date: 28/11/2018
//	Designers: Maor Assayag, Refael Shetrit
// using Mentor Graphics HDL Designer(TM) 2012.1 (Build 6)
// ====================================================================
module one_image_tb;
  localparam Amba_Word = 24;
  localparam Amba_Addr_Depth = 13;
  localparam WeightPrecision = 8;
  localparam WeightRowWidth = WeightPrecision * 3;
  localparam PixelWidth = 8;

   integer   fd;
   integer i = 0;
   integer j = 1;
   integer flag = 0;
   integer tmp1, tmp2;

   reg [15:0] data;
   reg [8*4:1] str;
   reg [7:0] mem [12287:0];

  //CatRecognize inputs/outputs
  reg    clk;
  reg    rst;
  reg    PENABLE;
  reg    PSEL;
  reg    PWRITE;
  reg  [Amba_Word-1:0] APB_WriteData;
  reg  [(Amba_Addr_Depth -1):0] APB_address;
  wire [Amba_Word-1:0] APB_ReadData;
  wire CatRecOut;
  reg CorrectResults [40:0];

CatRecognizer #(.Amba_Word(Amba_Word), .Amba_Addr_Depth(Amba_Addr_Depth), .WeightPrecision(WeightPrecision)) CatRecognizer_1(
        .clk (clk),
        .rst(rst),
        .PENABLE(PENABLE),
        .PSEL(PSEL),
        .PWRITE(PWRITE),
        .PADDR(APB_address),
        .PWDATA(APB_WriteData),
        .PRDATA(APB_ReadData),
        .CatRecOut(CatRecOut));

 initial begin
   fd = $fopen($sformatf("C:/Users/MaorA/Desktop/CatRecognizer/CatRecognizer/CatRecognizer_lib/TestBenchInputFiles/ResultsPrecision%0d.txt",WeightPrecision),"r");
   while (!$feof(fd)) begin
     tmp1 = $fgets(str, fd);
     tmp2 = $sscanf(str, "%d", data);
     CorrectResults[i] = data;
     i = i +1;
   end
   
    fd = $fopen("C:/Users/MaorA/Desktop/CatRecognizer/CatRecognizer/CatRecognizer_lib/TestBenchInputFiles/Image11.txt","r");
    clk = 0;
    data = 0;
    i = 0;
    tmp1 = 1;
    rst = 1'b1;
    #4 rst = 0;
    //insert Start_work = 0
    PWRITE = 'b1;
    PSEL = 'b1;
    PENABLE = 'b0;
    APB_address = 0;
    APB_WriteData = {Amba_Word{1'b0}};

    // load pixels
    while (!$feof(fd)) begin
       tmp1 = $fgets(str, fd);
       tmp2 = $sscanf(str, "%d", data);
       mem[i] = data;
       
       if ((i>0) && ((i+1)%3==0)) begin
         APB_address = (i+1)/3;
         APB_WriteData = {mem[i-2],mem[i-1],mem[i]};
       end

       i=i+1;
       if ($feof(fd)) begin
         flag = 1; //end of this while
       end
       @(posedge PENABLE);
    end
  
     //insert Start_work = 1
    while (j < 4150) begin
      if (flag == 1) begin
        #8
        PWRITE = 1'b0; 
        #2
        APB_address = 0;
        APB_WriteData = {{(Amba_Word-1){1'b0}},1'b1};
        #2 PWRITE = 1'b1; 
        #8 PWRITE = 1'b0;
        flag = 0;
      end
      j = j+1;
      @(posedge clk);
    end
    
    if (CorrectResults[11] == CatRecOut) 
      $write ("TestBench for image: true") ;
    else
      $write ("TestBench for image: false") ;
    $finish;
 end // initial begin

 always #2 clk = ~clk;
 always #4 PENABLE = ~PENABLE;
endmodule // stim_gen
