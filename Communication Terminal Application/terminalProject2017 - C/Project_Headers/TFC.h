/*
 * TFC.h
 *
 *  Created on: Apr 13, 2012
 *      Author: emh203
 */

#ifndef TFC_H_
#define TFC_H_

#include <time.h>
#include <stdio.h>
#include <stdarg.h>
#include <string.h>
#include <stdlib.h>
#include "Derivative.h"
#include "BoardSupport.h"
#include "arm_cm0.h"
#include "UART.h"
#include "GAMEON.h"
#include "ARRAY.h"
//void ChangePara(int ChangeArr[],int newbaudRate);
void UART0_IRQHandler();
void Ack();
void delay(int milliseconds);
void sendFile();
void Runfilechar(char a);
void Rundel(char a);
int f;
int paraUpdate;
int Delay;
int Delaymile;
int funarry [40];
char file[400];
int i;
int currantf;
int currarry;
int currarryf;
int count;
int color;
int del;
int delstap;
char Delaysum[4];
int delarry;
char game [400];
char* filename[10];
char* fileob[10];
int indexfilename;
int indexfileob;
int numOfFile;
#endif /* TFC_H_ */
