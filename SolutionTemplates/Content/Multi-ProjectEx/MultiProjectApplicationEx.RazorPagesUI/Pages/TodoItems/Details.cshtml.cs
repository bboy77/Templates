// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Details.cshtml.cs
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

namespace MultiProjectApplicationEx.RazorPagesUI.Pages.TodoItems;

public class DetailsModel : PageModel
{
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public DetailsModel(DatabaseNameContext context)
#else
    public DetailsModel(SolutionNameContext context)
#endif
    {
        _context = context;
    }

    public TodoItem TodoItem { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

#if (DatabaseTableIsEmpty)
        TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id);
#endif

        if (TodoItem == null)
        {
            return NotFound();
        }

        return Page();
    }
}