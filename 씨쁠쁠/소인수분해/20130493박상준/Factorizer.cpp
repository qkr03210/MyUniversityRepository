#include "Factorizer.h"


Factorizer::Factorizer(void)
{
}


Factorizer::~Factorizer(void)
{
}

int Factorizer::factorize(int arr[], int input )	// ���μ����� �Լ�
{
	int primenumber;
	int i = 0;
	
	while(input != 1)
	{
		primenumber = isPrime(input); 

		input = input / primenumber ; 

		arr[i] = primenumber;                      //���μ������Ѱ��� �迭�� �ű�

		i++;

	}
	return i; 
}

int Factorizer::isPrime(int n)                         // �Ҽ������Լ�
{
	for (int i = 2 ; i <= n ; i ++)
	{
		if (n % i == 0)
		{
			return i; 
		}
	}
	return n;
}
