#include "adc.h"
/*	adc_init()
 * Calibrates and initializes adc to perform single conversions and generate
 * */
void adc_init(void)
{
	// Enable clocks
	SIM_SCGC6 |= SIM_SCGC6_ADC0_MASK  ;	// ADC0  clock
	// Configure ADC
	ADC0_CFG1 = 0; // Reset register
	ADC0_CFG1 |= (ADC_CFG1_MODE(1)  |  	// 12 bits mode
				  ADC_CFG1_ADICLK(0)|	// Input Bus Clock (20-25 MHz out of reset (FEI mode))
				  ADC_CFG1_ADIV(1)) ;	// Clock divide by 2 (10-12.5 MHz)
	
	ADC0_SC2 |=  ADC_SC2_ADTRG_MASK;// Hardware trigger
	
	ADC0_SC3 |= ADC_SC3_AVGE_MASK |		// Enable HW average
				ADC_SC3_AVGS(2)   |		// Set HW average of 32 samples
				ADC_SC3_CAL_MASK;		// Start calibration process
	ADC0_CFG2 |= ADC_CFG2_MUXSEL_MASK;//The msb
	ADC0_SC1B |= ADC_SC1_ADCH(31) + ADC_SC1_AIEN_MASK; // Disable module
	printDistisPressed=0;
	enable_irq(INT_ADC0-16); // enable PIT IRQ on the NVIC
	set_irq_priority(INT_ADC0-16,0);  // Interrupt priority = 0 = max
}
void ADC0_IRQHandler(void){
	if((counter==1||Exit==2)&&Exit!=1){
		sens1=ADC0_RB;
		//ADC0_CV1=sens1-50;
		//ADC0_CV2=sens1+50;
		//RightScan= DistanceMeasuring1(sens1);	
		//UpgradeRight();//to do
	}else if ((counter==0||Exit==1)&&Exit!=2){
		sens2=ADC0_RB;
		/*if(Exit==1){
			TurnOffADC();
			DistLeft=-1;
			ExitRight=1;
		}*/
		//ADC0_CV1=sens2-50;
		//ADC0_CV2=sens2+50;
		//LeftScan= DistanceMeasuring1(sens2);
		//UpgradeLeft();//to do
	}
	/*else{
		batteryVOLT=ADC0_RB;
		ADC0_CV1=batteryVOLT-10;
		ADC0_CV2=batteryVOLT+10;
	}*/
}

// function to update the map due to right scan
// nextIndexForTargetRight = 0, tempTargetRight = 0, 
void UpgradeRight(){ 
	int x;//index
	int y;//index
	if (RightScan < 150){
		x = currentX + (int) (RightScan * sin(Servo1CurrPosition) * 0.1); // x index of the target
		y = currentY + (int) (RightScan * cos(Servo1CurrPosition) * 0.1);  // y index of the target
		if (x <= 44 && y <= 44 && map[x + y * 44] == 0) { // the target is legit
			for (i = currentX; i < x; i++)       if (map[i + currentY * 44]==0) {map[i + currentY * 44] = 1;}
			
			if (Servo1CurrPosition < 90){
				for (i = currentY ; i < y; i++)  if (map[currentX + i * 44]==0) {map[currentX + i * 44] = 1;}}
			if (Servo1CurrPosition >= 90){
				for (i = currentY ; i < y; i++)  if (map[currentX + i * 44]==0) {map[currentX + i * 44] = 1;}}
			
			if (tempTargetRight[0] == 0){
				tempTargetRight[0] = x;
				tempTargetRight[1] = y;
			}
			map[x + y * 44] = 2; // its a target
		}
	}
}

// function to update the map due to left scan
// nextIndexForTargetLeft = 0, tempTargetLeft = 0, 
void UpgradeLeft(){
	int x;//index
	int y;//index
	if (LeftScan < 150){
		x = currentX - (int) (RightScan * sin(180 - Servo1CurrPosition) * 0.1); // x index of the target
		y = currentY + (int) (RightScan * cos(180 - Servo1CurrPosition) * 0.1);  // y index of the target
		if (x <= 44 && y <= 44 && map[x + y * 44] == 0) { // the target is legit
			for (i = x + 1; i < currentX; i++)       if (map[i + currentY * 44]==0) {map[i + currentY * 44] = 1;}
			
			if (Servo1CurrPosition > 90){
				for (i = currentY ; i < y; i++)  if (map[currentX + i * 44]==0) {map[currentX + i * 44] = 1;}}
			if (Servo1CurrPosition <= 90){
				for (i = currentY ; i < y; i++)  if (map[currentX + i * 44]==0) {map[currentX + i * 44] = 1;}}
				
			if (tempTargetLeft[0] == 0){
				tempTargetLeft[0] = x;
				tempTargetLeft[1] = y;
			}
			map[x + y * 44] = 2; // its a target
		}
	}
}

void ExitADCright(){                                   //temp do delet
	ADC0_SC2 |= ADC_SC2_ACFE_MASK;//compare mode
	ADC0_CV1=600;
}
void TurnOffADC(){
	PIT_TCTRL0 =0; //Disable timer
}
void TurnOnADC(){
	PIT_TCTRL0 |= PIT_TCTRL_TEN_MASK; // Enable timer
}
