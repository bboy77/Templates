// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      Index.cshtml.cs
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApplication1.WebUI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Hello World!");
    }
}