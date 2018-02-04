/*
 * array.c
 *
 *  Created on: Aug 08, 2017
 *      Author: refael
 */

#include "ARRAY.h"

void initarray(){
	int i;
	for (i = 0; i < 400; i++) {
		game[i]='&';
		file[i]='&';
	}
}
char out(){
	char a = game[currarry];
	game[currarry]='&';
	currarry=(currarry+1)%400;
	return a;
}
void in(char a){
	game[currnt]=a;
	currnt=(currnt+1)%400;
}
char outT(){
	char a = file[currarryf];
	file[currarryf]='&';
	currarryf=(currarryf+1)%400;
	return a;
}
void inT(char a){
	file[currantf]=a;
	currantf=(currantf+1)%400;
}
void inStringT(char* str){
	char* temp=str;
	while(*temp!='\n'&&*temp!='\0'){
		inT(*temp);
		temp++;
	}
	inT(*temp);
}
