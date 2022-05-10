// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      DatabaseNameContext.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.Data.DbContexts;

public class DatabaseNameContext : DbContext
{
    public DatabaseNameContext(DbContextOptions<DatabaseNameContext> options) : base(options)
    {
    }

#if (!DatabaseTableIsEmpty)
    public DbSet<DatabaseTable> DatabaseTables => Set<DatabaseTable>();
#else
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseNameContext).Assembly);
    }
}