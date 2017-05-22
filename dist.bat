@echo off

echo ==========================================================================
echo Building Tomighty
echo ==========================================================================
echo.

msbuild Tomighty.sln /t:rebuild /p:Configuration=Release

for /f %%i in ('powershell -noprofile -executionpolicy bypass "(Get-Item Tomighty.Windows\bin\Release\Tomighty.Windows.exe).VersionInfo.FileVersion"') do set version=%%i

set tag=%1
if "%tag%"=="commit" (for /f %%i in ('git rev-parse --short HEAD') do set tag=%%i)

set artifact=tomighty-windows-%version%
if not "%tag%"=="" (set artifact=%artifact%-%tag%)

set zipfile=dist\%artifact%.zip
set src=Tomighty.Windows\bin\Release
set dest=build\%artifact%

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

makensis -DPRODUCT_NAME=Tomighty -DPRODUCT_VERSION=%version% -DPRODUCT_FILE_VERSION=%version% -DARTIFACT_NAME=%artifact% -DBUILD_DIR=%dest% setup.nsi

echo.
echo --------------------------------------------------------------------------
echo Package: %zipfile%
echo Build finished
echo --------------------------------------------------------------------------
