
//#include "derivative.h" /* include peripheral declarations */
# include "TFC.h"
int main(void){
	//timer
	ClockSetup();
	InitPIT();
	//led
	InitGPIO();
	//uart
	InitUARTs();
	//data structures
	initarray();
	while(1){
		if(f>0){
			gameon();
			}
		}
	return 0;
}
