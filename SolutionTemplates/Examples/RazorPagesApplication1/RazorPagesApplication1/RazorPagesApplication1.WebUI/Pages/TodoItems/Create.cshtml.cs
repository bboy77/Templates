#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesApplication1.WebUI.DataAccess.DbContexts;
using RazorPagesApplication1.WebUI.DataAccess.Entities;

namespace RazorPagesApplication1.WebUI.Pages.TodoItems
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesApplication1.WebUI.DataAccess.DbContexts.RazorPagesApplication1Context _context;

        public CreateModel(RazorPagesApplication1.WebUI.DataAccess.DbContexts.RazorPagesApplication1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoItem TodoItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TodoItems.Add(TodoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
