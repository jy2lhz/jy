clear;

clc;

X = imread('BMP.bmp');

figure(1);

imshow(X,[]);title('原始图像');

 

%2级小波变换

N = 2;

[C,S] = wavedec2(X,N,'db1');

 

%计算大小

[sizeX,sizeY] = size(X);

size1X = sizeX/2;

size1Y = sizeY/2;

size2X = sizeX/4;

size2Y = sizeY/4;

 

%提取第2级小波系数

temp = C(1:size2X*size2Y);

cA2 = reshape(temp(1:size2X*size2Y),size2X,size2Y);

%cA2 = appcoef2(C,S,'db1',2);

 

%temp = C(size2X*size2Y:size2X*size2Y*2);

%cH2 = reshape(temp(1:size2X*size2Y),size2X,size2Y);

%temp = C(size2X*size2Y*2:size2X*size2Y*3);

%cV2 = reshape(temp(1:size2X*size2Y),size2X,size2Y);

%temp = C(size2X*size2Y*3:size2X*size2Y*4);

%cD2 = reshape(temp(1:size2X*size2Y),size2X,size2Y);

%[cH2,cV2,cD2] = detcoef2('all',C,S,2);

 

%提取第1级小波变换系数

temp = C(size1X*size1Y:size1X*size1Y*2);

cH1 = reshape(temp(1:size1X*size1Y),size1X,size1Y);

temp = C(size1X*size1Y*2:size1X*size1Y*3);

cV1 = reshape(temp(1:size1X*size1Y),size1X,size1Y);

temp = C(size1X*size1Y*3:size1X*size1Y*4);

cD1 = reshape(temp(1:size1X*size1Y),size1X,size1Y);

%[cH1,cV1,cD1] = detcoef2('all',C,S,1);

 

figure(2);

subplot(221);imshow(cA2,[]);title('cA2');

subplot(222);imshow(cH2,[]);title('cH2');

subplot(223);imshow(cV2,[]);title('cV2');

subplot(224);imshow(cD2,[]);title('cD2');

 

figure(3);

%subplot(221);imshow(cA1,[]);title('cA1');

subplot(222);imshow(cH1,[]);title('cH1');

subplot(223);imshow(cV1,[]);title('cV1');

subplot(224);imshow(cD1,[]);title('cD1');

 

%画分割线

[m,n]=size(X);

mm = zeros(m,n);

mm = [[cA2,cH2;cV2,cD2],cH1;cV1,cD1];

dim = 2;

for i=1:dim

    m=m-mod(m,2);

    n=n-mod(n,2);

    mm(m/2,1:n)=255;

    mm(1:m,n/2)=255;

    m=m/2;

    n=n/2;

end

figure(4);

imshow(mm,[]);title('二级分解图像');