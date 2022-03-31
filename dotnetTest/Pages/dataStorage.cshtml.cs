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

// here we load the orders and orderhistory class

using dotnetTest.Models;

namespace dotnetTest.Pages;

public class dataStorageModel : PageModel
{
    private readonly ILogger<dataStorageModel> _logger;

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

    // this variable is for the IOrderHistory dependency injection
    // for data storage

    private IOrderHistory _orderHistory;
    private IOrder _order;

    public dataStorageModel(ILogger<dataStorageModel> logger,
		    IEnergyConversion energyConversion,
		    IBaseUnitConversion baseUnitConversion,
		    IPowerConverter powerConversion,
		    IData data,
		    IRNGScoped scopedRNG,
		    IRNGScoped scopedRNG2,
		    IRNGTransient transientRNG,
		    IRNGTransient transientRNG2,
		    IRNGSingleton singletonRNG,
		    IRNGSingleton singletonRNG2,
		    IOrderHistory orderHistory,
		    IOrder order)
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

	// this one does dependency injection for order history object
	
	_orderHistory = orderHistory;
	_order = order;


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



    [BindProperty]
    [Required]
    public string customer { get; set; }

    [BindProperty]
    [Required]
    public string burger { get; set; }

    [BindProperty]
    [Required]
    public string drink { get; set; }

    [BindProperty]
    [Required]
    public string sides { get; set; }


    public IEnumerable<IOrder> orderHistoryDisplay;

    public void OnPostSubmitOrder(){

	    // we fill in the order first

	    _order.customer = customer;
	    _order.burger = burger;
	    _order.drink = drink;
	    _order.sides = sides;

	    _order.drinkCost = 1.00;
	    _order.sidesCost = 3.99;
	    _order.burgerCost = 3.99;
	    _order.id = 1;

	    // straightaway we create an order

	    _orderHistory.createOrder(_order);

	    // we then copy this order history into
	    // a local copy for display

	    this.orderHistoryDisplay = _orderHistory.getOrderHistory();	    


    }

    



}

