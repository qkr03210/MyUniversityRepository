#pragma once
#include <iostream>
#include <string>
using namespace std;

const int SIZE = 100;

class Factorizer
{
private:
	int isPrime(int n); // 소수판정 함수
public:
	Factorizer(void);
	~Factorizer(void);

	int factorize(int arr[] , int n); // 소인수분해 함수
};

