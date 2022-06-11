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

#if (AddFluentValidation)
using FluentValidation;
#endif
#if (AddMediatR)
using MediatR;
#endif
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApplication.WpfUI.DataAccess.DbContexts;

namespace WpfApplication.WpfUI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionName(this IServiceCollection serviceCollection, HostBuilderContext hostBuilderContext)
    {
#if (AddAutoMapper)
        serviceCollection.AddAutoMapper(typeof(App));
#endif
#if (!DatabaseIsEmpty)
        serviceCollection.AddDbContext<DatabaseNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(hostBuilderContext.Configuration.GetConnectionString("DatabaseName")));
#else
            options.UseSqlServer(hostBuilderContext.Configuration.GetConnectionString("DatabaseName")));
#endif
#else
        serviceCollection.AddDbContext<SolutionNameContext>(options =>
#if (!DatabaseProviderIsSqlServer)
            options.UseSqlite(hostBuilderContext.Configuration.GetConnectionString("SolutionName")));
#else
            options.UseSqlServer(hostBuilderContext.Configuration.GetConnectionString("SolutionName")));
#endif
#endif
#if (AddMediatR)
        serviceCollection.AddMediatR(typeof(App));
#endif
#if (AddFluentValidation)
        serviceCollection.AddValidatorsFromAssemblyContaining(typeof(App));
#endif
        serviceCollection.AddSingleton<MainWindow>();
        return serviceCollection;
    }
}