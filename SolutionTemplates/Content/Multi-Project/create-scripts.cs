REM ----------------------------------------------------------------------------
REM Solution:  SolutionName
REM File:      create-scripts.bat
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

#if (!DatabaseIsEmpty)
SET DBCONTEXT=DatabaseNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\Scripts\DatabaseNameContext.sql
#else
SET DBCONTEXT=SolutionNameContext
SET DBCONTEXT_SCRIPT=%PROJECT%\Scripts\SolutionNameContext.sql
#endif
SET MIGRATIONS_SCRIPT=%PROJECT%\Scripts\Migrations.sql

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