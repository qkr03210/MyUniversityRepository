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

	int getInteger( int lower , int upper ); // 입력받는 함수
	void putString( string msg , int s ); // 결과값 함수

};

