using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Form_Submit.Models;

// here's where we can do validation attributes, eg [Required], [Range] etc
//
using System.ComponentModel.DataAnnotations;

namespace dotnetTest.Pages;

public class testPageModel : PageModel
{
    private readonly ILogger<testPageModel> _logger;

    public testPageModel(ILogger<testPageModel> logger)
    {
        _logger = logger;
    }


    // now i want to try things the dependency injection way, meaning to say we pass in the object in the constructor
    // but how to do this? i don't invoke the onstructor in my code...
    //
    // (1) create a constructor here in the code
    // (2) instead of making an instance of the pagemodel manually, the @model does it for you
    // (3) however, i don't have a bracket to put in my dependency injection objects
    // (4) so instead i use the @inject keyword.
    //
    // good pages to look at:
    // https://stackoverflow.com/questions/130794/what-is-dependency-injection
    // https://www.jamesshore.com/v2/blog/2006/dependency-injection-demystified
    // https://stackoverflow.com/questions/47463206/how-to-retrieve-a-service-in-razor-pages-with-dependency-injection


    public void OnGet()
    {

    }

    public string dataString { get; set; }

    public DataModel temperatureData { get; set; } 

    public void OnPostSubmit(){

	    string data = "result:";

	    ViewData["dataString"] = data;

	    DataModel temperatureData = new DataModel();

	    temperatureData.Name = "Temperature";

            // forms implicitly give string values, not double,
	    // we need to convert string to double using Convert
	    //
	    string temperatureValStr = Request.Form["Value"];
            double temperatureVal = Convert.ToDouble(temperatureValStr);

	    temperatureData.Value = temperatureVal;
	    temperatureData.Unit = "celsius";

	    ViewData["temperatureData"] = temperatureData;

	    dataString = Convert.ToString(temperatureVal)+" "+temperatureData.Unit+"=";

	    ViewData["dataString2"] = dataString;


	    // now i want to declare a unit conversion, temp conversion object
	    //

	    UnitConversion.TempConversion tempConv = new UnitConversion.TempConversion();

	    double tempF = tempConv.cToF(temperatureVal,2);
	    string tempFString = Convert.ToString(tempF);

	    dataString = tempF + " " + "Fahrenheit";

	    ViewData["dataString3"] = dataString;



	    


    }



    [BindProperty]
    [Required]
    [Range(-459.67,2.55e32)]
    public double tempF { get; set; }

    public void OnPostConvertFahrenheit(){

	    if (ModelState.IsValid)
	    {

	    ViewData["tempF"] = "Results: " + tempF.ToString() + " F = ";

	    double tempC;

	    UnitConversion.TempConversion tempConv = new UnitConversion.TempConversion();


	    tempC = tempConv.fToC(tempF);

	    ViewData["tempC"] = tempC.ToString() + " C";
	    }
    }
}

