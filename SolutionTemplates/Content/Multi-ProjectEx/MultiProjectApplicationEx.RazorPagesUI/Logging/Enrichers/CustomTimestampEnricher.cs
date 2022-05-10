// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      CustomTimestampEnricher.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Serilog.Core;
using Serilog.Events;
using System.Globalization;

namespace MultiProjectApplicationEx.RazorPagesUI.Logging.Enrichers;

public class CustomTimestampEnricher : ILogEventEnricher
{
    public const string CustomTimestampPropertyName = "CustomTimestamp";
    private LogEventProperty? _logEventProperty;

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) =>
        logEvent.AddPropertyIfAbsent(GetLogEventProperty(propertyFactory));

    private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
    {
        var value = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        return propertyFactory.CreateProperty(CustomTimestampPropertyName, value);
    }

    private LogEventProperty GetLogEventProperty(ILogEventPropertyFactory propertyFactory) =>
        _logEventProperty ??= CreateProperty(propertyFactory);
}