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

#if (UseSerilog)
using Serilog;
#endif
using WebApiApplication.Api;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices
builder.Host.ConfigureServices((hostBuilderContext, serviceCollection) =>
{
    serviceCollection
        .AddSolutionName(hostBuilderContext)
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();
});

#if (UseSerilog)
builder.Host.UseSerilog((context, _, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});
#endif
var app = builder.Build();

// Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();