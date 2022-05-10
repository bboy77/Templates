// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      TodoItemConfiguration.cs
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorPagesApplication1.WebUI.DataAccess.Entities;

namespace RazorPagesApplication1.WebUI.DataAccess.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItems").HasKey(e => e.Id).HasName("PK_TodoItems");

        builder.Property(e => e.Id).HasColumnName("TodoItemId");

        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

        builder.Property(e => e.Description).HasMaxLength(255).IsRequired(false);

        builder.Property(e => e.DateCreated).HasDefaultValueSql("GETDATE()");
    }
}