#pragma once
#include <iostream>
#include <string>
using namespace std;

const int SIZE = 100;

class Factorizer
{
private:
	int isPrime(int n); // �Ҽ����� �Լ�
public:
	Factorizer(void);
	~Factorizer(void);

	int factorize(int arr[] , int n); // ���μ����� �Լ�
};

