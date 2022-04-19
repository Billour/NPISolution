REM ************************************************
REM
REM 程式名稱：通知Sourcer議價資料 
REM 程式檔案：GenerateAnalysisDocBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=通知Sourcer議價資料
Set NameSpace.ClassName=BatchLibrary.GenratePriceMail

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
