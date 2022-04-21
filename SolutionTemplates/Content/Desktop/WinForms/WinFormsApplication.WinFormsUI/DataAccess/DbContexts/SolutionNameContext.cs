// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      SolutionNameContext.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using WinFormsApplication.WinFormsUI.DataAccess.Entities;

namespace WinFormsApplication.WinFormsUI.DataAccess.DbContexts;

public class SolutionNameContext : DbContext
{
    public SolutionNameContext(DbContextOptions<SolutionNameContext> options) : base(options)
    {
    }

#if (!DatabaseTableIsEmpty)
    public DbSet<DatabaseTable>? DatabaseTables { get; set; }
#else
    public DbSet<TodoItem>? TodoItems { get; set; }
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SolutionNameContext).Assembly);
    }
}