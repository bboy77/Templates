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
using MultiProjectApplication.Data.Entities;

namespace MultiProjectApplication.Data.Configurations;

public class DatabaseTableConfiguration : IEntityTypeConfiguration<DatabaseTable>
{
    public void Configure(EntityTypeBuilder<DatabaseTable> builder)
    {
        builder.ToTable("DatabaseTables").HasKey(databaseTable => databaseTable.Id).HasName("PK_DatabaseTables");

        builder.Property(databaseTable => databaseTable.Id).HasColumnName("DatabaseTableId");

        builder.Property(databaseTable => databaseTable.Name).HasMaxLength(50).IsRequired();

        builder.Property(databaseTable => databaseTable.Description).HasMaxLength(255).IsRequired(false);

#if (DatabaseProviderIsSqlite)
        builder.Property(databaseTable => databaseTable.DateCreated)
            .HasColumnType("TIMESTAMP DATETIME")
            .HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%S', 'now')");
#else
        builder.Property(databaseTable => databaseTable.DateCreated).HasDefaultValueSql("GETDATE()");
#endif
    }
}