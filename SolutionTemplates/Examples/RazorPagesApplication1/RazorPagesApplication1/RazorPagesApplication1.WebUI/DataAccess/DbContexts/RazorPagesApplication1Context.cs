// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      RazorPagesApplication1Context.cs
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using RazorPagesApplication1.WebUI.DataAccess.Entities;

namespace RazorPagesApplication1.WebUI.DataAccess.DbContexts;

public class RazorPagesApplication1Context : DbContext
{
    public RazorPagesApplication1Context(DbContextOptions<RazorPagesApplication1Context> options) : base(options)
    {
    }

    public DbSet<TodoItem>? TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RazorPagesApplication1Context).Assembly);
    }
}