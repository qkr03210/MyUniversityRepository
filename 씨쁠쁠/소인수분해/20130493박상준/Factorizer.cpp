#include "Factorizer.h"


Factorizer::Factorizer(void)
{
}


Factorizer::~Factorizer(void)
{
}

int Factorizer::factorize(int arr[], int input )	// 소인수분해 함수
{
	int primenumber;
	int i = 0;
	
	while(input != 1)
	{
		primenumber = isPrime(input); 

		input = input / primenumber ; 

		arr[i] = primenumber;                      //소인수분해한값을 배열로 옮김

		i++;

	}
	return i; 
}

int Factorizer::isPrime(int n)                         // 소수판정함수
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
