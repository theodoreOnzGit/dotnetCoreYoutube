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

public class testPage2Model : PageModel
{
    private readonly ILogger<testPage2Model> _logger;

    private IBaseUnitConversion _baseUnitConversion;
    private IEnergyConversion _energyConversion;
    private IPowerConverter _powerConversion;

    public testPage2Model(ILogger<testPage2Model> logger,
		    IEnergyConversion energyConversion,
		    IBaseUnitConversion baseUnitConversion,
		    IPowerConverter powerConversion)
    {
        _logger = logger;
	_baseUnitConversion = baseUnitConversion;
	_energyConversion = energyConversion;
	_powerConversion = powerConversion;
    }



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


	    @ViewData["btuPerHr"] = btuPerHr;

	    double wattsResult;

	    wattsResult = _powerConversion.btuPerHrToWatts(btuPerHr);

	    @ViewData["wattsResult"] = wattsResult;


    }



}

