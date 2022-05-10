REM ----------------------------------------------------------------------------
REM Solution:  RazorPagesApplication1
REM File:      create-database.bat
REM ----------------------------------------------------------------------------

@ECHO OFF
CLS
dotnet ef database drop --force --project "RazorPagesApplication1.WebUI"
RMDIR /S /Q "RazorPagesApplication1.WebUI/DataAccess/Migrations"
dotnet ef migrations add "Initial" --output-dir "DataAccess/Migrations" --project "RazorPagesApplication1.WebUI"
dotnet ef database update --project "RazorPagesApplication1.WebUI"
PAUSE