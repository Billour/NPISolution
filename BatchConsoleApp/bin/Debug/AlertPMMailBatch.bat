REM ************************************************
REM
REM 程式名稱：通知PM信件 
REM 程式檔案：AlertPMMailBatch.cs
REM 正在使用
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=通知PM信件
Set NameSpace.ClassName=BatchLibrary.AlertPMMailBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
