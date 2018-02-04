#include "TFC.h"
#include "mcg.h"
#define MUDULO_REGISTER  0x2EE0

//-----------------------------------------------------------------
// motor - MotorConfig
//-----------------------------------------------------------------
void MotorConfig(){
		//GPIO Configuration  - Output
		// Motor 1 direction
		PORTC_PCR5 = PORT_PCR_MUX(1); // assign PTC5 
		GPIOC_PDDR |= PORT_LOC(5);  // PTC5 is Output
		PORTC_PCR6 = PORT_PCR_MUX(1); // assign PTC6 
		GPIOC_PDDR |= PORT_LOC(6);  // PTC6 is Output
		// Motor 2 direction
		PORTC_PCR7 = PORT_PCR_MUX(1); // assign PTC5 
		GPIOC_PDDR |= PORT_LOC(7);  // PTC7 is Output
		PORTC_PCR10 = PORT_PCR_MUX(1); // assign PTC6 
		GPIOC_PDDR |= PORT_LOC(10);  // PTC10 is Output
		// Motor 1 enable
		PORTE_PCR23 = PORT_PCR_MUX(3); // PTE23 pin TPM2_CH1- ALT3
		// Motor 2 enable
		PORTE_PCR20 = PORT_PCR_MUX(3); // PTE20 pin TPM1_CH0- ALT3	
}

void EncoderConfig(){
	//PORTD_PCR1 = 0; // PTD1(TPM0_CH1) - output
	//PORTD_PCR2 = 0; // PTD2(TPM0_CH2) - inputCapture
	//PORTD_PCR3 = 0; // PTD3(TPM0_CH3) - inputCapture
	PORTC_PCR3 = PORT_PCR_MUX(4); // assign PTC3 as TPM0_CH2
	PORTC_PCR4 = PORT_PCR_MUX(4); // assign PTC4 as TPM0_CH3
}

void EncoderChecker(){//check the encoders for high accuracy only straight
	if(wheel1Speed > 35){
		   wheel1Duty = wheel1Duty - 45;
		   //wheel2Duty = wheel2Duty + (wheel2Duty/wheel2Speed)*0.3;
		  // TPM1_C0V = wheel2Duty;
	       TPM2_C1V = wheel1Duty;
	}else{
		   wheel1Duty = wheel1Duty + 45;
	       TPM2_C1V = wheel1Duty;
	}
	if(wheel2Speed > 35){
		   wheel2Duty = wheel2Duty - 45;
		  // wheel1Duty = wheel1Duty + (wheel1Duty/wheel1Speed)*0.3;
		   TPM1_C0V = wheel2Duty;
	      // TPM2_C1V = wheel1Duty;
	}else{
		   wheel2Duty = wheel2Duty + 45;
		   TPM1_C0V = wheel2Duty;
	}
}
