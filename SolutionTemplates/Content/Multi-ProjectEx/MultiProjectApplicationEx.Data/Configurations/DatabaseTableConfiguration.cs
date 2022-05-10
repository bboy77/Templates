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
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.Data.Configurations;

public class DatabaseTableConfiguration : IEntityTypeConfiguration<DatabaseTable>
{
    public void Configure(EntityTypeBuilder<DatabaseTable> builder)
    {
        builder.ToTable("DatabaseTables", "dbo").HasKey(e => e.Id).HasName("PK_DatabaseTables");

        builder.Property(e => e.Id).HasColumnName("DatabaseTableId");

        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

        builder.Property(e => e.UserName).HasMaxLength(50);

        builder.Property(e => e.Url).HasMaxLength(50);

        builder.Property(e => e.Description).HasMaxLength(255).IsRequired(false);
    }
}