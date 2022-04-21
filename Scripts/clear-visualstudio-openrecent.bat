REM ----------------------------------------------------------------------------
REM File:      clear-visualstudio-openrecent.bat
REM Copyright: Copyright © 2022 Aeb Solutions. All rights reserved.
REM License:   Licensed under the MIT license. See LICENSE file for full 
REM            license information.
REM ----------------------------------------------------------------------------

@ECHO OFF
CLS
ERASE /F /Q "%LOCALAPPDATA%\Microsoft\VisualStudio\17.0_f1c6002e\ApplicationPrivateSettings.*"
PAUSE