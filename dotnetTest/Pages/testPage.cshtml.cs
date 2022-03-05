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

    public void OnPostConvertCToF(){

	    string input = Request.Form["TempC"];

	    double tempC = Convert.ToDouble(input);

	    UnitConversion.TempConversion convObj = new UnitConversion.TempConversion();

	    double tempF = convObj.cToF(tempC,2);

	    // let's join a few strings together
	    //
	    //

	    string output;

	    output = "Result: "+ input +" C = " + Convert.ToString(tempF) + " F";

	    ViewData["outputCToF"]= output;

    }

    public void OnPostConvertFToC(){

	    string input = Request.Form["TempF"];

	    double tempF = Convert.ToDouble(input);

	    UnitConversion.TempConversion convObj = new UnitConversion.TempConversion();

	    double tempC = convObj.fToC(tempF,2);

	    // let's join a few strings together
	    //
	    //

	    string output;

	    output = "Result: "+ input +" F = " + Convert.ToString(tempC) + " C";

	    ViewData["outputFToC"]= output;
    }

}
