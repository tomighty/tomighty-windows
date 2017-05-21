@echo off

echo ==========================================================================
echo Building Tomighty
echo ==========================================================================
echo.

msbuild Tomighty.sln /t:rebuild /p:Configuration=Release

set tag=%1

if "%tag%"=="" (for /f %%i in ('git rev-parse --short HEAD') do set tag=%%i)

for /f %%i in ('powershell -noprofile -executionpolicy bypass "(Get-Item Tomighty.Windows\bin\Release\Tomighty.Windows.exe).VersionInfo.FileVersion"') do set version=%%i

set dirname=tomighty-windows-%version%-%tag%
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

xcopy /f LICENSE.txt %dest%
xcopy /f NOTICE.txt %dest%
xcopy /f %src%\Tomighty.Windows.exe %dest%
xcopy /f %src%\Tomighty.Core.dll %dest%
xcopy /f %src%\Microsoft.Toolkit.Uwp.Notifications.dll %dest%
xcopy /f /s %src%\Resources %dest%\Resources
xcopy /f Tomighty.Update.Swap\bin\Release\Tomighty.Update.Swap.exe %dest%

powershell -executionpolicy bypass -file pack.ps1 "%dest%" "%zipfile%"

echo.
echo --------------------------------------------------------------------------
echo Package: %zipfile%
echo Build finished
echo --------------------------------------------------------------------------
