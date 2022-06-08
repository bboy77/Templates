// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Create.cshtml.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MultiProjectApplicationEx.Data.DbContexts;
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.RazorPagesUI.Pages.DatabaseTables;

public class CreateModel : PageModel
{
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public CreateModel(DatabaseNameContext context)
#else
    public CreateModel(SolutionNameContext context)
#endif
    {
        _context = context;
    }

    [BindProperty]
    public DatabaseTable DatabaseTable { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.DatabaseTables.Add(DatabaseTable);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}