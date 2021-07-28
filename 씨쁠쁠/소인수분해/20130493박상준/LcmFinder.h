#pragma once
#include <iostream>
using namespace std;

const int MAX_FACTORS = 40;

typedef struct {
	int factor;
	int exponent;
}Factor;

class LcmFinder
{
private:
	int insertFactorInStruct( int arr[] , int factorizeArrSize, Factor factor[] ); // 소인수분해한 배열을 받아서 구조체배열로 옮김
public:
	LcmFinder(void);
	~LcmFinder(void);
	int createLcm(int val1, int val2 ); // 최소공배수만드는 함수
};