#include "ioHandler.h"


ioHandler::ioHandler(void)
{
}


ioHandler::~ioHandler(void)
{
}
 
int ioHandler::getInteger( int lower , int upper )                           // ������ �Է¹ޱ������Լ�
{
	int value;                                                               //�Է¹������� �����ϱ�����
	while( 1 ) {
		cin >> value;
		if( (value== EXIT) || (value >= lower && value < upper) )
			return value;

		cout << "Out of valid range!!!";
		cout << endl << endl;
	}
}

void ioHandler::putString( string msg , int s )		// ����� ��� �Լ�
{
	cout << msg;
	cout << s << endl << endl;
}