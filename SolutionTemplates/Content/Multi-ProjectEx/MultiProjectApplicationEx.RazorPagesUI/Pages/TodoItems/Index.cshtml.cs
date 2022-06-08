// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      Index.cshtml.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MultiProjectApplicationEx.Data.DbContexts;
using MultiProjectApplicationEx.Data.Entities;

namespace MultiProjectApplicationEx.RazorPagesUI.Pages.TodoItems;

public class IndexModel : PageModel
{
#if (!DatabaseIsEmpty)
    private readonly DatabaseNameContext _context;
#else
    private readonly SolutionNameContext _context;
#endif

#if (!DatabaseIsEmpty)
    public IndexModel(DatabaseNameContext context)
#else
    public IndexModel(SolutionNameContext context)
#endif
    {
        _context = context;
    }

    public IList<TodoItem> TodoItems { get; set; }

    public bool DatabaseCreated { get; set; }

    public async Task OnGetAsync()
    {
        DatabaseCreated = await (_context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.ExistsAsync();
        if (!DatabaseCreated)
        {
            return;
        }

#if (DatabaseTableIsEmpty)
        TodoItems = await _context.TodoItems!.ToListAsync();
#endif
    }
}