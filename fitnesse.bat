@echo off
set SCRIPT_DIR=%~dp0
set ROOT_DIR=%SCRIPT_DIR%\UnoByExample

set FITNESSEROOT=Fitnesse
set FITNESSEPORT=80
set TARGET=Debug

pushd %ROOT_DIR%

echo Lancement de FitNesse depuis %CD%
java -DTARGET=%TARGET% -jar %FITNESSEROOT%\bin\fitnesse.jar -e 0 -r %FITNESSEROOT%  -p %FITNESSEPORT%

popd

pause
