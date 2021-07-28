/* �� ������ �ּҰ����
�й�: 20130493 �ۼ���:�ڻ���
�ۼ���:2013.6.5
����ó : 010-9774-5263 */
#include "ioHandler.h"
#include "LcmFinder.h"

const int FALSE = 0;
const int TRUE = 1;
const int MAX_INT = 100000;
const int MIN_INT = 1;

int main( void )
{
	ioHandler ioh;
	LcmFinder lcm;
	int input1 , input2;		// �Է¹��� �� 2��
	//Factor input1Factor[100], input2Factor[100];	//�Է°��� ���μ������Ѱ��� factor�� exponent�� �ֱ����� ����ü �迭

	while( 1 )
	{
		int result;		// int����� �ʱ�ȭ

		cout << "2���� �������� �Է�" << endl;
		input1= ioh.getInteger( MIN_INT , MAX_INT ); 
		input2= ioh.getInteger( MIN_INT , MAX_INT );
		if( input1 == EXIT && input2 == EXIT )return 0;		                 // �Է°� �� �� -999�Է½� ����
		if( input1*input2 <= 0 )                                             //�Ѱ��� -999�ϰ�� �ٽ� �Է�
{ 
			cout << "�Է°��� -999�� ���ԵǾ��ֽ��ϴ�."<<endl<<endl; 
			continue;
		}
		if( input1 == 1 )
		{ 
			cout << input2 << endl;        // ù��° �Է°��� 1�϶� ������� �ι�°�Է°����� ����
			continue;
		}		     
		else if( input2 == 1 )
		{
			cout << input1 << endl;        // �ι�° �Է°��� 1�϶� ������� ù��°�Է°����� ����
			continue;
		}	    
		result = lcm.createLcm( input1, input2 );		                 // �ּҰ��������� �Լ�

		ioh.putString( "�����->" , result );
	}
}