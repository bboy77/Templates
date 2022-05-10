// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      TodoItemGenerator.cs
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

public static class TodoItemGenerator
{
    public static async void Generate(this IHost host, int count)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
#if (!DatabaseIsEmpty)
        var context = services.GetRequiredService<DatabaseNameContext>();
#else
        var context = services.GetRequiredService<SolutionNameContext>();
#endif

#if (DatabaseTableIsEmpty)
        if (!await (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.ExistsAsync())
        {
            return;
        }

        if (await context.TodoItems.AnyAsync())
        {
            return;
        }

        var faker = new Faker<TodoItem>()
            .RuleFor(x => x.Description, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .Generate(count)
            .ToList();

        context.TodoItems.AddRange(faker);
#endif

        await context.SaveChangesAsync();
    }
}