#pragma once
#include <iostream>
#include <string>
using namespace std;

const int EXIT = -999;

class ioHandler
{
public:
	ioHandler(void);
	~ioHandler(void);

	int getInteger( int lower , int upper ); // �Է¹޴� �Լ�
	void putString( string msg , int s ); // ����� �Լ�

};

