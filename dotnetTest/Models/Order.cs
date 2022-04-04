using Microsoft.AspNetCore.Mvc;



namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later

public class Order : IOrder 
{

	public int Id { get; set; }

        public string customer { get; set; }

	public string burger { get; set; }

        public double burgerCost { get; set; }

	public string sides { get; set; }

        public double sidesCost { get; set; }
	
	public string drink { get; set; }

        public double drinkCost { get; set; }

	public double taxRate { get; set; }

	// we are making a constructor to have some defaults
	//
	
	public Order(){

		customer = "blank";
		burger = "nothing";
		burgerCost = 0.0;
		sides = "nothing";
		sidesCost = 0.0;
		drink = "nothing";
		drinkCost = 0.0;
		taxRate = 17;

	}


	public double subTotal(double burgerCost, 
			double sidesCost, 
			double drinkCost){

		double subTotal = burgerCost + sidesCost + drinkCost;

		return subTotal;

	}

	public double total(){

		double total;

		double burgerCost = this.burgerCost;
		double sidesCost = this.sidesCost;
		double drinkCost = this.drinkCost;


		double subTotal = this.subTotal(burgerCost, sidesCost,
				drinkCost);

		// add tax
		//
		//

		total = subTotal * (1+taxRate/100);

		return total;	



	}

}

