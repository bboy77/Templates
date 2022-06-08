<!-- Header -->
# ![](/Assets/github-image32x32.png) Code Convention Templates
Solution templates for the .NET command-line interface and `Visual Studio`.

<!-- Solution Templates -->
## ![](/Assets/github-image16x16.png) Solution Templates
* [Console](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Console/)
* [Desktop](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Desktop/)
* [Web](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Web/)
* [Multi Project](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Multi-Project/)
* [Multi Project Ex](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Multi-ProjectEx/)

<!-- Features -->
## ![](/Assets/github-image16x16.png) Features
* Dependency Injection
* Generic Host
* Logging
  * Generic Host
  * Serilog (Optional)
* StyleCop configuration file
* .editorconfig
* create-database.bat: Creates an initial migration and database using the selected provider.
* appsettings.json
* LICENSE file for the solution (Optional)
* Data Access with Entity Framework Core
  * SQL Server Express LocalDB
  * SQL Server Express
  * Sqlite
* AutoMapper (Optional)
* FluentValidation (Optional)
* MediatR (Optional)

<!-- Requirements -->
## ![Requirements](/Assets/github-image16x16.png) Requirements
* [Visual Studio 2022](https://visualstudio.microsoft.com/launch/) version 17.0 and above
* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Entity Framework Core tools for .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) verion 6.0.5 and above
* [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

<!-- Instalation -->
## ![Installation](/Assets/github-image16x16.png) Installation
.NET CLI
```
dotnet new --install AebSolutions.CodeConvention.SolutionTemplates::6.5.0
```

## ![Instructions](/Assets/github-image16x16.png) Instructions
Follow the in-app instructions for creating the database and seeding data.

## ![Help](/Assets/github-image16x16.png) Help
.NET CLI
```
dotnet new cc-console --help
```
```
dotnet new cc-multi --help
```
```
dotnet new cc-multiex --help
```
```
dotnet new cc-razorpages --help
```
```
dotnet new cc-webapi --help
```
```
dotnet new cc-winforms --help
```
```
dotnet new cc-wpf --help
```
