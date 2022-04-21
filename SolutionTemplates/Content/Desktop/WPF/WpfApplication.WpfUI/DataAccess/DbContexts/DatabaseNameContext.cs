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
using WpfApplication.WpfUI.DataAccess.Entities;

namespace WpfApplication.WpfUI.DataAccess.DbContexts;

public class DatabaseNameContext : DbContext
{
    public DatabaseNameContext(DbContextOptions<DatabaseNameContext> options) : base(options)
    {
    }

#if (!DatabaseTableIsEmpty)
    public DbSet<DatabaseTable>? DatabaseTables { get; set; }
#else
    public DbSet<TodoItem>? TodoItems { get; set; }
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseNameContext).Assembly);
    }
}