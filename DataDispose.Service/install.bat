@echo off

:: 使用管理员模式运行

%1 %2
ver|find "5.">nul&&goto :st
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :st","","runas",1)(window.close)&goto :eof
:st
copy "%~0" "%windir%\system32\"

:: 安装服务，设置自动模式，启动服务。

sc create DisposeDBService binPath=%~dp0DataDispose.Service.exe

sc config DisposeDBService start= AUTO

sc description DisposeDBService "测试服务"

net start DisposeDBService



@echo.
@pause