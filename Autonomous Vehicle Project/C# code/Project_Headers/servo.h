/*
 * servo.h
 *
 *  Created on: May 29, 2017
 *      Author: maoryak
 */

#ifndef SERVO_H_
#define SERVO_H_
#include "TFC.h"

void leftExitconfig();
void ServoConfig();
void Servo1SetPos(int Servo1Position);
void Servo2SetPos(int Servo2Position);
void Servo_Movement(int mode);
void scan();
void RightExitconfig();
void Straightconfig();
void CheckWhereTheServo(int position);
#endif /* SERVO_H_ */
