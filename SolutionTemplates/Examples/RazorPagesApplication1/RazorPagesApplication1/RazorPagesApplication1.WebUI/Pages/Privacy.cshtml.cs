// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      Privacy.cshtml.cs
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApplication1.WebUI.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Privacy Page");
    }
}