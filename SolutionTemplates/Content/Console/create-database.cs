REM ----------------------------------------------------------------------------
REM Solution:  SolutionName
REM File:      create-database.bat
#if (!CompanyIsEmpty)
REM Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
REM License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file
REM            for full license information.
#endif
REM ----------------------------------------------------------------------------

@ECHO OFF
CLS
dotnet ef database drop --force --project "ConsoleApplication.ConsoleUI"
RMDIR /S /Q "ConsoleApplication.ConsoleUI/DataAccess/Migrations"
dotnet ef migrations add "Initial" --output-dir "DataAccess/Migrations" --project "ConsoleApplication.ConsoleUI"
dotnet ef database update --project "ConsoleApplication.ConsoleUI"
PAUSE