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

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
#if (UseSerilog)
using Serilog;
#endif

namespace ConsoleApplication.ConsoleUI;

public class Program
{
    private static readonly IHost _host;
    private static readonly ILogger<Program> _logger;

    static Program()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostBuilderContext, services) =>
            {
                services.AddSolutionName(hostBuilderContext);
            })
#if (UseSerilog)
            .UseSerilog((hostBuilderContext, serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            })
#endif
            .Build();

        _host.StartAsync();
        _logger = _host.Services.GetRequiredService<ILogger<Program>>();
    }

    public static async Task Main(string[] args)
    {
        // TODO: Code Here
        await Exit();
    }

    private static async Task Exit()
    {
        _logger.LogInformation("Press any key to exit the application...");
        Console.ReadKey();

        using (_host)
        {
            await _host.StopAsync();
        }

        _host.Dispose();
    }
}