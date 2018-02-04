/*
 * UltraSonic.c
 *
 *  Created on: Jun 14, 2017
 *      Author: maoryak
 */

#include "DistSens.h"
#include "TFC.h"

void UltraSonicConfig(){
	PORTC_PCR3 = 0; // assign PTC3 as TPM0_CH2
	PORTC_PCR4 = 0; // assign PTC4 as TPM0_CH3
	PORTD_PCR1 = PORT_PCR_MUX(4); // PTD1(TPM0_CH1) - output
	PORTD_PCR2 = PORT_PCR_MUX(4); // PTD2(TPM0_CH2) - inputCapture
	PORTD_PCR3 = PORT_PCR_MUX(4); // PTD3(TPM0_CH3) - inputCapture
}

//-----------------------------------------------------------------
//  Function to Print the speed
//-----------------------------------------------------------------
void PrintDistance(){
	double DistanceToPrint1;
	double DistanceToPrint2;
	//calculate the distance
	if (state == 3 || state == 4){ //IR
		currentDistance1 = DistanceMeasuring1(sens1);
		currentDistance2 = DistanceMeasuring2(sens2);
		DistanceToPrint1 = currentDistance1;
		DistanceToPrint2 = currentDistance2;
	}
	if (state ==5){
		UltraSonicSensing();
		DistanceToPrint1 = currentDistanceUltra1;
		DistanceToPrint2 = currentDistanceUltra2;
	}
	// then print distance 1
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n Distance 1 from the object is : \r\n");//logic to print the current motor speed
	int k=4;
	 while(k>=0){
		if(UART0_S1 & UART_S1_TDRE_MASK){ // TX buffer is empty and ready for sending
		  if(k==4){ UART0_D=((int)(DistanceToPrint1/100)%10)+48;} //X00.0 DIGIT 
		  if(k==3){ UART0_D=(int)(DistanceToPrint1/10)%10+48;}//0X0.0 DIGIT
		  if(k==2){ UART0_D=(int)(DistanceToPrint1)%10 + 48;} //00X.0 DIGITONE DIGIT
		  if(k==1){ UART0_D=46;}
		  if(k==0){ UART0_D=(int)(DistanceToPrint1*10)%10 + 48;} //00.X DIGITONE DIGIT AFTER DOT
		  k--;
		 }
	 }
	UARTprintf(UART0_BASE_PTR,"  [cm per second]  \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	//-----------------------------------//
	// then print distance 2
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n Distance 2 from the object is : \r\n");//logic to print the current motor speed
	k=4;
	 while(k>=0){
		if(UART0_S1 & UART_S1_TDRE_MASK){ // TX buffer is empty and ready for sending
		  if(k==4){ UART0_D=((int)(DistanceToPrint2/100)%10)+48;} //X00.0 DIGIT 
		  if(k==3){ UART0_D=(int)(DistanceToPrint2/10)%10+48;}//0X0.0 DIGIT
		  if(k==2){ UART0_D=(((int)(DistanceToPrint2)%10))+48;} //00X.0 DIGITONE DIGIT
		  if(k==1){ UART0_D=46;}
		  if(k==0){ UART0_D=(int)(DistanceToPrint2*10)%10+48;} //00.X DIGITONE DIGIT AFTER DOT
		  k--;
		 }
	 }
	UARTprintf(UART0_BASE_PTR,"  [cm per second]  \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	option = 0;
}
//-----------------------------------------------------------------
// Print UltraSonicDistance
//-----------------------------------------------------------------
void UltraSonicSensing(){
	currentDistanceUltra1 = wheel1Delta * 0.0226666666666667; // [time echo is high]*17000 -> (wheel1Delta / 750000) * 17000; 
	currentDistanceUltra2 = wheel2Delta * 0.0226666666666667; // [time echo is high]*17000 -> (wheel1Delta / 750000) * 17000; 
}
//-----------------------------------------------------------------
// PRESS 5 Function - UltraSonic
//-----------------------------------------------------------------
void UltraSonic_Sensor(){
	option=0;
	init_TPM0(3);
}
void UltraDistance(){
	UltraSonicSensing();
}
