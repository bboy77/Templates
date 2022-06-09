<!-- Header -->
# ![](https://github.com/bboy77/Templates/blob/main/Assets/github-image32x32.png) Code Convention Templates
Solution templates for the .NET command-line interface and `Visual Studio`.

<!-- Solution Templates -->
## ![](https://github.com/bboy77/Templates/blob/main/Assets/github-image16x16.png) Solution Templates
* [Console](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Console/)
* [Desktop](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Desktop/)
* [Web](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Web/)
* [Multi Project](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Multi-Project/)
* [Multi Project Ex](https://github.com/bboy77/Templates/tree/main/SolutionTemplates/Content/Multi-ProjectEx/)

<!-- Features -->
## ![](https://github.com/bboy77/Templates/blob/main/Assets/github-image16x16.png) Features
Optional features will not be added unless selected. See individual templates for optional parameters that are available.
* StyleCop
  * [StyleCop.Analyzers](https://www.nuget.org/packages/StyleCop.Analyzers/1.2.0-beta.406)
* [Database Providers (Entity Framework Core)](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
  * Sqlite
  * Sql Server Express
  * Sql Server LocalDB
* Dependency Injection
* Generic Host
* Logging
  * Generic Host
  * Serilog (Optional)
    * [Serilog.AspNetCore](https://www.nuget.org/packages/Serilog.AspNetCore/5.0.0)
    * [Serilog.Enrichers.Environment](https://www.nuget.org/packages/Serilog.Enrichers.Environment/2.2.0)
    * [Serilog.Enrichers.Process](https://www.nuget.org/packages/Serilog.Enrichers.Process/)
    * [Serilog.Enrichers.Thread](https://www.nuget.org/packages/Serilog.Enrichers.Thread/3.1.0)
    * [Serilog.Settings.Configuration](https://www.nuget.org/packages/Serilog.Settings.Configuration/3.3.0)
    * [Serilog.Sinks.Console](https://www.nuget.org/packages/Serilog.Sinks.Console/4.0.1)
    * [Serilog.Sinks.Debug](https://www.nuget.org/packages/Serilog.Sinks.Debug/)
    * [Serilog.Sinks.File](https://www.nuget.org/packages/Serilog.Sinks.File/5.0.0)
* Files
  * .editor.config
  * appsettings.json
  * create-database.bat
  * LICENSE (Optional)
  * stylecop.json
* NuGet Packages (Optional)
  * Auto Mapper
    + [AutoMapper](https://www.nuget.org/packages/AutoMapper/)
    + [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/)
  * Bogus
    * [Bogus](https://www.nuget.org/packages/Bogus/)
  * Fluent Validation
    * [FluentValidation](https://www.nuget.org/packages/FluentValidation/)
    * [FluentValidation.AspNetCore](https://www.nuget.org/packages/FluentValidation.AspNetCore/)
    * [FluentValidation.DependencyInjectionExtensions](https://www.nuget.org/packages/FluentValidation.DependencyInjectionExtensions/)
  * MediatR
    * [MediatR](https://www.nuget.org/packages/MediatR/)
    * [MediatR.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/MediatR.Extensions.Microsoft.DependencyInjection/)
    
<!-- Requirements -->
## ![](https://github.com/bboy77/Templates/blob/main/Assets/github-image16x16.png) Requirements
* [Visual Studio 2022](https://visualstudio.microsoft.com/launch/)
* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Entity Framework Core tools for .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
* [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

<!-- Instalation -->
## ![](/Assets/github-image16x16.png) Installation
.NET CLI
```
dotnet new --install AebSolutions.CodeConvention.SolutionTemplates::6.5.0
```

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
