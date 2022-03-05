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
    public double tempF { get; set; }

    public void OnPostConvertFahrenheit(){

	    ViewData["tempF"] = tempF;

    }
}

