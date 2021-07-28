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
	int insertFactorInStruct( int arr[] , int factorizeArrSize, Factor factor[] ); // ���μ������� �迭�� �޾Ƽ� ����ü�迭�� �ű�
public:
	LcmFinder(void);
	~LcmFinder(void);
	int createLcm(int val1, int val2 ); // �ּҰ��������� �Լ�
};