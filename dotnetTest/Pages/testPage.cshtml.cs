using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// here's where we can do validation attributes, eg [Required], [Range] etc
//
using System.ComponentModel.DataAnnotations;

// here we load the EnergyConversion and BaseConversion classes
//
using UnitConversion.Models;
using UnitConversion;

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

    public void OnPostSubmit(){

	    string data = "result:";

	    ViewData["dataString"] = data;


            // forms implicitly give string values, not double,
	    // we need to convert string to double using Convert
	    //
	    string temperatureValStr = Request.Form["Value"];
            double temperatureVal = Convert.ToDouble(temperatureValStr);


	    dataString = Convert.ToString(temperatureVal)+" "+"celsius"+"=";

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

    [BindProperty]
    [Required]
    public double btuPerHr { get; set; }

    public void OnPostConvertBtuPerHr(){

	    // for dependency injection (manual) i first need to instantiate
	    // objects
	    //

	    SimpleEnergyConversion energyConversion = new SimpleEnergyConversion();
	    
	    SimpleBaseUnitConversion baseUnitConversion = new SimpleBaseUnitConversion();
	    
	    PowerConversion powerConv;
	    powerConv = new PowerConversion(energyConversion,baseUnitConversion);

	    // the above process is what dependency injection is about:
	    // declaring dependencies as objects and passing them into
	    // the constructor
	    //
	    // the above way is quite manual and not really done
	    // in real webpages
	    //
	    // first let's pass the btuPerHr into viewdata

	    @ViewData["btuPerHr"] = btuPerHr;

	    // we'll then use the power conversion method
	    //
	    double wattsResult;

	    wattsResult = powerConv.btuPerHrToWatts(btuPerHr);

	    @ViewData["wattsResult"] = wattsResult;



	    
	    




    }



}

