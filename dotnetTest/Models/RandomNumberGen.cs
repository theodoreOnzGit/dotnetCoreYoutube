using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models.RNG;


public class RNGTransient : IRNGTransient
{

        public double Value { get; set; }

	// the random number generator should be called ONCE
	// in the constructor only
	// after that the value stays the same
	//
	
	public RNGTransient(){

		Random rnd  = new Random();

		Value = rnd.Next(1,10000);

	}


}
public class RNGScoped : IRNGScoped
{

        public double Value { get; set; }

	// the random number generator should be called ONCE
	// in the constructor only
	// after that the value stays the same
	//
	
	public RNGScoped(){

		Random rnd  = new Random();

		Value = rnd.Next(1,10000);

	}


}
public class RNGSingleton : IRNGSingleton
{

        public double Value { get; set; }

	// the random number generator should be called ONCE
	// in the constructor only
	// after that the value stays the same
	//
	
	public RNGSingleton(){

		Random rnd  = new Random();

		Value = rnd.Next(1,10000);

	}


}

