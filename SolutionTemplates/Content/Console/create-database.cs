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

SET PROJECT=SolutionName.ConsoleUI
SET STARTUP_PROJECT=SolutionName.ConsoleUI

SET MIGRATIONS=DataAccess\Migrations
SET MIGRATION_NAME=Initial
SET MIGRATIONS_SCRIPT=%PROJECT%\DataAccess\Scripts\Migrations.sql

#if (!DatabaseIsEmpty)
SET DBCONTEXT=DatabaseNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\DataAccess\Scripts\DatabaseNameContext.sql
#else
SET DBCONTEXT=SolutionNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\DataAccess\Scripts\SolutionNameContext.sql
#endif

REM Drop the database
dotnet ef database drop --force --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.

REM Remove Migrations Directory
IF EXIST %PROJECT%\%MIGRATIONS% (
    RMDIR /Q /S %PROJECT%\%MIGRATIONS%
    ECHO Removed directory %PROJECT%\%MIGRATIONS%.
) ELSE (
    ECHO %PROJECT%\%MIGRATIONS% directory does not exist.
)
ECHO.

REM Add Migration
dotnet ef migrations add %MIGRATION_NAME% --output-dir %MIGRATIONS% --project %PROJECT% --startup-project %STARTUP_PROJECT%
ECHO.

IF EXIST %PROJECT%\%MIGRATIONS% (
    ECHO %PROJECT%\%MIGRATIONS% directory has been created.
) ELSE (
    ECHO Unable to create the %PROJECT%\%MIGRATIONS% directory.
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