# include "TFC.h"
# define  Turn1AngleTime 3.9 //need to check
# define  Turn2AngleTime 4 //need to check

int main(void){
	ClockSetup();
	InitGPIO();
	InitTPM(0);
	InitTPM(1);
	InitTPM(2);
	InitGPIO();
	InitUARTs();
	MotorConfig();
	adc_init();
	EncoderConfig();
	BattLedConfig ();
	pit_init();
	DistSensConfig();
	ServoConfig();
	printMenu(); // print the menu
	
	target=4 ; //to begin
	currentAngle = 90;
	distFromStartingPoint = 80; // change by hanan
	delay=180;
	while(delay>0);
	//turnToAngle(0);
	gameOn();
//	EnterArena();
	while(1){
		wait();
	}
	return 0;
}
//-----------------------------------------------------------------
// TPM0 Function
//-----------------------------------------------------------------
void init_TPM0(int mode){
	switch(mode){
		case 1: 
			//PORTE_PCR31 &= ~PORT_PCR_MUX(3); // PTE31 pin TPM0_CH4- ALT3
			wheel1TPMCounter=2;
			wheel2TPMCounter=2;
			TPM0_C2SC |=  TPM_CnSC_CHIE_MASK + TPM_CnSC_ELSA_MASK; // input capture rising edge
			TPM0_C3SC |=  TPM_CnSC_CHIE_MASK + TPM_CnSC_ELSA_MASK; // input capture rising edge
			TPM0_SC |= TPM_SC_CMOD(1); //Start the TPM0 counter
			break;	
			
		case 2: 
			CountTOF1 = 0;
			CountTOF2 = 0;
			break;	
					
		case 3:
			1;
			/*
			//for ultra sonic, using FTM0 handler
		//	Servo_Movement(1);//servo to the front
			PORTE_PCR31 &= ~PORT_PCR_MUX(3); // PTE31 pin TPM0_CH4- ALT3
			if (ultraConfig!=1) {
				UltraSonicConfig();
				ultraConfig = 1;}
			TPM0_SC = 0; // to ensure that the counter is not running
			TPM0_SC |= TPM_SC_PS(5) + TPM_SC_TOIE_MASK;
			TPM0_MOD = 0xAFBE; // PWM T=60ms
			TPM0_C1SC = 0;// stop PWM -> ultra sonic trigger
			TPM0_C2SC = 0;
			TPM0_C3SC = 0;
			TPM0_C1SC |= TPM_CnSC_MSB_MASK + TPM_CnSC_ELSB_MASK;// PWM 16.7 Hz for ultra Sonic
			TPM0_C2SC |= TPM_CnSC_CHIE_MASK + TPM_CnSC_ELSA_MASK + TPM_CnSC_ELSB_MASK; //input capture rising edge or falling edge
			TPM0_C3SC |= TPM_CnSC_CHIE_MASK + TPM_CnSC_ELSA_MASK + TPM_CnSC_ELSB_MASK ; //input capture rising edge or falling edge
			wheel1TPMCounter=2;
			wheel2TPMCounter=2;
			TPM0_SC |= TPM_SC_CMOD(1);
	*/
	}
}
//-----------------------------------------------------------------
// Motor Movement Function
//-----------------------------------------------------------------
void Motor_Dir_Speed (int Direction, int Speed){
	currentSpeed=Speed;
	GPIOC_PDOR = 0;// stop motors
	if (Direction!=0){// Direction = 1 is forward , Direction = 2 is backward, Direction =0 is stop
		wheel2Duty =  5526; //speed for motor 2
		TPM1_C0V = wheel2Duty;
		wheel1Duty =  5400; //speed for motor 1
		TPM2_C1V = wheel1Duty;
		
		if (Direction == 1){
			GPIOC_PDOR |= PORT_LOC(6);
			int i;
			for (i=8000; i>0; i--);
			GPIOC_PDOR |=PORT_LOC(10);//PTC10 direction forward for motor 2 			
		}
		else if (Direction == 2){
			GPIOC_PDOR |= PORT_LOC(5);
			GPIOC_PDOR |= PORT_LOC(7);//PTC7 direction backward for motor 2
		}
	}
	if(Speed==0){
		wheel1Speed=0;
		wheel2Speed=0;
		TPM1_C0V=0;
		delay=50;
		while(delay>0);
		TPM2_C1V=0;
	}
	else init_TPM0(1);
}
//----------------------//
//the car at start in angle 90'
//------------------------//
void turnToAngle(int angle){
	GPIOC_PDOR=0;
	double deltaAngle;
	double relativeTimeToTurn;
	if (angle < currentAngle){//turn left - motor 2 stop. motor 1 move
		deltaAngle = currentAngle - angle;// how much angle did i need to turn
		GPIOC_PDOR |= PORT_LOC(7) ;
		relativeTimeToTurn = deltaAngle * Turn1AngleTime; //how much time i need to turn
		TPM1_C0V = 5000;//100% speed of turn
	}
	else if(angle > currentAngle){
		deltaAngle = angle - currentAngle;// how much angle did i need to turn
		relativeTimeToTurn = deltaAngle * Turn2AngleTime; //how much time i need to turn
		GPIOC_PDOR |= PORT_LOC(10); //PTC6 direction for motor 1

		TPM1_C0V = 5000;//100% speed of turn
	}
	 double i = (relativeTimeToTurn * 1000);
	while (i > 0){i--;}
	GPIOC_PDOR = 0;
	TPM2_C1V = 0x01;
	TPM1_C0V = 0x01;
	wheel1Speed=0;
	wheel2Speed=0;
	currentAngle = angle;
}
//-----------------------------------------------------------------
//  Function to Print the speed
//-----------------------------------------------------------------
void PrintSpeed(){
	//calculate the speed
	EncoderSensing();
	// then print
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n Motor speed is : \r\n");//logic to print the current motor speed
	int k=3;
	 while(k>=0){
		if(UART0_S1 & UART_S1_TDRE_MASK){ // TX buffer is empty and ready for sending
		  if(k==3){ UART0_D=((int)(wheel1Speed/10)%10)+48;} //X0.0 DIGIT 
		  if(k==2){ UART0_D=(int)(wheel1Speed)%10+48;}//0X.0 DIGIT
		  if(k==1){ UART0_D=46;}// dot
		  if(k==0){ UART0_D=((int)(wheel1Speed*10)%10)+48;} //00.X DIGITONE DIGIT AFTER DOT
		  k--;
		 }
	 }
	UARTprintf(UART0_BASE_PTR,"  [cm per second]  \r\n");
	UARTprintf(UART0_BASE_PTR,"\r\n \r\n");
}
//-----------------------------------------------------------------
// PRESS 1 Function CASES
//-----------------------------------------------------------------
void Motor_Movement(int mode){
	switch(mode){
		// S is pressed - motors speed will be max
		case 83: 
			currentSpeed = 10;
			Motor_Dir_Speed(1,10); // the two motors drive backwards in max speed
			option = 0;
			break;	
		//P	is pressed - motors will stop moving	
		case 80: 
			currentSpeed = 0;
			Motor_Dir_Speed(1,0); // the two motors will stop
			wheel1Delta=0;
			option = 0;
			break;
		//U	is pressed - motors will move in periodic speed that increase
		case 85: 
			currentSpeed=currentSpeed+0.1;
			if (currentSpeed > 10){ currentSpeed = 1;} //return to min speed
			Motor_Dir_Speed(1,currentSpeed);
			option = 0;
			break;
		//D	is pressed - motors will move in periodic that decrease		
		case 68: 
			currentSpeed--;
			if (currentSpeed < 1){ currentSpeed = 10;} //return to max speed
			Motor_Dir_Speed(1,currentSpeed);
			option = 0;
			break;
		//E	- for now on, show the speed of the wheels when the speed changes		
		case 69:
			currentSpeed!=0 ? init_TPM0(1):PrintSpeed();
			//printTheSpeed = 1;
			option = 0;
			break;	
	}
}
//-----------------------------------------------------------------
// Encoder Sensing to calculate the speed of the motors
//-----------------------------------------------------------------
void EncoderSensing(){
	if(wheel1Delta!=0) {wheel1Freq = (750000 / wheel1Delta);} // 0.034 = 408 / 12000 ,seconds to do a full spin in the wheel = 18.84 cm
	else {wheel1Freq=0;}
	wheel1Time = wheel1Freq/408;
	wheel1Speed = 18.84*wheel1Time; // cm per second
	
	if(wheel2Delta!=0) {wheel2Freq = (750000 / wheel2Delta);} // 0.034 = 408 / 12000 ,seconds to do a full spin in the wheel = 18.84 cm
	else {wheel2Freq=0;}
	wheel2Time = wheel2Freq/408;
	wheel2Speed = 18.84*wheel2Time; // cm per second
}
//-----------------------------------------------------------------
// TPM0- ISR = Interrupt Service Routine
//-----------------------------------------------------------------
void FTM0_IRQHandler(){
	if (TPM0_STATUS & 0x100){ // TOF
		TPM0_SC |= TPM_SC_TOF_MASK;
		if (wheel1TPMCounter<2 && wheel1TPMCounter>0)
			CountTOF1++;
		if (wheel2TPMCounter<2 && wheel2TPMCounter>0)
			CountTOF2++;
	}else{
		if (TPM0_STATUS & 0x04 && wheel1TPMCounter>0){ // wheel 1 interrupt
				int currentCNV1 = TPM0_C2V;
				wheel1Delta = currentCNV1 - prevCNV1+CountTOF1*65535;
				prevCNV1 = currentCNV1;
				wheel1TPMCounter--;
				TPM0_C2SC |= TPM_CnSC_CHF_MASK; 
		}
		
		if (TPM0_STATUS & 0x08 && wheel2TPMCounter>0){ // wheel 2 interrupt
				int currentCNV2 = TPM0_C3V;
				wheel2Delta = currentCNV2 - prevCNV2+CountTOF2*65535;
				prevCNV2 = currentCNV2;
				wheel2TPMCounter--;
				TPM0_C3SC |= TPM_CnSC_CHF_MASK;
		}
		
		if (wheel1TPMCounter == 0 && wheel2TPMCounter==0){
				init_TPM0(2);
				EncoderSensing();// PrintSpeed();
			//else if (state == 5) UltraDistance();
		 if (state == 5) PrintDistance();
		}
	}
	TPM0_STATUS |= TPM_STATUS_CH2F_MASK + TPM_STATUS_CH3F_MASK;  
}

void gameOn(){
	EnterArena();
	while(target>0){
		delay=20;
		while(delay>0);
		while(target>0){
		WalkAway();
		}
	}
	DistLeft=100;
	Motor_Dir_Speed(1,8);
	while(DistLeft>0);
	Motor_Dir_Speed(0,0);
	delay=30;
	while(delay>0);
	ExitArena();
	//stopAll();
}
void EnterArena(){//NEED TO DO SAVE THR CAR BEFOR INTARE
	// servo to 90 degree
	DistLeft = 150+distFromStartingPoint; // 1.5m from the starting point
	Motor_Dir_Speed(1,8);//start moving forward
	while(DistLeft > 0);
	Motor_Dir_Speed(0,0);//stop
	delay=10;
	while(delay>0);
	currentY = 1.5;
}
void ExitArena(){//                                         looking for the Exit
	RightExitconfig();//get the servo 1 to 90 
	Motor_Dir_Speed(1,5);
	DistLeft=220;//                                   
	while(DistLeft>0){
		if(sens2<800){//                                   
			DistLeft=0;
			TurnOffADC();	
			ExitRight=1;
		}
	}
	Motor_Dir_Speed(0,0);
	delay=3;
	while(delay>0);
	if(ExitRight==1){
		Motor_Dir_Speed(1,1);
		DistLeft=50;
		while(DistLeft>0);
		Motor_Dir_Speed(0,0);
		delay=5;
		while(delay>0);
		turnToAngle(90);
		delay=5;
		while(delay>0);
		Motor_Dir_Speed(1,5);
		DistLeft=200;//                                   
		while(DistLeft>0);
		Motor_Dir_Speed(0,0);
	}else{
		
		leftExitconfig();
		Motor_Dir_Speed(1,5);
		DistLeft=1000;//                                   
		while(DistLeft>0){
			if(sens1<600){//                                   
				DistLeft=0;
				TurnOffADC();	
				ExitLeft=1;
			}
		}
		Motor_Dir_Speed(0,0);
		delay=5;
		while(delay>0);
		if(ExitLeft==1){
			Motor_Dir_Speed(1,1);
			DistLeft=50;
			while(DistLeft>0);
			Motor_Dir_Speed(0,0);
			delay=5;
			while(delay>0);
			turnToAngle(90);
			delay=5;
			while(delay>0);
			Motor_Dir_Speed(1,5);
			DistLeft=200;
			while(DistLeft>0);
			Motor_Dir_Speed(0,0);
		}
	}
}
void WalkAway(){//                                    Search targets function
	BLUE_LED_ON;
	int OldTarget=target;
	CheckWhereTheServo(90);//the servoes is equal 
	Motor_Dir_Speed(1,10);//                                   
	delay=10;
	while(delay>0);
	Yflag=1;
	while(!(sens1>800||sens2>800));//                                   
	delay=20;
	while(delay>0);
	BLUE_LED_OFF;
	RED_LED_ON;
	Yflag=0;
	Motor_Dir_Speed(0,0);
	delay=20;
	while(delay>0);
	int Objectright=DistanceMeasuring1(sens1);
	int Objectleft =DistanceMeasuring2(sens2);
	if(Objectleft<120){//                                   
		RGB_LED_OFF;
		GREEN_LED_ON;
		GetObjectLeft();
	}
	if(Objectright<120){
		RGB_LED_OFF;
		GREEN_LED_ON;
		RED_LED_ON;
		GetObjectRight();
	}
	if(OldTarget!=target){
		DistLeft=40;//                                 the length of box//
		while(DistLeft>0);
	}
	RGB_LED_OFF;
}
void GetObjectLeft(){//                                   go to the Object in the left side 
	turnToAngle(0);
	Straightconfig();//get the servo to 0 and 180
	delay=20;
	while(delay>0);
	if(sens1>800 || sens2>800){
		DistLeft=fmax(DistanceMeasuring1(sens1),DistanceMeasuring2(sens2));
		int temp=DistLeft;
		Motor_Dir_Speed(1,8);
		while(DistLeft>0);
		Motor_Dir_Speed(0,0);
		delay=20;
		while(delay>0);
		DistLeft=temp;
		Motor_Dir_Speed(2,8);
		while(DistLeft>0);
		target--;
	}
	Motor_Dir_Speed(0,0);
	delay=20;
	while(delay>0);
	turnToAngle(90);
	CheckWhereTheServo(90);//get the servo to 90
	RGB_LED_OFF;
	delay=20;
	while(delay>0);
}
void GetObjectRight(){//                                 go to the Object in the right side 
	turnToAngle(180);
	Straightconfig();//get the servo to 0 and 180
	delay=20;
	while(delay>0);
	if(sens1>800||sens2>800){
		DistLeft=fmax(DistanceMeasuring1(sens1),DistanceMeasuring2(sens2));
		int temp=DistLeft;
		Motor_Dir_Speed(1,8);
		while(DistLeft>0);
		Motor_Dir_Speed(0,0);
		delay=20;
		while(delay>0);
		DistLeft=temp;
		Motor_Dir_Speed(2,8);
		while(DistLeft>0);
		target--;
	}
	Motor_Dir_Speed(0,0);
	delay=20;
	while(delay>0);
	turnToAngle(90);
	CheckWhereTheServo(90);//get the servo to 90
	RGB_LED_OFF;
	delay=20;
	while(delay>0);
}
void stopAll(){
	stop();
}
