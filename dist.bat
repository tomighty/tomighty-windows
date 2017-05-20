@echo off

REM msbuild Tomighty.sln /t:rebuild /p:Configuration=Release

for /f %%i in ('git rev-parse --abbrev-ref HEAD') do set version=%%i

set dirname=tomighty-windows-%version%
set zipfile=dist\%dirname%.zip
set src=Tomighty.Windows\bin\Release
set dest=build\%dirname%

IF NOT EXIST build (
    mkdir build
)

IF NOT EXIST dist (
    mkdir dist
)

IF EXIST %dest% (
    rmdir %dest% /S /Q
)

if exist %zipfile% (
    del %zipfile%
)

mkdir %dest%\Resources

copy LICENSE.txt %dest%
copy NOTICE.txt %dest%
copy %src%\Tomighty.Windows.exe %dest%
copy %src%\Tomighty.Core.dll %dest%
copy %src%\Newtonsoft.Json.dll %dest%
copy %src%\Microsoft.Toolkit.Uwp.Notifications.dll %dest%
xcopy /s %src%\Resources %dest%\Resources

powershell -executionpolicy bypass -file pack.ps1 "%dest%" "%zipfile%"
