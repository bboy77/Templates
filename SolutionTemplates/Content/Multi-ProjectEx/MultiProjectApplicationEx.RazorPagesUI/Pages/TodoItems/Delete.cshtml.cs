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

namespace MultiProjectApplicationEx.RazorPagesUI.Pages.TodoItems;

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
    public TodoItem? TodoItem { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

#if (DatabaseTableIsEmpty)
        TodoItem = await _context.TodoItems.FirstOrDefaultAsync(e => e.Id == id);
#endif

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

#if (DatabaseTableIsEmpty)
        TodoItem = await _context.TodoItems.FindAsync(id);

        if (TodoItem == null)
        {
            return RedirectToPage("./Index");
        }

        _context.TodoItems.Remove(TodoItem);
#endif

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}