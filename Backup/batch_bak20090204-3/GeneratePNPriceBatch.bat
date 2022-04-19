REM ************************************************
REM
REM 程式名稱：展開Price資料 
REM 程式檔案：GenerateAnalysisDocBatch.cs
REM
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=展開Price資料
Set NameSpace.ClassName=BatchLibrary.GeneratePNPriceBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
