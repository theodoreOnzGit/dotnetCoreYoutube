using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Form_Submit.Models;

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

    public string dataString { get; set; }

    public void OnPostSubmit(){

	    string data = Request.Form["Unit"];


	    ViewData["dataString"] = data;   


    }
}

