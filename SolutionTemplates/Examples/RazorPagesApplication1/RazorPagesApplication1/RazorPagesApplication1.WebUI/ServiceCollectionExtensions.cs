// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      ServiceCollectionExtensions.cs
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using RazorPagesApplication1.WebUI.DataAccess.DbContexts;

namespace RazorPagesApplication1.WebUI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRazorPagesApplication1(this IServiceCollection services, HostBuilderContext context)
    {
        services.AddDbContext<RazorPagesApplication1Context>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("RazorPagesApplication1")));
        return services;
    }
}