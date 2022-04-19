REM ************************************************
REM
REM 程式名稱：產生BuyingMode 
REM 程式檔案：GenerateBuyingModeBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=產生BuyingMode
Set NameSpace.ClassName=BatchLibrary.GenerateBuyingModeBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause