// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      ServiceCollectionExtensions.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using MultiProjectApplicationEx.Data.DbContexts;
#if (AddFluentValidation)
using FluentValidation;
#endif
#if (AddMediatR)
using MediatR;
#endif

namespace MultiProjectApplicationEx.RazorPagesUI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionName(this IServiceCollection serviceCollection, HostBuilderContext hostBuilderContext)
    {
#if (AddAutoMapper)
        serviceCollection.AddAutoMapper(typeof(Program));
#endif
#if (!DatabaseIsEmpty)
        serviceCollection.AddDbContext<DatabaseNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(
                hostBuilderContext.Configuration.GetConnectionString("DatabaseName"),
                sqliteOptions => sqliteOptions.MigrationsAssembly("SolutionName.Data")));
#else
            options.UseSqlServer(
                hostBuilderContext.Configuration.GetConnectionString("DatabaseName"),
                sqlServerOptions => sqlServerOptions.MigrationsAssembly("SolutionName.Data")));
#endif
#else
        serviceCollection.AddDbContext<SolutionNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(
                hostBuilderContext.Configuration.GetConnectionString("SolutionName"),
                sqliteOptions => sqliteOptions.MigrationsAssembly("SolutionName.Data")));
#else
            options.UseSqlServer(
                hostBuilderContext.Configuration.GetConnectionString("SolutionName"),
                sqlServerOptions => sqlServerOptions.MigrationsAssembly("SolutionName.Data")));
#endif
#endif
#if (AddMediatR)
        serviceCollection.AddMediatR(typeof(Program));
#endif
#if (AddFluentValidation)
        serviceCollection.AddValidatorsFromAssemblyContaining<Program>();
#endif
        return serviceCollection;
    }
}