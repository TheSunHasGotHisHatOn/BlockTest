@echo off
title Run Tests

if not exist Results mkdir Results


for /f "skip=1" %%d in ('wmic os get localdatetime') do if not defined mydate set mydate=%%d


set todaydate=%mydate:~0,8%
set hour=%time:~0,2%
set minute=%time:~3,2%
set second=%time:~6,2%
set filename=%todaydate%%hour%%minute%%second%

echo todaydate: %todaydate%
echo hour %hour%
echo minute %minute%
echo second %second%
echo filename %filename%

rem set filename=%foldername%%time:~0,2%%time:~3,2%%time:~6,2%
rem echo filename (time) %filename%

pause
@echo about to run tests
@echo Results/%foldername%/%filename%.xml
pause
echo current dir: %cd%
rem ..\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console /result:Results/%foldername%/%filename%.xml  ../BJSS/bin/debug/BJSS.dll
..\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console /result:Results/%filename%.xml  ../BJSS/bin/debug/BJSS.dll
@echo finished running tests
pause