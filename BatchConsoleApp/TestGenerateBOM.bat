REM ************************************************
REM
REM 程式名稱：測試展BOM資料 
REM 程式檔案：TestBomBatch.cs
REM 測試用-不使用
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=測試展bom
Set NameSpace.ClassName=BatchLibrary.TestBomBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause