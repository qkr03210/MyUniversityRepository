#include "ioHandler.h"


ioHandler::ioHandler(void)
{
}


ioHandler::~ioHandler(void)
{
}
 
int ioHandler::getInteger( int lower , int upper )                           // 정수를 입력받기위한함수
{
	int value;                                                               //입력받은수를 저장하기위해
	while( 1 ) {
		cin >> value;
		if( (value== EXIT) || (value >= lower && value < upper) )
			return value;

		cout << "Out of valid range!!!";
		cout << endl << endl;
	}
}

void ioHandler::putString( string msg , int s )		// 결과값 출력 함수
{
	cout << msg;
	cout << s << endl << endl;
}