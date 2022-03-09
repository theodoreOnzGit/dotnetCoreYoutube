using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Models;


public class MockOther : IOther
{
	public double cost(){

		double cost = 2.00;

		return cost;
	}

}


public class Other : IOther
{
	public double cost(){

		double cost = pickleCost()+bbqSauceCost()+tomatoCost();

		return cost;
	}

	private double pickleCost(){

		double cost = 0.02;

		return cost;


	}

	private double bbqSauceCost(){

		double cost = 0.005;

		return cost;


	}

	private double tomatoCost(){

		double cost = 0.03;

		return cost;

	}

}
