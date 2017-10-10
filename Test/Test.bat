@echo off
title Run Tests

pause

echo Launch dir: %~dp0%
echo Current dir: %cd%

if not exist Results mkdir Results

rem make date locale independent
rem mkdir %date:/=%


for /f "skip=1" %%d in ('wmic os get localdatetime') do if not defined mydate set mydate=%%d


cd Results
set foldername=%mydate:~0,8%
echo foldername: %foldername%
rem md %mydate:~0,8%
if not exist %foldername% mkdir %foldername%
rem md %foldername%
echo ----- results folder created ----
cd ..
echo Current dir: %cd%

set filename=%time:~0,2%-%time:~3,2%-%time:~6,2%
echo filename (time) %filename%

pause
@echo about to run tests
@echo Results/%foldername%/%filename%.xml
pause
echo current dir: %cd%
..\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console /result:Results/%foldername%/%filename%.xml  ../BJSS/bin/debug/BJSS.dll
@echo finished running tests
pause