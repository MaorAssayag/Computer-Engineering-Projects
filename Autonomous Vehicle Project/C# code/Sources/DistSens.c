/*
 * DistSens.c
 *
 *  Created on: Jun 3, 2017
 *      Author: shetritr
 */
#include "DistSens.h"
#include "TFC.h"
#include "mcg.h"

float Distance1[130]={		2735,2674,2617,2560,2503,2446,2393,2344,2295,2246,2197,2130,2067,2004,1941,1878,1837,1800,1763,1726,1689,1654,1621,1588,1555,1522,1499,1478,1457,1436,1415,1402,1390,1378,1366,1354,1328,1302,1276,1250,1224,1204,1187,1170,1153,1136,1127,1121,1115,1109,1103,1097,1095,1093,1091,1089,1050,1025,1020,1015,1010,1005,1004,1003,1002,1001,997,993,989,985,981,956,933,910,887,864,841,818,795,772,749,759,767,775,783,791,790,785,780,775,770,765,760,755,750,745,740,735,730,725,700,612,512,412,312,212,237,262,287,313,310	}; // IR 1
float Distance2[130]={		2735,2674,2617,2560,2503,2446,2393,2344,2295,2246,2197,2130,2067,2004,1941,1878,1837,1800,1763,1726,1689,1654,1621,1588,1555,1522,1499,1478,1457,1436,1415,1402,1390,1378,1366,1354,1328,1302,1276,1250,1224,1204,1187,1170,1153,1136,1127,1121,1115,1109,1103,1097,1095,1093,1091,1089,1050,1025,1020,1015,1010,1005,1004,1003,1002,1001,997,993,989,985,981,956,933,910,887,864,841,818,795,772,749,759,767,775,783,791,790,785,780,775,770,765,760,755,750,745,740,735,730,725,700,612,512,412,312,212,237,262,287,313,310	}; //IR 2
int startMeasure = 0;
int index = 0;

void DistSensConfig(){
	SIM_SOPT7 |= SIM_SOPT7_ADC0ALTTRGEN_MASK | SIM_SOPT7_ADC0PRETRGSEL_MASK | SIM_SOPT7_ADC0TRGSEL(4);//set up the adc-b and connect to pit0
}

void DistSensStop(){
	//PIT_TCTRL0 &= ~PIT_TCTRL_TEN_MASK; // Disable timer 
}

double DistanceMeasuring1 (int DisSamp1){
	int index1 = indexDistance1(DisSamp1);
	index1=index1+20;
	return index1;
}

double DistanceMeasuring2 (int DisSamp2){
	int index2 = indexDistance2(DisSamp2);
	index2=index2+20;
	return index2;
}

int indexDistance1 (int DisSamp1){
	int index1 = 0;
	while (index1<13&&Distance1[index1*10]>DisSamp1){
		index1++;
	}
	index1=index1*10;
	if(index1==130){index1--;}
	while(index1>0&&Distance1[index1]<DisSamp1){
		index1--;
	}
	return index1;
}
int indexDistance2 (int DisSamp2){
	int index2 = 0;
	while (index2<13&&Distance2[index2*10]>DisSamp2){
		index2++;
	}
	index2=index2*10;
	if(index2==130){index2--;}
	while(index2>0&&Distance2[index2]<DisSamp2){
		index2--;
	}
	return index2;
}

//-----------------------------------------------------------------
//  PORTD - ISR = Interrupt Service Routine
//-----------------------------------------------------------------
void PORTD_IRQHandler(void){
	volatile unsigned int i;
	while(!(GPIOD_PDIR & (SW_POS)));// wait of release the button
	// check that the interrupt was for switch
	if (PORTD_ISFR & SW_POS){
	  if(index!=13){	
		  DistanceMeasure(index);
		  index +=1;
	  }
	  else{
		  startMeasure=0;
		  index = 0;
	  }
	}
	for(i=100000 ; i>0 ; i--); //delay, button debounce
	PORTD_ISFR |= 0x0000004;  // clear interrupt flag bit of PTD7 
}

void DistanceForArray (){
	if(index!=14){	
			DistanceMeasure(index);
			DistanceMeasureIR2(index);
		 index +=1;
	}
	else {
		startMeasure=0;
		DistSensStop();
		index = 0;
	}
}

void DistanceMeasure (int i){
	int k=0;
	i = i*10;
	int temp = sens1;
	if(i==0){
		Distance1[i]=temp;
	}else{
	  Distance1[i]=temp;
	  temp = temp - Distance1[i-10];
	  while(k<9){
		  k++;
		 Distance1[i-k] = Distance1[i+1-k]-(temp/10);
	  }
	}
}

void DistanceMeasureIR2 (int i){
	int k=0;
	i = i*10;
	int temp = sens2;
	if(i==0){
		Distance2[i]=temp;
	}else{
	  Distance2[i]=temp;
	  temp = temp - Distance2[i-10];
	  while(k<9){
		  k++;
		 Distance2[i-k] = Distance2[i+1-k]-(temp/10);
	  }
	}
}

//-----------------------------------------------------------------
// PRESS 3,4 Function CASES
//-----------------------------------------------------------------
void Distance_Sensor(int mode){
	switch(mode){
		// start printing the distance
		case 1: 
			PrintDistance();
			//Servo_Movement(1); // return to the front
			break;	
	}
}
