REM ************************************************
REM
REM 程式名稱：Deploy NPI Web 
REM Target Web Site:\\tp-srm-03\d$\SCM\npi\npiweb
REM Target Web Site:\\srm\d$\SCM\npi\npiweb
REM Test Web Site：\\tp-srm-04\d$\WebDB\npiweb
REM 將原先的資料備份
REM Ref:Wiki[DeployScipt] By 2009-05-25 W.B.
REM ************************************************  

Set DeployVersion=01

REM -------------------------------------------------
REM  程式 如下
REM -------------------------------------------------

For /f "tokens=1 delims= " %%G in ('date /t') do set dt=%%G
For /f "tokens=1,2,3 delims=/ " %%G in ("%dt%") do Set TodayDate=%%G-%%H-%%I


md \\tp-srm-03\d$\SCM\npi\npiweb-%TodayDate%-%DeployVersion%

xcopy /h /r /k /x /y /S /E \\tp-srm-03\d$\SCM\npi\npiweb \\tp-srm-03\d$\SCM\npi\npiweb-%TodayDate%-%DeployVersion%

del  /s/q \\tp-srm-03\d$\SCM\npi\npiweb\*.*

md \\srm\d$\SCM\npi\npiweb-%TodayDate%-%DeployVersion%

xcopy /h /r /k /x /y /S /E \\srm\d$\SCM\npi\npiweb \\srm\d$\SCM\npi\npiweb-%TodayDate%-%DeployVersion%

del  /s/q \\srm\d$\SCM\npi\npiweb\*.*

xcopy /h /r /k /x /y /S /E \\tp-srm-04\d$\WebDB\npiweb \\tp-srm-03\d$\SCM\npi\npiweb

xcopy /h /r /k /x /y /S /E \\tp-srm-04\d$\WebDB\npiweb \\srm\d$\SCM\npi\npiweb

pause