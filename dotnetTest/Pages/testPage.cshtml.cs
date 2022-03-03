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

	    double tempC = Convert.ToDouble(input);

	    ViewData["Temperature"] = input;

	    UnitConversion.TempConversion convObj = new UnitConversion.TempConversion();

	    double tempF = convObj.cToF(tempC,2);

	    ViewData["TempF"] = tempF;

	    // let's join a few strings together
	    //
	    //

	    string output;

	    output = "Result: "+ input +" C = " + Convert.ToString(tempF) + " F";

	    ViewData["output"]= output;

    }
}
