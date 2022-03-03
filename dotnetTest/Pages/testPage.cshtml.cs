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

    }

    public void OnPostConvert(){

	    string input = Request.Form["Temperature"];

	    ViewData["Temperature"] = input;

    }
}
