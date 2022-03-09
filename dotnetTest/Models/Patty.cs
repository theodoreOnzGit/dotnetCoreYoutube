using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Models;

public interface IPatty{

	public double cost();


}

public class MockPatty : IPatty
{
	public double cost(){

		double cost = 5.00;

		return cost;
	}


}


public class Patty : IPatty
{
	public double cost(){

		double cost = farmCost()+processCost()+logisticsCost();

		return cost;
	}

	private double farmCost(){

		double cost = 1.20;

		return cost;


	}

	private double processCost(){

		double cost = 3.00;

		return cost;


	}

	private double logisticsCost(){

		double cost = 1.40;

		return cost;

	}

}
