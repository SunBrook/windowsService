@echo off

:: ʹ�ù���Աģʽ����

%1 %2
ver|find "5.">nul&&goto :st
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :st","","runas",1)(window.close)&goto :eof
:st
copy "%~0" "%windir%\system32\"


:: ֹͣ���񣬹رշ���

sc stop DisposeDBService

sc delete DisposeDBService

@echo.
@pause