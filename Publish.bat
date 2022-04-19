For /f "tokens=1 delims= " %%G in ('date /t') do set dt=%%G
For /f "tokens=1,2,3 delims=/ " %%G in ("%dt%") do Set TodayDate=%%G-%%H-%%I

if NOT EXIST c:\NPI\target%TodayDate% md c:\NPI\target%TodayDate%-old

if NOT EXIST c:\NPI\target%TodayDate% xcopy /h /r /k /x /y /S /E c:\NPI\target c:\NPI\target%TodayDate%-old

ren c:\NPI\target target%TodayDate%

mkdir c:\NPI\target\npiweb

mkdir c:\NPI\target\batch

MsBuild NPISolution.sln

copy .\BatchConsoleApp\bin\Debug\*.* c:\NPI\target\batch /y

pause