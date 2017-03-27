X=imread('BMP1.bmp');

N = 1;
[C,S] = wavedec2(X,N,'haar');
[C1,S1] = wavedec2(X(:,:,1),N,'haar');
[C2,S2] = wavedec2(X(:,:,2),N,'haar');
[C3,S3] = wavedec2(X(:,:,3),N,'haar');
fid=fopen('YCBCR.txt','w');
fid1=fopen('Y.txt','w');
fid2=fopen('CB.txt','w');
fid3=fopen('CR.txt','w');
SIZE=size(C);
YSIZE=size(C1);
CBSIZE=size(C2);
CRSIZE=size(C3);
fprintf(fid,'%12f       ',C);
fprintf(fid1,'%12f       ',C1);
fprintf(fid2,'%12f       ',C2);
fprintf(fid3,'%12f       ',C3);