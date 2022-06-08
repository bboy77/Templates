// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      About.cshtml.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MultiProjectApplicationEx.Data.DbContexts;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace MultiProjectApplicationEx.RazorPagesUI.Pages;

public class AboutModel : PageModel
{
    private readonly IConfiguration _configuration;
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public AboutModel(IConfiguration configuration, DatabaseNameContext context)
#else
    public AboutModel(IConfiguration configuration, SolutionNameContext context)
#endif
    {
        _configuration = configuration;
        _context = context;
    }

    public SolutionInformationModel? SolutionInformation { get; set; }

    public async Task OnGetAsync()
    {
        var databaseCreated = await (_context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.ExistsAsync();
        var databaseHasData = false;

        if (databaseCreated)
        {
#if (!DatabaseTableIsEmpty)
            databaseHasData = await _context.DatabaseTables.AnyAsync();
#else
            databaseHasData = await _context.TodoItems.AnyAsync();
#endif
        }

        SolutionInformation = new SolutionInformationModel
        {
            Company = _configuration.GetSection("SolutionInformation:Company").Value,
#if (!DatabaseIsEmpty)
            ConnectionString = _configuration.GetConnectionString("DatabaseName"),
#else
            ConnectionString = _configuration.GetConnectionString("SolutionName"),
#endif
            Database = _configuration.GetSection("SolutionInformation:Database").Value,
            DatabaseCreated = databaseCreated.ToString(),
            DatabaseHasData = databaseHasData.ToString(),
            DatabaseProvider = _configuration.GetSection("SolutionInformation:DatabaseProvider").Value,
            License = _configuration.GetSection("SolutionInformation:License").Value,
            Name = _configuration.GetSection("SolutionInformation:Name").Value,
        };
    }

    public class SolutionInformationModel
    {
        public string? Company { get; set; }

        [Display(Name = "Connection String")]
        public string ConnectionString { get; set; } = null!;

        public string Database { get; set; } = null!;

        [Display(Name = "Database Provider")]
        public string DatabaseProvider { get; set; } = null!;

        [Display(Name="Database Created")]
        public string DatabaseCreated { get; set; } = null!;

        [Display(Name="Database Has Data")]
        public string DatabaseHasData { get; set; } = null!;

        [Display(Name="License Identifier")]
        public string? License { get; set; }

        [Display(Name = "Solution Name")]
        public string Name { get; set; } = null!;
    }
}