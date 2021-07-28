#include "LcmFinder.h"
#include "Factorizer.h"


LcmFinder::LcmFinder(void)
{
}


LcmFinder::~LcmFinder(void)
{
}

int LcmFinder::insertFactorInStruct(int arr[], int size , Factor factor[])		// 소인수분해한 배열을 받아서 구조체배열로 옮김 //소인수분해 배열,배열의 크기,구조체
{
	int structSize = 0;		//구조체배열의 크기
	int i = 0;		        // factor을 구하기 위한 변수
	int j = 0;		        // exponent를 구하기 위한 변수

	while( 1 )
	{
		if( arr[i] == arr[j] )		// 소인수분해 한 후 해당 배열에 값이 같으면 exponent 증가
		{	
			if( factor[structSize-1].factor == arr[i] )
			{
				factor[structSize-1].exponent++;

			}
			else	                             // 다르면 이전 구조체배열을 다름 칸으로 옮겨서 factor = arr[i] 입력, exponent = 1 입력
			{
				factor[structSize].factor = arr[i];
				factor[structSize].exponent = 1;
				structSize++;
			}
			j++;

		}
		if( j >= size )
		{
			break;		                      // j가 size(= 소인수분해배열크기)보다 커지면 함수 탈출
		}
		if( arr[i] != arr[j] )
		{
			i = j;		                       // i가 가리키는 소인수분해배열값과 j가 가리키는 소인수분해배열값이 다르면 i를 j쪽으로 가리키도록 옮김
		}
	}
	return structSize;
}


int LcmFinder::createLcm( int val1, int val2 )	                        // 최소공배수만드는함수
{
	Factorizer fac;
	int mkresult = 1;		                                            // 값을 곱해서 최소공배수를 도출해내는 변수
	int input1Arr[100], input2Arr[100];                                 //소인수분해값 저장하기위해
	Factor input1Factor[100], input2Factor[100];                        // 구조체값으로 바꾸기 위해서
	int input1FactorizeArrSize = fac.factorize(input1Arr , val1);		// 첫번째 입력값이 소인수분해해서 배열에 담을 때 그 배열의 크기
	int input2FactorizeArrSize = fac.factorize(input2Arr , val2);		// 두번째 입력값이 소인수분해해서 배열에 담을 때 그 배열의 크기

	int input1StructArrSize = insertFactorInStruct(input1Arr, input1FactorizeArrSize , input1Factor);	// 첫번째 입력값의 구조체배열 크기//배열,크기,구조체
	int input2StructArrSize = insertFactorInStruct(input2Arr, input2FactorizeArrSize , input2Factor);	// 두번째 입력값의 구조체배열 크기


	int i = 2;		// factor값을 찾는 변수(2부터 1씩 증가시키면서 각 구조체에 맞는 수를 찾음)//소수는 2부터
	int j = 0;		// 첫번째 입력값의 구조체 배열의 자리
	int k = 0;		// 두번째 입력값의 구조체 배열의 자리
	int m;		    // 입력값 중 큰값까지 i를 늘려주기 위한것

	if( val1 >= val2 )       
		m = val1;
	else
		m = val2;

	for( i ; i <= m ; i++ )		// i를 m까지 증가시킴
	{
		if( input1Factor[j].factor == i && input2Factor[k].factor == i)		// i가 첫번째 구조체의 factor와 두번째 구조체의 factor 동시에 존재할때
		{
			if( input1Factor[j].exponent >= input2Factor[k].exponent )		// 두 구조체의 exponent를 비교하여 큰것을 곱함
			{
				for( int l = 0 ; l < input1Factor[j].exponent ; l++ )
				{                                                           // exponent의 수만큼 factor를 Result에 곱해줌

					mkresult = mkresult * input1Factor[j].factor;
				}
			}
			else
			{
				for( int l = 0 ; l < input2Factor[k].exponent ; l++ )
				{
					mkresult = mkresult * input2Factor[k].factor;
				}
			}
			j++;		// 첫번째 구조체의 자릿수를 늘림
			k++;		// 두번째 구조체의 자릿수를 늘림
		}
		else if( input1Factor[j].factor == i && input2Factor[k].factor != i )		// i가 첫번째 구조체의 factor엔 존재하지만 두번째 구조체의 factor에 존재하지않을때
		{
			for( int l = 0 ; l < input1Factor[j].exponent ; l++ )
			{                  // 첫번째 구조체의 exponent만큼 factor를 Result에 곱해줌

				mkresult = mkresult * input1Factor[j].factor;
			}
			j++;		// 첫번째 구조체의 자릿수를 늘림
		}
		else if( input1Factor[j].factor != i && input2Factor[k].factor == i )		// i가 첫번째 구조체의 factor엔 존재하지않지만 두번째 구조체의 factor에 존재할때
		{
			for( int l = 0 ; l < input2Factor[k].exponent ; l++ )
			{     // 두번째 구조체의 exponent만큼 factor를 Result에 곱해줌
				mkresult = mkresult * input2Factor[k].factor;
			}
			k++;		// 두번째 구조체의 자릴수를 늘림
		}
	}

	return mkresult;
}