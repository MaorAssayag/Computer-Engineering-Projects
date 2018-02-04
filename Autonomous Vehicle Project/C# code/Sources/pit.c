#include "pit.h"
#include "BoardSupport.h"
#include "TFC.h"
/* Initializes the PIT module to produce an interrupt every second
 * 
 * */
void pit_init(void)
{		
	// Enable PIT clock
	SIM_SCGC6 |= SIM_SCGC6_PIT_MASK;
	// Turn on PIT
	PIT_MCR = 0;
	// Configure PIT0 to produce an interrupt every 4ms
	PIT_LDVAL0 = 0x0000FFFF;//Trigger to adc
	PIT_LDVAL1 = 0x000DFD40;//check sensors
	PIT_TCTRL1 |= PIT_TCTRL_TIE_MASK+ PIT_TCTRL_TEN_MASK;//Enable interrupt
	PIT_TCTRL0 |= PIT_TCTRL_TEN_MASK; // Enable timer
    currsens=6;
    MultiDrop=2;
    counter=0;//temp
    enable_irq(INT_PIT-16); // disable PIT IRQ on the NVIC
    set_irq_priority(INT_PIT-16,1);  // Interrupt priority = 0 = max
  // ADC0_SC1B = ADC_SC1_ADCH(currsens) + ADC_SC1_AIEN_MASK;//Connecting to the current sensor1 
}
void PIT_IRQHandler(void)
{	
	//         IR sensor      ///////
	
	if(MoveServo==0){
		if(counter==0){
			ADC0_SC1B = ADC_SC1_ADCH(currsens) + ADC_SC1_AIEN_MASK;//Connecting to the current sensor1  
			//
			//temp[i]=sens1;
			//i++;	
			
		}else if (counter==1){
			ADC0_SC1B = ADC_SC1_ADCH(currsens+1) + ADC_SC1_AIEN_MASK;//Connecting to the current sensor2 
			//
			//temp[j]=sens2;
			//j++;
		}
	}
	counter=(counter+1)%2;//chose the IR 
	RoundOfPit=(RoundOfPit+1)%4;//move the servo  
	RoundOfPit2=(RoundOfPit2+1)%2;// EncoderChecker or init_TPM0
    
	//            move servo                 //
	if(MoveServo==1){
	if(scanum>0 && RoundOfPit==0){
		Servo_Movement(2);
		scanum--;//number of the servo left to go to the side
	}
	if(scanum==0){
	    ScanPhase=0;
	    MoveServo=0;//if the servo is on moving don't get IR measurements
	    Exit=0;//chose if left or right servo
		}
    }
    
    //              Encoder              //
	if(currentSpeed>0){
		if(RoundOfPit2==0)
			EncoderChecker();
			
		else
			init_TPM0(1);
	}
	
	//          distance over          //
	if ( DistLeft > 0){
		DistLeft = DistLeft - (double)fmax(wheel1Speed,wheel2Speed)*0.03988; // current speed * pit timer per entry
	}
	
	if (Yflag==1){
		currentY = currentY + (double)fmax(wheel1Speed,wheel2Speed)*0.03988;
	}
	
	//                     delay                  //
	if(delay>0)
		delay--;
	// Clear interrupt
	PIT_TFLG1 = PIT_TFLG_TIF_MASK;
}
