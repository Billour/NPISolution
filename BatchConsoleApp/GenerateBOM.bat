REM ************************************************
REM
REM 程式名稱：展BOM資料 
REM 程式檔案：GenerateAnalysisDocBatch.cs
REM 正在使用
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=展開BOM資料
Set NameSpace.ClassName=BatchLibrary.GenerateBOM

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
