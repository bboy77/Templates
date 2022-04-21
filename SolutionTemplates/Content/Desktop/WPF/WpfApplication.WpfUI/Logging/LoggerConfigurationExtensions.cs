// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      LoggerConfigurationExtensions.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Serilog;
using Serilog.Configuration;
using System;
using WpfApplication.WpfUI.Logging.Enrichers;

namespace WpfApplication.WpfUI.Logging;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration WithCustomTimestamp(this LoggerEnrichmentConfiguration enrichmentConfiguration) =>
        enrichmentConfiguration != null
            ? enrichmentConfiguration.With<CustomTimestampEnricher>()
            : throw new ArgumentNullException(nameof(enrichmentConfiguration));

    public static LoggerConfiguration WithOSVersion(this LoggerEnrichmentConfiguration enrichmentConfiguration) =>
        enrichmentConfiguration != null
            ? enrichmentConfiguration.With<OSVersionEnricher>()
            : throw new ArgumentNullException(nameof(enrichmentConfiguration));
}