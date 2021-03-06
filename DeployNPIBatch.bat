REM ************************************************
REM
REM 程式名稱：Deploy NPI Batch To Product(正式) Environment
REM Target  Site:\\tp-sso-03\d$\SCM\npi\batch
REM From  Site：\\tp-srm-04\d$\job\NPI\batch
REM 將原先的資料備份
REM
REM ************************************************  

Set DeployVersion=01
Set TargetDir=\\tp-sso-03\d$\SCM\npi\batch
Set FromDir=\\tp-srm-04\d$\job\NPI\batch
Set ConfigFile=BatchConsoleApp.exe.config


REM -------------------------------------------------
REM  程式 如下
REM -------------------------------------------------

For /f "tokens=1 delims= " %%G in ('date /t') do set dt=%%G
For /f "tokens=1,2,3 delims=/ " %%G in ("%dt%") do Set TodayDate=%%G-%%H-%%I


md %TargetDir%-%TodayDate%-%DeployVersion%

xcopy /h /r /k /x /y /S /E %TargetDir% %TargetDir%-%TodayDate%-%DeployVersion%


del  /s/q %TargetDir%\*.*


xcopy /h /r /k /x /y /S /E %FromDir% %TargetDir%




pause


