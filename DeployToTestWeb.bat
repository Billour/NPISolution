REM ************************************************
REM
REM 程式名稱：Deploy NPI Web To Test Environment
REM Target Web Site:\\tp-srm-04\d$\WebDB\npiweb
REM Development Web Site：C:\NPI\target\npiweb
REM 將原先的資料備份
REM
REM ************************************************  

Set DeployVersion=01
Set TargetDir=\\tp-srm-04\d$\WebDB\npiweb
Set FromDir=C:\NPI\target\npiweb

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