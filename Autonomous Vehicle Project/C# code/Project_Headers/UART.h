#ifndef UART_H_
#define UART_H_
#include "TFC.h"
void Uart0_Br_Sbr(int sysclk, int baud);
void InitUARTs();
void UART0_IRQHandler();
char uart_getchar (UART_MemMapPtr channel);
void uart_putchar (UART_MemMapPtr channel, char ch);
void UARTprintf(UART_MemMapPtr channel,char* str);
void UART0_IRQHandler();
void printMenu();
#endif /* TFC_UART_H_ */
