// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      App.xaml.cs
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

using System.Windows;

namespace WpfApplication.WpfUI;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostBuilderContext, serviceCollection) =>
            {
                serviceCollection.AddSolutionName(hostBuilderContext);
            })
#if (UseSerilog)
            .UseSerilog((hostBuilderContext, serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            })
#endif
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }

        _host.Dispose();
        base.OnExit(e);
    }
}