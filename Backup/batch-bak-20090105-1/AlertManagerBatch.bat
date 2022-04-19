REM ************************************************
REM
REM 程式名稱：通知主管訊息 
REM 程式檔案：AlertManagerBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=通知主管訊息
Set NameSpace.ClassName=BatchLibrary.AlertManagerBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause