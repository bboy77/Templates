// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      TodoItemConfiguration.cs
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

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItems").HasKey(e => e.Id).HasName("PK_TodoItems");

        builder.Property(e => e.Id).HasColumnName("TodoItemId");

        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

        builder.Property(e => e.Description).HasMaxLength(255).IsRequired(false);
    }
}