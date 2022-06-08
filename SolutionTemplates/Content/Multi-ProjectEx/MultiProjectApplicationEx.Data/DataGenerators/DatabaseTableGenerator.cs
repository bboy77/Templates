// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      DatabaseTableGenerator.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiProjectApplicationEx.Data.DbContexts;
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.Data.DataGenerators;

public static class DatabaseTableGenerator
{
    /// <summary>
    /// Generates data using the Bogus library. If data exists, no data will be generated.
    /// </summary>
    public static async void Generate(this IHost host, int count)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
#if (!DatabaseIsEmpty)
        var context = services.GetRequiredService<DatabaseNameContext>();
#else
        var context = services.GetRequiredService<SolutionNameContext>();
#endif

#if (!DatabaseTableIsEmpty)
        if (!await (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.ExistsAsync())
        {
            return;
        }

        if (await context.DatabaseTables.AnyAsync())
        {
            return;
        }

        var faker = new Faker<DatabaseTable>()
            .RuleFor(x => x.Description, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .Generate(count)
            .ToList();

        context.DatabaseTables.AddRange(faker);
#endif

        await context.SaveChangesAsync();
    }
}