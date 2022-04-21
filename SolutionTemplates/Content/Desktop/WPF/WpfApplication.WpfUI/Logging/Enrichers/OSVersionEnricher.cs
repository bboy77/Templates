// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      OSVersionEnricher.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Serilog.Core;
using Serilog.Events;
using System;

namespace WpfApplication.WpfUI.Logging.Enrichers;

public class OSVersionEnricher : ILogEventEnricher
{
    public const string OSVersionPropertyName = "OSVersion";
    private LogEventProperty? _logEventProperty;

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) =>
        logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));

    private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
    {
        var value = Environment.OSVersion;
        return propertyFactory.CreateProperty(OSVersionPropertyName, value);
    }

    private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory) =>
        _logEventProperty ??= CreateProperty(propertyFactory);
}