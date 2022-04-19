REM ************************************************
REM
REM 程式名稱：測試WebMail
REM 程式檔案：TestWebMailBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=測試WebMail
Set NameSpace.ClassName=BatchLibrary.TestWebMailBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause