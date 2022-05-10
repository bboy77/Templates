#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApplication1.WebUI.DataAccess.DbContexts;
using RazorPagesApplication1.WebUI.DataAccess.Entities;

namespace RazorPagesApplication1.WebUI.Pages.TodoItems
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesApplication1.WebUI.DataAccess.DbContexts.RazorPagesApplication1Context _context;

        public IndexModel(RazorPagesApplication1.WebUI.DataAccess.DbContexts.RazorPagesApplication1Context context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; }

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItems.ToListAsync();
        }
    }
}
