/*
 * DistSens.h
 *
 *  Created on: Jun 3, 2017
 *      Author: shetritr
 */

#ifndef DISTSENS_H_
#define DISTSENS_H_
#include "TFC.h"
/* Prototypes */
void DistSensConfig();
void DistanceMeasure(int i);
int indexDistance1 (int DisSamp1);
int indexDistance2 (int DisSamp2);
double DistanceMeasuring1 (int DisSamp1);
double DistanceMeasuring2 (int DisSamp2);
void DistanceMeasureIR2 (int i);
#endif /* DISTSENS_H_ */
