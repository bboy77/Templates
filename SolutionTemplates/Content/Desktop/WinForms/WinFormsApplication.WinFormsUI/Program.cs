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
#if (UseSerilog)
using Serilog;
#endif

namespace WinFormsApplication.WinFormsUI;

internal static class Program
{
    private static readonly IHost _host;

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
    }

    [STAThread]
    private static void Main()
    {
        _host.Start();
        ApplicationConfiguration.Initialize();
        Application.Run(_host.Services.GetRequiredService<MainForm>());
        Exit();
    }

    private static void Exit()
    {
        using (_host)
        {
            _host.StopAsync();
        }

        _host.Dispose();
    }
}