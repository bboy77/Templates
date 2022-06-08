// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Edit.cshtml.cs
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

public class EditModel : PageModel
{
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public EditModel(DatabaseNameContext context)
#else
    public EditModel(SolutionNameContext context)
#endif
    {
        _context = context;
    }

    [BindProperty]
    public DatabaseTable DatabaseTable { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        DatabaseTable = await _context.DatabaseTables!.FirstOrDefaultAsync(m => m.Id == id);

        if (DatabaseTable == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(DatabaseTable).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DatabaseTableExists(DatabaseTable.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool DatabaseTableExists(int id)
    {
        return _context.DatabaseTables!.Any(e => e.Id == id);
    }
}