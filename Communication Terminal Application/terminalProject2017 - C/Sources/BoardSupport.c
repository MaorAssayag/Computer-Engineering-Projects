#include "TFC.h"
#include "mcg.h"

#define MUDULO_REGISTER  0x2EE0

// set I/O for switches and LEDs
void InitGPIO()
{
	//enable Clocks to all ports - page 206, enable clock to Ports
	SIM_SCGC5 |= SIM_SCGC5_PORTA_MASK | SIM_SCGC5_PORTB_MASK | SIM_SCGC5_PORTC_MASK | SIM_SCGC5_PORTD_MASK | SIM_SCGC5_PORTE_MASK;

	//GPIO Configuration - LEDs - Output
	PORTD_PCR1 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK;  //Blue
	GPIOD_PDDR |= BLUE_LED_LOC; //Setup as output pin	
	PORTB_PCR18 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; //Red  
	PORTB_PCR19 = PORT_PCR_MUX(1) | PORT_PCR_DSE_MASK; //Green
	GPIOB_PDDR |= RED_LED_LOC + GREEN_LED_LOC; //Setup as output pins
	
	PORTD_PCR7 |= PORT_PCR_PS_MASK | PORT_PCR_PE_MASK | PORT_PCR_PFE_MASK | PORT_PCR_IRQC(0x0a);
//	enable_irq(INT_PORTD-16); // Enable Interrupts 
//	set_irq_priority (INT_PORTD-16,0);  // Interrupt priority = 0 = max
	RGB_LED_OFF;
}
//-----------------------------------------------------------------
// DipSwitch data reading
//-----------------------------------------------------------------
uint8_t TFC_GetDIP_Switch()
{
	uint8_t DIP_Val=0;
	
	DIP_Val = (GPIOC_PDIR>>4) & 0xF;

	return DIP_Val;
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
		//Enable the Clock to the TPM0 and PIT Modules
		//See Page 207 of f the KL25 Sub-Family Reference Manual
		SIM_SCGC6 |= SIM_SCGC6_TPM0_MASK + SIM_SCGC6_TPM2_MASK;
	    // TPM_clock = 24MHz , PIT_clock = 48MHz
	    
}
//-----------------------------------------------------------------
// PIT - Initialisation
//-----------------------------------------------------------------
void InitPIT(){
	SIM_SCGC6 |= SIM_SCGC6_PIT_MASK; //Enable the Clock to the PIT Modules
	// Timer 0
	PIT_LDVAL0 = 0x00003FFF;
	PIT_TCTRL0 =  PIT_TCTRL_TIE_MASK; //enable PIT0 interrupt
	PIT_MCR = 0;
	enable_irq(INT_PIT-16); //  //Enable PIT IRQ on the NVIC
	set_irq_priority(INT_PIT-16,0);  // Interrupt priority = 0 = max
}
void PIT_IRQHandler(void)
{	
	// Clear interrupt
	if(funarry[i]<=7&&delstap==0){
		switch(funarry[i]){
				case 1:
					RGB_LED_OFF;
					RED_LED_ON;
				break;
				case 3:
					RGB_LED_OFF;
					BLUE_LED_ON;
				break;
				case 4:
					RGB_LED_OFF;
					RED_LED_ON;
					GREEN_LED_ON;
				break;
				case 7:
					RGB_LED_OFF;
					GREEN_LED_ON;
				break;
				case 6:
					RGB_LED_OFF;
					RED_LED_ON;
					BLUE_LED_ON;
				break;
				case 2:
				RED_LED_ON;
				GREEN_LED_ON;
				BLUE_LED_ON;
				break;
				case 5:
					RGB_LED_OFF;
					BLUE_LED_ON;
					GREEN_LED_ON;
				break;
		}
		i++;
		i=i%(count+1);
	}else{
		if(delstap==0){
			delstap=1;
			del=funarry[i];
		}else{
			del--;
			if(del==0){
				delstap=0;
				i++;
				i=i%(count+1);
			}
		}
	}
	PIT_TFLG0 = PIT_TFLG_TIF_MASK;
	Delaymile=0;
	
}
void delay(int milisec){
	PIT_LDVAL0 = 0x00002800*milisec;//delay in milisec
	PIT_TCTRL0 |= PIT_TCTRL_TEN_MASK;//enable PIT0
	Delaymile=1;
	while(Delaymile!=0);
}
