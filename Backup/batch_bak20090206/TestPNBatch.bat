REM ************************************************
REM
REM 程式名稱：測試查詢PN 
REM 程式檔案：TestPNPriceBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=測試查詢PN
Set NameSpace.ClassName=BatchLibrary.TestPNPriceBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause