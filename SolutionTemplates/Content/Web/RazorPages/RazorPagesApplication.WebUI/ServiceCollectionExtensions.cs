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
using RazorPagesApplication.WebUI.DataAccess.DbContexts;
#if (AddFluentValidation)
using FluentValidation;
#endif
#if (AddMediatR)
using MediatR;
#endif

namespace RazorPagesApplication.WebUI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionName(this IServiceCollection services, HostBuilderContext context)
    {
#if (AddAutoMapper)
        services.AddAutoMapper(typeof(Program));
#endif
#if (!DatabaseIsEmpty)
        services.AddDbContext<DatabaseNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(context.Configuration.GetConnectionString("DatabaseName")));
#else
            options.UseSqlServer(context.Configuration.GetConnectionString("DatabaseName")));
#endif
#else
        services.AddDbContext<SolutionNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(context.Configuration.GetConnectionString("SolutionName")));
#else
            options.UseSqlServer(context.Configuration.GetConnectionString("SolutionName")));
#endif
#endif
#if (AddMediatR)
        services.AddMediatR(typeof(Program));
#endif
#if (AddFluentValidation)
        services.AddValidatorsFromAssemblyContaining<Program>();
#endif
        return services;
    }
}