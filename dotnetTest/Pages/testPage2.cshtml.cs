using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// here's where we can do validation attributes, eg [Required], [Range] etc
//
using System.ComponentModel.DataAnnotations;

// here we load the EnergyConversion and BaseConversion classes
//
using UnitConversion.Models;
using UnitConversion;

// here we load the RNG class
using UnitConversion.Models.RNG;

namespace dotnetTest.Pages;

public class testPage2Model : PageModel
{
    private readonly ILogger<testPage2Model> _logger;

    private IBaseUnitConversion _baseUnitConversion;
    private IEnergyConversion _energyConversion;
    private IPowerConverter _powerConversion;
    private IData _data;

    // here's to demonstrate dependency injection using scoped, transient
    // and singleton
    //
    private IRNGScoped _scopedRNG;
    private IRNGScoped _scopedRNG2;
    private IRNGTransient _transientRNG;
    private IRNGTransient _transientRNG2;
    private IRNGSingleton _singletonRNG;
    private IRNGSingleton _singletonRNG2;

    public testPage2Model(ILogger<testPage2Model> logger,
		    IEnergyConversion energyConversion,
		    IBaseUnitConversion baseUnitConversion,
		    IPowerConverter powerConversion,
		    IData data,
		    IRNGScoped scopedRNG,
		    IRNGScoped scopedRNG2,
		    IRNGTransient transientRNG,
		    IRNGTransient transientRNG2,
		    IRNGSingleton singletonRNG,
		    IRNGSingleton singletonRNG2)
    {
        _logger = logger;
	_baseUnitConversion = baseUnitConversion;
	_energyConversion = energyConversion;
	_powerConversion = powerConversion;
	_data = data;

	_scopedRNG = scopedRNG;
	_scopedRNG2 = scopedRNG2;
	_transientRNG = transientRNG;
	_transientRNG2 = transientRNG2;
	_singletonRNG = singletonRNG;
	_singletonRNG2 = singletonRNG2;
    }



    public void OnGet()
    {

	    ViewData["buttonValue"] = _data.Value;

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

    public void OnPostButtonClick(){

	    buttonClick();

    } 

    public void buttonClick(){

	    // i want a button to click and add a number starting at zero
	    //
	    //
	    
	    _data.Value = _data.Value + 0.1;

	    ViewData["buttonValue"] = _data.Value;

    } 

    public void OnPostDepInjectionTest(){

	    ViewData["RNGSingleton1"] = _singletonRNG.Value;

	    ViewData["RNGSingleton2"] = _singletonRNG2.Value;


	    ViewData["RNGScoped1"] = _scopedRNG.Value;

	    ViewData["RNGScoped2"] = _scopedRNG2.Value;

	    ViewData["RNGTransient1"] = _transientRNG.Value;

	    ViewData["RNGTransient2"] = _transientRNG2.Value;
    }

    



}

