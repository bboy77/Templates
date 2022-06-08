// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Program.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

#if (AddBogus)
using MultiProjectApplicationEx.Data.DataGenerators;
#endif
using MultiProjectApplicationEx.RazorPagesUI;
#if (UseSerilog)
using Serilog;
#endif

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices
builder.Host.ConfigureServices((hostBuilderContext, serviceCollection) =>
{
    serviceCollection
        .AddSolutionName(hostBuilderContext)
        .AddRazorPages();
});
#if (UseSerilog)
builder.Host.UseSerilog((hostBuilderContext, serviceProvider, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
});
#endif

// Build
var app = builder.Build();

// Configure
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
#if (AddBogus)
// Uncomment to generate initial data
// app.Generate(10);
#endif

// Run
app.Run();
