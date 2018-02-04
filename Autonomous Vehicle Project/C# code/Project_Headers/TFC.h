/*
 * TFC.h
 *
 *  
 *    
 */

#ifndef TFC_H_
#define TFC_H_
#define MAX_SPEED  0x0752
#define Precent_Speed 0x0752 	// each 10 precent of 0x493E is 10% of the speed
#define MUDULO_REGISTER  0x493E //18,750

//               main function                //
void turnToAngle (int angle);
void ExitArena();
void updateMap(int type);
void updateMotorSpeed(int level);
void hitTheTargetFrom20();
void EncoderSensing();
void PrintSpeed();
void Motor_Dir_Speed (int Direction, int Speed);
void FTM0_IRQHandler();
void WalkAway();
void GetObjectLeft();
void GetObjectRight();
void stopAll();
void EnterArena();
void gameOn();

//---//



//int MoveServo;//for pit                 /////////CHANGE/////////
//int backServo;


//
//----//
int distFromStartingPoint; // hanan parameter



int MoveServo;//for pit                 /////////CHANGE/////////
int backServo;



int RoundOfPit2;//for balance
int currsens;
int sens1;
int sens2;
int counter;
int dir1;
int dir2;
int Servo1CurrPosition;
int Servo2CurrPosition;
int printDistisPressed ;
int batteryLevel;
int batteryVOLT;
int scanum;
int RightScan;
int LeftScan;

double currentDistance1;
double currentDistance2;

double currentDistanceUltra1;
double currentDistanceUltra2;


//----//
int state; // press 1,2,3,4,5 or 6 .
int option; // ASCI for S,P,U,D or E.

int currentSpeed; // from 0 to 10 evaluate a speed level.
int firstMove;

int calcSpeed ; //0 : dont print the speed , 1: every change of speed print the speed on the screen.
int CountTOF1;
int CountTOF2;


int prevCNV1;
float wheel1Speed;
float wheel1Time; // seconds to do full spin = 18.84 cm
int wheel1Delta; // 1/408 of a spin is equal the delta with TPM0. save in this parmater.
int wheel1TPMCounter; // the TPM0 calculate 2 times the speed to the wheel
float wheel1Freq;//freq form wheel1delta

int prevCNV2 ;
float wheel2Speed;
float wheel2Time; // seconds to do full spin = 18.84 cm
int wheel2Delta; // 1/408 of a spin is equal the delta with TPM0. save in this parmater.
int wheel2TPMCounter; // the TPM0 calculate 2 times the speed to the wheel
float wheel2Freq;//freq form wheel1delta

int ultraConfig;
int encoderConfig;
int phase;
int currentX;
int currentY;
float map[2700]; // 10x10 cm^2 per index
float targets[4];
float tempTargetRight[2]; // save the x and y indexes of the current right scan 
float tempTargetLeft[2]; // save the x and y indexes of the current left scan 
int nextTargetX1;
int nextTargetX2;
int nextTargetY1;
int nextTargetY2;


int RoundOfPit;//count from 0 to 1 for double entry to the pit 
int UltraTOF;
int wheel1Duty; // how much we insert to wheel 1 duty
int wheel2Duty;// how much we insert to wheel 2 duty
int hitMode; // did the car hit the target?
int currentAngle;
int ScanPhase;
int delay;




//phase 0
int phase0Starting;
double DistLeft;
//

//                 game                //
int target; //the number of target
int Yflag; //move on y axis
//exit//
int Exit;//chose if left or right ,in the ADC
int ExitRight;
int ExitLeft;



#include <stdint.h>
#include <stdio.h>
#include <stdarg.h>
#include <string.h>
#include <math.h>
#include "Derivative.h"
#include "BoardSupport.h"
#include "arm_cm0.h"
#include "UART.h"
#include "motors.h"
#include "servo.h"
#include "adc.h"
#include "DistSens.h"
#include "pit.h"
#include "UltraSonic.h"
#include "battery.h"


int temp [180];//temp
int i;
int j;
int MultiDrop;//how much we move the servo ?


#endif /* TFC_H_ */
