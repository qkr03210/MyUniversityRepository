/* 두 정수의 최소공배수
학번: 20130493 작성자:박상준
작성일:2013.6.5
연락처 : 010-9774-5263 */
#include "ioHandler.h"
#include "LcmFinder.h"

const int FALSE = 0;
const int TRUE = 1;
const int MAX_INT = 100000;
const int MIN_INT = 1;

int main( void )
{
	ioHandler ioh;
	LcmFinder lcm;
	int input1 , input2;		// 입력받을 값 2개
	//Factor input1Factor[100], input2Factor[100];	//입력값을 소인수분해한것을 factor과 exponent에 넣기위한 구조체 배열

	while( 1 )
	{
		int result;		// int결과값 초기화

		cout << "2개의 양의정수 입력" << endl;
		input1= ioh.getInteger( MIN_INT , MAX_INT ); 
		input2= ioh.getInteger( MIN_INT , MAX_INT );
		if( input1 == EXIT && input2 == EXIT )return 0;		                 // 입력값 둘 다 -999입력시 종료
		if( input1*input2 <= 0 )                                             //한개만 -999일경우 다시 입력
{ 
			cout << "입력값에 -999가 포함되어있습니다."<<endl<<endl; 
			continue;
		}
		if( input1 == 1 )
		{ 
			cout << input2 << endl;        // 첫번째 입력값이 1일때 결과값을 두번째입력값으로 도출
			continue;
		}		     
		else if( input2 == 1 )
		{
			cout << input1 << endl;        // 두번째 입력값이 1일때 결과값을 첫번째입력값으로 도출
			continue;
		}	    
		result = lcm.createLcm( input1, input2 );		                 // 최소공배수만드는 함수

		ioh.putString( "결과값->" , result );
	}
}