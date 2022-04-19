REM ************************************************
REM
REM 程式名稱：產生NPI DB Schema 
REM 程式檔案：GenDbSchemaBatch.cs
REM 不使用
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=產生NPI-DB-Schema
Set NameSpace.ClassName=BatchLibrary.GenDbSchemaBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
