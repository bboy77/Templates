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

SET PROJECT=SolutionName.Data
SET STARTUP_PROJECT=SolutionName.RazorPagesUI

SET MIGRATIONS=%PROJECT%\Migrations
SET MIGRATION_NAME=Initial
SET MIGRATIONS_SCRIPT=%PROJECT%\Scripts\Migrations.sql

#if (!DatabaseIsEmpty)
SET DBCONTEXT=DatabaseNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\Scripts\DatabaseNameContext.sql
#else
SET DBCONTEXT=SolutionNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\Scripts\SolutionNameContext.sql
#endif


REM Drop the database
dotnet ef database drop --force --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.

REM Remove Migrations Directory
IF EXIST %MIGRATIONS% (
    RMDIR /Q /S %MIGRATIONS%
    ECHO Removed directory %MIGRATIONS%.
) ELSE (
    ECHO %MIGRATIONS% directory does not exist.
)
ECHO.

REM Add Migration
dotnet ef migrations add %MIGRATION_NAME% --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.

IF EXIST %MIGRATIONS% (
    ECHO %MIGRATIONS% directory has been created.
) ELSE (
    ECHO Unable to create the %MIGRATIONS% directory.
)
ECHO.

REM Update Database
dotnet ef database update --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.

REM Create DBContext Script
dotnet ef dbcontext script  --output %DBCONTEXT_SCRIPT% --context %DBCONTEXT% --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.
ECHO Created script %DBCONTEXT_SCRIPT%
ECHO.

REM Create Migrations Script
dotnet ef migrations script  --output %MIGRATIONS_SCRIPT% --context %DBCONTEXT% --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.
ECHO Created script %MIGRATIONS_SCRIPT%
ECHO.

PAUSE