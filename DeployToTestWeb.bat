REM ************************************************
REM
REM �{���W�١GDeploy NPI Web To Test Environment
REM Target Web Site:\\tp-srm-04\d$\WebDB\npiweb
REM Development Web Site�GC:\NPI\target\npiweb
REM �N�������Ƴƥ�
REM
REM ************************************************  

Set DeployVersion=01
Set TargetDir=\\tp-srm-04\d$\WebDB\npiweb
Set FromDir=C:\NPI\target\npiweb

REM -------------------------------------------------
REM  �{�� �p�U
REM -------------------------------------------------

For /f "tokens=1 delims= " %%G in ('date /t') do set dt=%%G
For /f "tokens=1,2,3 delims=/ " %%G in ("%dt%") do Set TodayDate=%%G-%%H-%%I


md %TargetDir%-%TodayDate%-%DeployVersion%

xcopy /h /r /k /x /y /S /E %TargetDir% %TargetDir%-%TodayDate%-%DeployVersion%


del  /s/q %TargetDir%\*.*


xcopy /h /r /k /x /y /S /E %FromDir% %TargetDir%



pause