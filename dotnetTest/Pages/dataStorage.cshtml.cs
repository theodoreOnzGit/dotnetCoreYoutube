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

    // this variable is for the IOrderHistory dependency injection
    // for data storage

    private IOrderHistory _orderHistory;
    private Order _order;

    public dataStorageModel(ILogger<dataStorageModel> logger,
		    IOrderHistory orderHistory)
    {
        _logger = logger;

	// this one does dependency injection for order history object
	
	_orderHistory = orderHistory;
	_order = new Order();


	this.orderHistoryDisplay = _orderHistory.getOrderHistory();	    
    }



    public void OnGet()
    {

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


    public IEnumerable<Order> orderHistoryDisplay;

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

    [BindProperty]
    public int orderID { get; set; }


    public void OnPostDeleteOrder(){

	    _orderHistory.deleteOrder(orderID);

    }

    
    public void OnPostClearAll(){

	    _orderHistory.clearAllOrders();

    }

    public void OnPostUpdateOrder(){


	    _order.customer = customer;
	    _order.burger = burger;
	    _order.drink = drink;
	    _order.sides = sides;

	    _order.drinkCost = 1.00;
	    _order.sidesCost = 3.99;
	    _order.burgerCost = 3.99;
	    _order.id = orderID;

	    _orderHistory.updateOrder(_order,orderID);


    }



}

