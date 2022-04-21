// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      DatabaseTableConfiguration.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiApplication.Api.DataAccess.Entities;

namespace WebApiApplication.Api.DataAccess.Configurations;

public class DatabaseTableConfiguration : IEntityTypeConfiguration<DatabaseTable>
{
    public void Configure(EntityTypeBuilder<DatabaseTable> builder)
    {
        builder.ToTable("DatabaseTables").HasKey(e => e.Id).HasName("PK_DatabaseTables");

        builder.Property(e => e.Id).HasColumnName("DatabaseTableId");

        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

        builder.Property(e => e.Description).HasMaxLength(255).IsRequired(false);

#if (DatabaseProviderIsSqlite)
        builder.Property(e => e.DateCreated)
            .HasColumnType("TIMESTAMP DATETIME")
            .HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ', 'now')");
#else
        builder.Property(e => e.DateCreated).HasDefaultValueSql("GETDATE()");
#endif
    }
}