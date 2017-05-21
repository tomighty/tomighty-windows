;======================================================
; Includes

  !include MUI.nsh
  !include Sections.nsh
  !include FileFunc.nsh

;======================================================
; Installer Information

  Name "Tomighty"
  OutFile "dist\${ARTIFACT_NAME}-install.exe"
  SetCompressor /SOLID lzma
  XPStyle on
  CRCCheck on
  InstallDir "C:\Program Files\${PRODUCT_NAME}\"
  AutoCloseWindow false
  ShowInstDetails show
  Icon "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"

;======================================================
; Version Tab information for Setup.exe properties

  VIProductVersion 2008.3.22.0
  VIAddVersionKey ProductName "${PRODUCT_NAME}"
  VIAddVersionKey ProductVersion "${PRODUCT_VERSION}"
  VIAddVersionKey FileVersion "${PRODUCT_FILE_VERSION}"

;======================================================
; Variables


;======================================================
; Modern Interface Configuration

  !define MUI_HEADERIMAGE
  !define MUI_ABORTWARNING
  !define MUI_COMPONENTSPAGE_SMALLDESC
  !define MUI_HEADERIMAGE_BITMAP_NOSTRETCH
  !define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
  !define MUI_FINISHPAGE_RUN
  !define MUI_FINISHPAGE_RUN_TEXT "Run Tomighty"
  !define MUI_FINISHPAGE_RUN_FUNCTION "LaunchLink"
  !define REG_UNINSTALL "Software\Microsoft\Windows\CurrentVersion\Uninstall\Tomighty"

;======================================================
; Modern Interface Pages

  !define MUI_DIRECTORYPAGE_VERIFYONLEAVE
  !insertmacro MUI_PAGE_LICENSE .\LICENSE.txt
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

;======================================================
; Languages

  !insertmacro MUI_LANGUAGE "English"

;======================================================
; Installer Sections

Section "Tomighty"
    SectionIn RO
    SetOutPath $INSTDIR
    SetOverwrite on
    File "${BUILD_DIR}\Tomighty.Windows.exe"
    File "${BUILD_DIR}\Tomighty.Update.Swap.exe"
    File "${BUILD_DIR}\Tomighty.Core.dll"
    File "${BUILD_DIR}\Microsoft.Toolkit.Uwp.Notifications.dll"
    File "${BUILD_DIR}\NOTICE.txt"
    File "${BUILD_DIR}\LICENSE.txt"
    File /r "${BUILD_DIR}\Resources"
    WriteUninstaller $INSTDIR\uninstall.exe
SectionEnd

Section "Start menu shortcuts"
    SetShellVarContext all
    CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Tomighty.lnk" "$INSTDIR\Tomighty.Windows.exe" "" "$INSTDIR\Tomighty.Windows.exe" 0
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
SectionEnd

Section "Desktop shortcut"
    SetShellVarContext all
    CreateShortCut "$DESKTOP\Tomighty.lnk" "$INSTDIR\Tomighty.Windows.exe" "" "$INSTDIR\Tomighty.Windows.exe" 0
SectionEnd

; Installer functions
Function .onInstSuccess
  WriteRegStr HKLM "${REG_UNINSTALL}" "DisplayName" "Tomighty - Desktop Pomodoro Timer"
  WriteRegStr HKLM "${REG_UNINSTALL}" "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
  WriteRegStr HKLM "${REG_UNINSTALL}" "Publisher" "Open Source"
  WriteRegStr HKLM "${REG_UNINSTALL}" "DisplayIcon" "$\"$INSTDIR\Tomighty.Windows.exe$\""

  ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
  IntFmt $0 "0x%08X" $0
  WriteRegDWORD HKLM "${REG_UNINSTALL}" "EstimatedSize" "$0"
FunctionEnd

Function LaunchLink
  ExecShell "" "$SMPROGRAMS\${PRODUCT_NAME}\Tomighty.lnk"
FunctionEnd

Section "uninstall"
  SetShellVarContext all

  delete "$DESKTOP\Tomighty.lnk"
  RMDir /r "$SMPROGRAMS\${PRODUCT_NAME}"
  RMDir /r "$INSTDIR"
  DeleteRegKey HKLM ${REG_UNINSTALL}
SectionEnd

Function .onInit
    InitPluginsDir
FunctionEnd