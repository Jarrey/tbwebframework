Select * From MAIN.[TB_LANG_DICTIONARY] A;
Select * From MAIN.[TB_LANG_DICTIONARY] A where A.LD_DESC like '%����%';
Select max(A.LD_ITEM_SRNO) from MAIN.[TB_LANG_DICTIONARY] A; 
insert into MAIN.[TB_LANG_DICTIONARY] values (1076,1,'����');
insert into MAIN.[TB_LANG_DICTIONARY] values (1076,2,'�^�V');
insert into MAIN.[TB_LANG_DICTIONARY] values (1076,3,' Filter');
