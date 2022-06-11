REM ----------------------------------------------------------------------------
REM File:      build-solution-templates.bat
REM Copyright: Copyright © 2022 Aeb Solutions. All rights reserved.
REM License:   Licensed under the MIT license. See LICENSE file for full 
REM            license information.
REM ----------------------------------------------------------------------------

@ECHO OFF
CLS
RMDIR /S /Q %LOCALAPPDATA%\Microsoft\VisualStudio\17.0_f1c6002e\TemplateEngineHost\vs\
DEL /A:H /Q "%LOCALAPPDATA%\Microsoft\VisualStudio\17.0_f1c6002e\ProjectTemplatesCache_{00000000-0000-0000-0000-000000000000}\cache.bin"
nuget pack ../SolutionTemplates/AebSolutions.CodeConvention.SolutionTemplates.6.6.0.nuspec -NoDefaultExcludes -OutputDirectory ../Packages/
dotnet new --uninstall AebSolutions.CodeConvention.SolutionTemplates
dotnet new --install ../Packages/AebSolutions.CodeConvention.SolutionTemplates.6.6.0.nupkg
PAUSE