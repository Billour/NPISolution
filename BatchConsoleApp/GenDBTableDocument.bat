REM ************************************************
REM
REM 程式名稱：產生資料庫文件 
REM 程式檔案：GenDBDocBatch.cs
REM 不使用
REM ************************************************  

Call .\Init.bat

REM -------------------設定資料於此開始-----------------------------

Set Program=產生資料庫文件
Set NameSpace.ClassName=BatchLibrary.GenDBDocBatch

REM -------------------設定資料於此結束-----------------------------

Call .\BatchProgram.bat
pause