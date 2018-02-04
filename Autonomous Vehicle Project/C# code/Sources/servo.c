#include "TFC.h"
#include "mcg.h"
#define MaxDuty 0x660//1632
#define MinDuty 0x1AF//431
#define DeltaDuty 0x4F1//1201

void ServoConfig(){
	//Servo1 Configuration  
	//Servo1_EN
	PORTE_PCR21 = PORT_PCR_MUX(3); // PTE21 pin TPM1_CH1- ALT3
	// Servo1_samp
	PORTE_PCR29 = PORT_PCR_MUX(0); // PTE29 pin ADC0_SE4b- ALT1	
	//Servo2 Configuration  
	//Servo2_EN
	PORTE_PCR31 = PORT_PCR_MUX(3); // PTE31 pin TPM0_CH4- ALT3
	// Servo2_samp
	PORTE_PCR30 = PORT_PCR_MUX(0); // PTE30 pin ADC0_SE23- ALT1	
	backServo=-1;
	TPM1_C1V = 0x1AF;// 0 duty cycle
	TPM0_C4V =0x660;// 0 duty cycle
	TPM0_C4SC |= TPM_CnSC_MSB_MASK + TPM_CnSC_ELSB_MASK;//En_Servo2
	TPM1_C1SC |= TPM_CnSC_MSB_MASK + TPM_CnSC_ELSB_MASK;//Enable_Servo1
}

void Servo1SetPos (int Servo1Position){
	if(backServo==1){
		Servo1Position=Servo1Position-5;
	}else if(backServo==0){
		Servo1Position=Servo1Position+5;
	}
	if(Servo1Position>90){
		Servo1Position=90;
	}
	if(Servo1Position<0)
	{
		Servo1Position=0;
	}
	int Duty = (int)((Servo1Position*DeltaDuty/180) + MinDuty);
	TPM1_C1V=Duty;
	Servo1CurrPosition=Servo1Position;
}

void Servo2SetPos (int Servo2Position){
	if(backServo==1){
		Servo2Position=Servo2Position+5;
		}else if(backServo==0){
		Servo2Position=Servo2Position-5;
		}
	if(Servo2Position>180){
		Servo2Position=180;
	}
	if(Servo2Position<70)
	{
		Servo2Position=70;
	}
	int Duty = (int)((Servo2Position*DeltaDuty/180) + MinDuty);
	TPM0_C4V=Duty;
 	Servo2CurrPosition=Servo2Position;
}

//-----------------------------------------------------------------
// PRESS 1 Function CASES
//-----------------------------------------------------------------
void Servo_Movement(int mode){
	PORTE_PCR31 = PORT_PCR_MUX(3); // PTE31 pin TPM0_CH4- ALT3
	switch(mode){
		//get the servo to the sides of the car 		
		case 1: 
			backServo=0;
			scanum=35;
			MultiDrop=4;
			MoveServo=1;
			option = 0;
			while(scanum>0);
			break;	
		//move the servo in dir*multiDrop degrees   	
		case 2: 
			//TPM0_SC |= TPM_SC_CMOD(1); //start the TPM0 PWM counter 
			if(Exit==1||Exit==2){//Exit logic
				if(Exit==1){	
					if(Servo1CurrPosition<90)
						Servo1SetPos(Servo1CurrPosition);}
				else{		
					if(Servo2CurrPosition>90)
						Servo2SetPos(Servo2CurrPosition);
					if(Servo1CurrPosition>0)
						Servo1SetPos(Servo1CurrPosition-6);
				}

			}else{
				Servo1SetPos(Servo1CurrPosition);
				Servo2SetPos(Servo2CurrPosition);
			}
			option = 0;
			break;
		// move to the front of the car
		case 3: 
			backServo=1;
			scanum=35;
			MultiDrop=4;
			MoveServo=1;
			while(scanum>0);
		
	}
	option = 0;
}

void RightExitconfig(){
	TurnOnADC();
	Exit=1;
	turnToAngle(180);
	Servo_Movement(1);
	
}
void leftExitconfig(){
	TurnOnADC();
	Exit=2;
	turnToAngle(0);
	Servo_Movement(1);
	//ExitADCright();
}
void Straightconfig(){
	CheckWhereTheServo(0);//check  where the servo and change if needed
	TurnOnADC();
	delay=3;
	while(delay>0);
}
void CheckWhereTheServo(int position){
	if(Servo1CurrPosition==90&&position==0){
		Servo_Movement(3);
	}else if(Servo1CurrPosition==0&&position==90)
		Servo_Movement(1);
}
