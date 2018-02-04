# include "TFC.h"
void addFile(){
	i=0;
	PIT_TCTRL0 &= ~PIT_TCTRL_TEN_MASK;//enable PIT0
	char sizearr[4];
	int j;
	for(j=0;j<4;j++){
			sizearr[j]=out();
	}
	int* size=&sizearr;
	char name [40];
	char *filenametemp=malloc(41);
	filename[indexfilename]=filenametemp;//array of name
	char a=out();
	while(a!='\n'){
		*filenametemp=a;
		filenametemp++;
		a=out();
	}
	*filenametemp='\0';
	indexfilename++;
	char *filerem=malloc(*size+1);
	fileob[indexfileob]=filerem;//array of pointers to the memo
	char b;
	b=out();
	while(b!='>'){
		*filerem=b;
		filerem++;
		if(b=='s'){
			color=1;
		}
		if(b=='d'){
			if(game[(count+1)%400]=='e')
				del=1;
		}
		if(color==1)
			if(b=='w'||b=='r'||b=='b'||b=='y'||b=='a'||b=='p'||b=='g')
				Runfilechar(b);	
		if(b>='0'&& b<='9')
			Rundel(b);
		b=out();
		}
	*filerem=b;
    numOfFile++;
	i=0;
	delstap=0;
	PIT_TCTRL0 |= PIT_TCTRL_TEN_MASK;//enable PIT0
	}	
void sendFile(){
			char name[40];
			char b=out();
			int index=0;
			while(b!='>'){
				name[index]=b;
				b=out();
				index++;
			}
			name[index]='\0';
			int indextemp=search(name);
			char* temp=fileob[indextemp];
			while(*temp!='>'){
				inT(*temp);
				temp++;
			}
			inT(0x1A);
			UART0_C2 |=  UART_C2_TIE_MASK;  //enable transmit interrupt for start sending
		}
int search(char* name){
			int temp=0;
			while(temp<numOfFile){
				if(strcmp(filename[temp],name)==0){
					return temp;
				}
				temp++;
			}
			return;	
	}
void filelist(){
	 int countemp=0;
	 if(numOfFile==0){
		 inT(' ');
		 inT('\n');
	 }
	 else while(countemp<numOfFile){
		 inStringT(filename[countemp]);
		 countemp++;
		 inT(0x1A);
		 inT('\n');
	 }
	 inT('>');
	 inT('\n');
	
	 UART0_C2 |=  UART_C2_TIE_MASK;  //enable transmit interrupt for start sending
	 
}

