@ECHO OFF


:ONCE
start "" "bin/server.exe"

start "" "bin/wServer.exe"

:STARTS
TASKLIST | find "server.exe"

if errorlevel 1 goto RUNS

if errorlevel 2 goto RUNS

if errorlevel 3 goto RUNS

if errorlevel 4 goto RUNS

goto STARTW

:STARTW
TASKLIST | find "wServer.exe"

if errorlevel 1 goto RUNW

if errorlevel 2 goto RUNW

if errorlevel 3 goto RUNW

if errorlevel 4 goto RUNW

goto RESTART



:RESTART

TIMEOUT 5

goto STARTS



:RUNW

start "" "bin/wServer.exe"

goto RESTART



:RNUS

start "" "bin/server.exe"

goto STARTS