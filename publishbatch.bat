mkdir c:\NPI\target\batch

MsBuild NPISolution.sln

copy .\BatchConsoleApp\bin\Debug\*.* c:\NPI\target\batch /y

pause