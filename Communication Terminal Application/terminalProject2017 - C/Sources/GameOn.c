/*
 * GameOn.c
 *
 *  Created on: Aug 16, 2017
 *      Author: refael
 */
#include "GAMEON.h"
void updatePara(){
	UART0_C2 &=~UART_C2_TIE_MASK; 
	char baudratePara[4];
	int PSSBPara[4];
	int i;
	// get the baud rate and ppsb
	for(i=0;i<8;i++){
		if(i<4)
			baudratePara[i]=out();
		else
			PSSBPara[i-4]=(int)out();
	}
	//send ack
	out();
	Ack();
	int baudRate=(baudratePara[0]-'0')*1000+(baudratePara[1]-'0')*100+(baudratePara[2]-'0')*10+(baudratePara[3]-'0')*1;;
	ChangePara(PSSBPara,baudRate);
	UART0_C2 |= UART0_C2_TE_MASK |UART0_C2_RE_MASK;
}
void ChangePara(int ChangeArr[],int newbaudRate){
	UART0_C2 &= ~(UART0_C2_TE_MASK |UART0_C2_RE_MASK);
	//update the baud rate
	Uart0_Br_Sbr(48000000/2/1000, newbaudRate);
	if(ChangeArr[0]<2){
		UART0_C4 &=~UART0_C4_M10_MASK;// change the bit of 10 bit trans
		if(ChangeArr[0]==0)
			UART0_C1 &=~UART0_C1_M_MASK;// 8 bit trans
		else{
			UART0_C1 |=UART0_C1_M_MASK;// 9 bit trans
			RED_LED_ON;
		}
	}else{// 10 bit trans
		UART0_C1 &=~UART0_C1_M_MASK;
		UART0_C4 |=UART0_C4_M10_MASK;
	}
	if(ChangeArr[1]==1)
		UART0_BDH &=~UART0_BDH_SBNS_MASK;//1 stop bit
	else if(ChangeArr[1]==2)
		UART0_BDH |=UART0_BDH_SBNS_MASK;//2 stop bit
	if(ChangeArr[2]==0){
		UART0_C1 &=~UART0_C1_PE_MASK;//no parity bit
	}else{
		UART0_C1 |=UART0_C1_PE_MASK;//yes parity bit
		if(ChangeArr[2]==1){
			UART0_C1 &=~UART0_C1_PT_MASK;//even bit
		}else if(ChangeArr[2]==2){
			UART0_C1 |=UART0_C1_PT_MASK;// odd bit	
		}
	}

}
void gameon(){
	char a=out();
	RGB_LED_OFF;
	PIT_TCTRL0 &= ~PIT_TCTRL_TEN_MASK;//enable PIT0
	switch (a){
		case '1': 
			RGB_LED_OFF;
			RED_LED_ON;
			out();
		break;
		case '2':
			RGB_LED_OFF;
			BLUE_LED_ON;
			out();
		break;
		case '3':
			RGB_LED_OFF;
			RED_LED_ON;
			GREEN_LED_ON;
			out();
		break;
		case '4':
			RGB_LED_OFF;
			GREEN_LED_ON;
			out();
		break;
		case '5':
			RGB_LED_OFF;
			RED_LED_ON;
			BLUE_LED_ON;
			out();
		break;
		case '6':
	   	    RED_LED_ON;
		    GREEN_LED_ON;
	    	BLUE_LED_ON;
			out();
		break;
		case '7':
			RGB_LED_OFF;
			BLUE_LED_ON;
			GREEN_LED_ON;
			out();
		break;
		case '8':
			inStringT("l\n");
			filelist();
			out();
		break;
		case '9':
			inStringT("S\n");
			sendFile();
			out();
		break;
		case 'A':
			addFile();
		break;
		case 'B':
			updatePara();
			out();
		break;
		case 'R':
			__iar_program_start();
		break;
		case 'C':
			RGB_LED_OFF;
			out();
		break;
	}	
	f--;
}
void Runfilechar(char a){
	switch(a){
		case 'r':
		funarry[i]=1;
		break;
		case 'w':
		funarry[i]=2;
		break;
		case 'b':
		funarry[i]=3;
		break;
		case 'y':
		funarry[i]=4;
		break;
		case 'a':
		funarry[i]=5;
		break;
		case 'p':
		funarry[i]=6;
		break;
		case 'g':
		funarry[i]=7;
		break;
	}
	color=0;
	i++;
	count++;
}
void Rundel(char a){
	Delaysum[delarry]=a;
	if(delarry==3){
		int* delayNum=&Delaysum;
		funarry[i]=(Delaysum[0]-'0')*1000+(Delaysum[1]-'0')*100+(Delaysum[2]-'0')*10+(Delaysum[3]-'0')*1;
		i++;
		count++;
		del=0;
		delstap=0;
		delarry=0;
	}else
		delarry++;
}
