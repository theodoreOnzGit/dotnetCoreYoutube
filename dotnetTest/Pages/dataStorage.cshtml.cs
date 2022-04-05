using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Pages;

public class dataStorageModel : PageModel
{
    private readonly ILogger<dataStorageModel> _logger;

    public dataStorageModel(ILogger<dataStorageModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
