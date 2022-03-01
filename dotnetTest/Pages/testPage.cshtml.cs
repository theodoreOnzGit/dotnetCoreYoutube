using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Pages;

public class testPageModel : PageModel
{
    private readonly ILogger<testPageModel> _logger;

    public testPageModel(ILogger<testPageModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        UnitConversion.TempObject tempData1;
        tempData1 = new UnitConversion.TempObject();
    }
}
