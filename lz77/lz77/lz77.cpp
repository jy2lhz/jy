// lz77.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
#include <fstream>


#define WindowLength 256  //2的8次方
#define MaxLen 256       //2的7次方

typedef struct {
	unsigned short off, len;
	char c;
}CODE;


int Match(char *WindowString, int Sn, char *NextString, int Nn)  //字符串匹配
{
	int i = 0, j = 0, k;
	while ((i < Sn) && (j < Nn))
	{
		if (WindowString[i] == NextString[j])
		{
			i++;
			j++;
		}
		else
		{
			i = i - j + 1;
			j = 0;
		}
	}
	if (j >= Nn)
		k = i - Nn;
	else k = -1;
	return k;
}

void Code(char *arr, int ILen, CODE *CodeFile, int *CodeLen){
	int WindowsStart = 0, WindowEnd = 0;
	*CodeLen = 0;
	if (ILen > 0)  //对第一个字符进行编码
	{
		CodeFile[0].off = 0;
		CodeFile[0].len = 0;
		CodeFile[0].c = arr[0];
		(*CodeLen)++;
	}
	int i = 1, j = 1, k1 = 0, k2 = 0;
	for (; i < ILen; i++)
	{
		if (i < WindowLength)
			WindowEnd = i;
		else WindowEnd = WindowLength;
		for (j = 1, k1= 0, k2 = 0;j < MaxLen + 1; j++)
		{
			k1 = k2;
			k2 = Match(arr + i - WindowEnd, WindowEnd, arr + i, j);
			if ((k2 < 0) || (j == MaxLen))
			{
				CodeFile[*CodeLen].off = WindowEnd - k1;
				if ((CodeFile[*CodeLen].len = j - 1) == 0)
					CodeFile[*CodeLen].off = 0;
				CodeFile[*CodeLen].c = arr[i + j - 1];
				i = i + j - 1;
				if (i == ILen)
				{
					CodeFile[*CodeLen].len--;
					CodeFile[*CodeLen].c = arr[i - 1];
				}
				(*CodeLen)++;
				break;
			}
		}

	}
}

void Decode(char *arr, int CodeLen, char *outData)
{
	int Move = 0;
	for (int i = 0; i < CodeLen; i = i + 3)
	{
		if(((unsigned char)arr[i]) ==0)
		{
			outData[Move] = arr[i + 2];
			Move++;
		}
		else
		{
			memcpy((outData + Move),(outData + Move - (unsigned char)arr[i + 1]), (unsigned char)arr[i]);
			Move = Move + (unsigned char)arr[i];
			outData[Move] = arr[i + 2];
			Move++;
		}
	}
}

int Count(char *arr, int Codelen)
{
	//int groupLen = Codelen / 3;
	int bmpLen = 0;
	for (int i = 0; i < Codelen; i = i + 3)
	{
		bmpLen = bmpLen + (unsigned char)arr[i] + 1;
	}
	return bmpLen;
}

int lz77Out(CODE *CodeFile, int CodeLen)
{
	std::ofstream Out;
	Out.open("lz77out.jy", std::ios::binary);
	unsigned short temp;
	for (int i = 0; i < CodeLen; i++)
	{
		//Out << CodeFile[i].off << "," << CodeFile[i].len << "," << CodeFile[i].c << "/";
		//Out << CodeFile[i].off << CodeFile[i].len << CodeFile[i].c;
		temp = (CodeFile[i].off << 8) + CodeFile[i].len;
		Out.write((char*)&temp, sizeof(unsigned short));
		Out.write(&(CodeFile[i].c), sizeof(char));
	}
	Out.close();
	return 1;
}

void fileOut(char *outData, int len)
{
	std::ofstream file;
	file.open("jieBMP.bmp", std::ios::binary);
	file.write(outData, len);
	file.close();
}


int main()
{
	std::ifstream InData;
	int InLength;
	InData.open("BMP.bmp", std::ios::in | std::ios::binary);
	InData.seekg(0, std::ios::end);
	InLength = InData.tellg();
	InData.seekg(0, std::ios::beg);
	char *buffer;
	buffer = new char[InLength];
	InData.read(buffer, InLength);
	InData.close();

	CODE *CodeFile;
	CodeFile = new CODE[InLength];
	int CodeSize = sizeof(CODE);

	int CodeLength;
	Code(buffer, InLength, CodeFile, &CodeLength);
	lz77Out(CodeFile, CodeLength);

	int lz77Len;
	std::ifstream lz77;
	lz77.open("lz77out.jy", std::ios::in | std::ios::binary);
	lz77.seekg(0, std::ios::end);
	lz77Len = lz77.tellg();
	lz77.seekg(0,std::ios::beg);
	char *lz77Buffer;
	lz77Buffer = new char[lz77Len];
	lz77.read(lz77Buffer, lz77Len);
	int OutLen;
	OutLen = Count(lz77Buffer,lz77Len);
	char *OutData = new char[OutLen];
	Decode(lz77Buffer, lz77Len, OutData);
	fileOut(OutData,OutLen);
	return 0;
}
