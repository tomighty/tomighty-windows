@echo off

set version=%1

echo.
echo ~~~~~~~~~~~~~~~~~~~~~~~
echo %version%
echo ~~~~~~~~~~~~~~~~~~~~~~~
echo.

if "%version%"=="" (goto use_latest_tagname_as_version_number) else goto begin



:use_latest_tagname_as_version_number

for /f %%i in ('git rev-list --tags --max-count=1') do set commit=%%i
for /f %%i in ('git describe --tags %commit%') do set version=%%i



:begin

echo ==========================================================================
echo Building Tomighty %version%
echo ==========================================================================
echo.

msbuild Tomighty.sln /t:rebuild /p:Configuration=Release



:package

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

xcopy /f LICENSE.txt %dest%
xcopy /f NOTICE.txt %dest%
xcopy /f %src%\Tomighty.Windows.exe %dest%
xcopy /f %src%\Tomighty.Core.dll %dest%
xcopy /f %src%\Microsoft.Toolkit.Uwp.Notifications.dll %dest%
xcopy /f /s %src%\Resources %dest%\Resources

powershell -executionpolicy bypass -file pack.ps1 "%dest%" "%zipfile%"



echo.
echo --------------------------------------------------------------------------
echo Package: %zipfile%
echo Build finished
echo --------------------------------------------------------------------------
