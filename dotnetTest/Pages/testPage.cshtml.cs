using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// this package (or more correctly, namespace) gives us access to the model validation rules in square brakcets
using System.ComponentModel.DataAnnotations;

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


    [BindProperty]
    [Required]
    [Range(-459.67,2.55e32)]
    public double tempF { get;  set; }

    public void OnPostConvertFToC(){

	    if(ModelState.IsValid)

	    {

	    // string input = Request.Form["TempF"];

	    // tempF = Convert.ToDouble(tempF);
	    //
	    // get: a = tempF;
	    // set: tempF = 89;

	    UnitConversion.TempConversion convObj = new UnitConversion.TempConversion();

	    double tempC = convObj.fToC(tempF,2);

	    // let's join a few strings together
	    //
	    //

	    string output;

	    output = "Result: "+ tempF +" F = " + Convert.ToString(tempC) + " C";

	    ViewData["outputFToC"]= output;
	    }

    }

}
