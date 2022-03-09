using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Models;

public class SuperExpensiveWheat : IBuns{

	public double cost(){

		double cost = 200.0;

		return cost;

	}


}

public class MockBuns : IBuns
{
	public double cost(){

		double cost = 1.00;

		return cost;
	}


}


public class Buns : IBuns
{
	public double cost(){

		double cost = wheatCost()+processCost()+transportCost();

		return cost;
	}

	private double wheatCost(){

		double cost = 0.20;
		return cost;

	}

	private double processCost(){

		double cost = 0.80;
		return cost;

	}

	private double transportCost(){

		double cost = 0.30;
		return cost;

	}


}
