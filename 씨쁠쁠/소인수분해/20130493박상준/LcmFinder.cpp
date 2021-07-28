#include "LcmFinder.h"
#include "Factorizer.h"


LcmFinder::LcmFinder(void)
{
}


LcmFinder::~LcmFinder(void)
{
}

int LcmFinder::insertFactorInStruct(int arr[], int size , Factor factor[])		// ���μ������� �迭�� �޾Ƽ� ����ü�迭�� �ű� //���μ����� �迭,�迭�� ũ��,����ü
{
	int structSize = 0;		//����ü�迭�� ũ��
	int i = 0;		        // factor�� ���ϱ� ���� ����
	int j = 0;		        // exponent�� ���ϱ� ���� ����

	while( 1 )
	{
		if( arr[i] == arr[j] )		// ���μ����� �� �� �ش� �迭�� ���� ������ exponent ����
		{	
			if( factor[structSize-1].factor == arr[i] )
			{
				factor[structSize-1].exponent++;

			}
			else	                             // �ٸ��� ���� ����ü�迭�� �ٸ� ĭ���� �Űܼ� factor = arr[i] �Է�, exponent = 1 �Է�
			{
				factor[structSize].factor = arr[i];
				factor[structSize].exponent = 1;
				structSize++;
			}
			j++;

		}
		if( j >= size )
		{
			break;		                      // j�� size(= ���μ����ع迭ũ��)���� Ŀ���� �Լ� Ż��
		}
		if( arr[i] != arr[j] )
		{
			i = j;		                       // i�� ����Ű�� ���μ����ع迭���� j�� ����Ű�� ���μ����ع迭���� �ٸ��� i�� j������ ����Ű���� �ű�
		}
	}
	return structSize;
}


int LcmFinder::createLcm( int val1, int val2 )	                        // �ּҰ����������Լ�
{
	Factorizer fac;
	int mkresult = 1;		                                            // ���� ���ؼ� �ּҰ������ �����س��� ����
	int input1Arr[100], input2Arr[100];                                 //���μ����ذ� �����ϱ�����
	Factor input1Factor[100], input2Factor[100];                        // ����ü������ �ٲٱ� ���ؼ�
	int input1FactorizeArrSize = fac.factorize(input1Arr , val1);		// ù��° �Է°��� ���μ������ؼ� �迭�� ���� �� �� �迭�� ũ��
	int input2FactorizeArrSize = fac.factorize(input2Arr , val2);		// �ι�° �Է°��� ���μ������ؼ� �迭�� ���� �� �� �迭�� ũ��

	int input1StructArrSize = insertFactorInStruct(input1Arr, input1FactorizeArrSize , input1Factor);	// ù��° �Է°��� ����ü�迭 ũ��//�迭,ũ��,����ü
	int input2StructArrSize = insertFactorInStruct(input2Arr, input2FactorizeArrSize , input2Factor);	// �ι�° �Է°��� ����ü�迭 ũ��


	int i = 2;		// factor���� ã�� ����(2���� 1�� ������Ű�鼭 �� ����ü�� �´� ���� ã��)//�Ҽ��� 2����
	int j = 0;		// ù��° �Է°��� ����ü �迭�� �ڸ�
	int k = 0;		// �ι�° �Է°��� ����ü �迭�� �ڸ�
	int m;		    // �Է°� �� ū������ i�� �÷��ֱ� ���Ѱ�

	if( val1 >= val2 )       
		m = val1;
	else
		m = val2;

	for( i ; i <= m ; i++ )		// i�� m���� ������Ŵ
	{
		if( input1Factor[j].factor == i && input2Factor[k].factor == i)		// i�� ù��° ����ü�� factor�� �ι�° ����ü�� factor ���ÿ� �����Ҷ�
		{
			if( input1Factor[j].exponent >= input2Factor[k].exponent )		// �� ����ü�� exponent�� ���Ͽ� ū���� ����
			{
				for( int l = 0 ; l < input1Factor[j].exponent ; l++ )
				{                                                           // exponent�� ����ŭ factor�� Result�� ������

					mkresult = mkresult * input1Factor[j].factor;
				}
			}
			else
			{
				for( int l = 0 ; l < input2Factor[k].exponent ; l++ )
				{
					mkresult = mkresult * input2Factor[k].factor;
				}
			}
			j++;		// ù��° ����ü�� �ڸ����� �ø�
			k++;		// �ι�° ����ü�� �ڸ����� �ø�
		}
		else if( input1Factor[j].factor == i && input2Factor[k].factor != i )		// i�� ù��° ����ü�� factor�� ���������� �ι�° ����ü�� factor�� ��������������
		{
			for( int l = 0 ; l < input1Factor[j].exponent ; l++ )
			{                  // ù��° ����ü�� exponent��ŭ factor�� Result�� ������

				mkresult = mkresult * input1Factor[j].factor;
			}
			j++;		// ù��° ����ü�� �ڸ����� �ø�
		}
		else if( input1Factor[j].factor != i && input2Factor[k].factor == i )		// i�� ù��° ����ü�� factor�� �������������� �ι�° ����ü�� factor�� �����Ҷ�
		{
			for( int l = 0 ; l < input2Factor[k].exponent ; l++ )
			{     // �ι�° ����ü�� exponent��ŭ factor�� Result�� ������
				mkresult = mkresult * input2Factor[k].factor;
			}
			k++;		// �ι�° ����ü�� �ڸ����� �ø�
		}
	}

	return mkresult;
}