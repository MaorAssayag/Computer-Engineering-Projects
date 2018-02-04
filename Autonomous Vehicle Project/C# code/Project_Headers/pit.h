
#ifndef PIT_H_
#define PIT_H_
#include "TFC.h"


#define ADC_CHANNEL 0 // Channel 0 (PTE20)

void pit_init(void);
void PIT_IRQHandler(void);


#endif /* PIT_H_ */
