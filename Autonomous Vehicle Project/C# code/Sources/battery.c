/*
 * battery.c
 *
 *  Created on: Jun 5, 2017
 *      Author: maoryak
 */
#include "battery.h"

void BattLedConfig (){
	PORTE_PCR22 = PORT_PCR_MUX(1); // PTE22 pin ADC0_SE3- ALT1
	//
	PORTB_PCR8 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; // PTB8 pin as GPIO
	PORTB_PCR9 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; // PTB9 pin as GPIO
	PORTB_PCR10 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK;// PTB10 pin as GPIO
	GPIOB_PDDR |= PORT_LOC(8) + PORT_LOC(9) + PORT_LOC(10); //Setup as output pin	
}


// turn 3 LEDS *_*_*_* for battery level 1 to 8
void BattLedState (double BattSamp){// BattSamp = from 6.05 to 7.5 v
	float currentBatt = 1.23 - BattSamp;
	int levelBatt =8 - (currentBatt/0.21)*8; // 7.5-6.05=1.45v
	if (levelBatt & 0x001){
		TFC_BAT_LED0_ON;
	}else{
		TFC_BAT_LED0_OFF;	
	}
	if(levelBatt & 0x010){
		TFC_BAT_LED1_ON;
	}else{
		TFC_BAT_LED1_OFF;	
	}
	if(levelBatt & 0x100){
			TFC_BAT_LED2_ON;
	}else{
		TFC_BAT_LED2_OFF;	
	}
	batteryLevel = levelBatt; // for global variable
}

void PrintBattery(){
	double temp = (batteryVOLT/1217.0);// 1217 is 1V
	BattLedState(temp);
	// then print battery level
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n battery level is : ");//logic to print the current motor speed
	int k = 0;
	while (k==0){
		if (UART0_S1 & UART_S1_TDRE_MASK){
			UART0_D=(int)(batteryLevel+48); //X.0 DIGIT 
			k++;
		}
	}
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	state = 0;	
}
