#include "TFC.h"
#include "mcg.h"

#define MUDULO_REGISTER  0x493E //18,750
// set I/O for switches and LEDs
void InitGPIO()
{
	//SIM_SCGC6 |=  SIM_SCGC6_DAC0_MASK;
	//enable Clocks to all ports - page 206, enable clock to Ports
	SIM_SCGC5 |= SIM_SCGC5_PORTA_MASK | SIM_SCGC5_PORTB_MASK | SIM_SCGC5_PORTC_MASK | SIM_SCGC5_PORTD_MASK | SIM_SCGC5_PORTE_MASK;
	//DAC0_C0 |= DAC_C0_DACEN_MASK + DAC_C0_DACRFS_MASK+DAC_C0_LPEN_MASK; //enable
	
	//GPIO Configuration - LEDs - Output
		PORTD_PCR1 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK;  //Blue
		GPIOD_PDDR |= BLUE_LED_LOC; //Setup as output pin	
		PORTB_PCR18 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; //Red  
		PORTB_PCR19 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; //Green
		GPIOB_PDDR |= RED_LED_LOC + GREEN_LED_LOC; //Setup as output pins
		RGB_LED_OFF;
	
}
//-----------------------------------------------------------------
// TPMx - Initialization
//-----------------------------------------------------------------
void InitTPM(char x){  // x={0,1,2}
	switch(x){
	case 0: 
		TPM0_SC = 0; // to ensure that the counter is not running
		TPM0_SC |= TPM_SC_PS(5) + TPM_SC_TOIE_MASK; //Prescaler =32, up-mode, counter-disable
		TPM0_MOD = MUDULO_REGISTER; // PWM frequency of 40Hz = 24MHz/(32x18,750)
		TPM0_C2SC |= TPM_CnSC_ELSA_MASK ; // PTC3
		TPM0_C3SC |= TPM_CnSC_ELSA_MASK ; // PTC4
		TPM0_CONF = TPM_CONF_DBGMODE_MASK;
		
		TPM0_SC |= TPM_SC_CMOD(1); //start the TPM0 PWM counter
		Servo2CurrPosition=180;
		enable_irq(INT_TPM0-16);
		set_irq_priority(INT_TPM0-16,2);
		break;

	case 1://Motor2 TPM1_CH0 PTE20 pin ALT3
		TPM1_SC = 0; // to ensure that the counter is not running
		TPM1_SC |= TPM_SC_PS(5); //Prescaler =32, up-mode, counter-disable
		TPM1_MOD = MUDULO_REGISTER; // PWM frequency of 40Hz = 24MHz/(32x18,750) 
		TPM1_C0SC |= TPM_CnSC_MSB_MASK + TPM_CnSC_ELSB_MASK;
		TPM1_C0V = 0;// 0 speed
		TPM1_CONF = TPM_CONF_DBGMODE_MASK;
		
		Servo1CurrPosition=0;
		TPM1_SC |= TPM_SC_CMOD(1); //start the TPM1 PWM counter 
		break;
		
	case 2: //Motor1 TPM2_CH1 PTE23 pin ALT3
		TPM2_SC = 0; // to ensure that the counter is not running
		TPM2_SC |= TPM_SC_PS(5); //Prescaler =32, up-mode, counter-disable
		TPM2_MOD = MUDULO_REGISTER; // PWM frequency of 40Hz = 24MHz/(32x18,750) 
		TPM2_C1SC |= TPM_CnSC_MSB_MASK + TPM_CnSC_ELSB_MASK;
		TPM2_C1V = 0;//speed
		TPM2_CONF = TPM_CONF_DBGMODE_MASK;
		TPM2_SC |= TPM_SC_CMOD(1); //start the TPM2 PWM counter 
		break;
	}
}
//-----------------------------------------------------------------
// TPMx - Clock Setup
//-----------------------------------------------------------------
void ClockSetup(){
	    pll_init(8000000, LOW_POWER, CRYSTAL,4,24,MCGOUT); //Core Clock is now at 48MHz using the 8MHZ Crystal
	    //Clock Setup for the TPM requires a couple steps.
	    //1st,  set the clock mux
	    //See Page 124 of f the KL25 Sub-Family Reference Manual
	    SIM_SOPT2 |= SIM_SOPT2_PLLFLLSEL_MASK;// We Want MCGPLLCLK/2=24MHz (See Page 196 of the KL25 Sub-Family Reference Manual
	    SIM_SOPT2 &= ~(SIM_SOPT2_TPMSRC_MASK);
	    SIM_SOPT2 |= SIM_SOPT2_TPMSRC(1); //We want the MCGPLLCLK/2 (See Page 196 of the KL25 Sub-Family Reference Manual
		//Enable the Clock to the TPM0,TPM1,TPM2 and PIT Modules
		//See Page 207 of f the KL25 Sub-Family Reference Manual
		SIM_SCGC6 |= SIM_SCGC6_TPM0_MASK +SIM_SCGC6_TPM1_MASK + SIM_SCGC6_TPM2_MASK;
	    // TPM_clock = 24MHz , PIT_clock = 48MHz
}
