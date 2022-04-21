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
dotnet ef database drop --force --project "WebApiApplication.Api"
RMDIR /S /Q "WebApiApplication.Api/DataAccess/Migrations"
dotnet ef migrations add "Initial" --output-dir "DataAccess/Migrations" --project "WebApiApplication.Api"
dotnet ef database update --project "WebApiApplication.Api"
PAUSE