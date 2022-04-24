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
using MultiProjectApplication.Data.Entities;

namespace MultiProjectApplication.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItems").HasKey(todoItem => todoItem.Id).HasName("PK_TodoItems");

        builder.Property(todoItem => todoItem.Id).HasColumnName("TodoItemId");

        builder.Property(todoItem => todoItem.Name).HasMaxLength(50).IsRequired();

        builder.Property(todoItem => todoItem.Description).HasMaxLength(255).IsRequired(false);

#if (DatabaseProviderIsSqlite)
        builder.Property(todoItem => todoItem.DateCreated)
            .HasColumnType("TIMESTAMP DATETIME")
            .HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%S', 'now')");
#else
        builder.Property(todoItem => todoItem.DateCreated).HasDefaultValueSql("GETDATE()");
#endif
    }
}