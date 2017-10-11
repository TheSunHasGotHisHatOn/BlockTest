@echo off
title Run Tests

if not exist Results mkdir Results


for /f "skip=1" %%d in ('wmic os get localdatetime') do if not defined mydate set mydate=%%d


set todaydate=%mydate:~0,8%
rem time less than 10 is represented as 0,1,2 instead of 00, 01, 02 which breaks the file system.  this fixes it.
set timeNoSpace=%time: =0%
set hour=%timeNoSpace:~0,2%
set minute=%timeNoSpace:~3,2%
set second=%timeNoSpace:~6,2%
set filename=%todaydate%%hour%%minute%%second%

@echo About to run tests
@echo Results will be written to Results/%filename%.xml
pause
..\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console /result:Results/%filename%.xml  ../BJSS/bin/debug/BJSS.dll

..\packages\ReportUnit.1.2.1\tools\reportunit Results/%filename%.xml Results/%filename%.html
pause

@echo Finished running tests
pause