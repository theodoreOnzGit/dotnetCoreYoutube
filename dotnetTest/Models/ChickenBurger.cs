using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnetTest.Models;

public class ChickenBurger {


	// dependency injection MUST occur the moment the object is created
	//
	// constructors are special functions/methods which execute the
	// moment an object is created
	//
	public ChickenBurger(IPatty patty, IBuns buns, IOther other){

		_patty = patty;
		_buns = buns;
		_other = other;

	}


	public void inject(IPatty patty, IBuns buns, IOther other){

		// this function injects the "real" dependencies

		_patty = patty;
		_buns = buns;
		_other = other;

	}

	private IPatty _patty;

	private IBuns _buns;

	private IOther _other;




	public double cost(){

		double tax = 1.17;

		double tip = 1.15;

		double profitMargin = 1.20;

		double cost = (pattyCost() + bunCost() + otherCost())*tax*tip*profitMargin;

		return cost;
	}

	private double pattyCost(){

		// declare object
		//

		double pattyCost = _patty.cost();

		return pattyCost;
	}

	private double bunCost(){

		double bunsCost = _buns.cost();

		return bunsCost;

	}

	private double otherCost(){

                double otherCost = _other.cost();

		return otherCost;

	}

}
