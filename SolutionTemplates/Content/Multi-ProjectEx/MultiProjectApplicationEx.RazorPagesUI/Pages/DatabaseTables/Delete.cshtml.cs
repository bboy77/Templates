// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Delete.cshtml.cs
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
using MultiProjectApplicationEx.Data.DbContexts;
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.RazorPagesUI.Pages.DatabaseTables;

public class DeleteModel : PageModel
{
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public DeleteModel(DatabaseNameContext context)
#else
    public DeleteModel(SolutionNameContext context)
#endif
    {
        _context = context;
    }

    [BindProperty]
    public DatabaseTable? DatabaseTable { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        DatabaseTable = await _context.DatabaseTables.FirstOrDefaultAsync(e => e.Id == id);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        DatabaseTable = await _context.DatabaseTables.FindAsync(id);

        if (DatabaseTable == null)
        {
            return RedirectToPage("./Index");
        }

        _context.DatabaseTables.Remove(DatabaseTable);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}