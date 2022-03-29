using Microsoft.AspNetCore.Mvc;


namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later

public interface IOrder{

	int id { get; set; }

        string customer { get; set; }

	string burger { get; set; }

        double burgerCost { get; set; }

	string sides { get; set; }

        double sidesCost { get; set; }
	
	string drink { get; set; }

        double drinkCost { get; set; }

	double taxRate { get; set; }

	double subTotal(double burgerCost, double sidesCost, double drinkCost);

	double total();

}

