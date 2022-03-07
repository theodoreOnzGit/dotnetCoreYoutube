using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;

// here is the implementation, the behind the scenes stuff

public class ComplexBaseUnitConversion : IBaseUnitConversion
{

	public double lbmToKg(double lbm){

		double kg;
		kg = lbm / 2.20462;
		return kg;

	}

	public double kgToLbm(double kg){

		double lbm;
		lbm = kg / lbmToKg(1);
		return lbm;

	}

	public double kgToGram(double kg){

		double gram;
		gram = kg * 1000.0;
		return gram;

	}


	public double gramToKg(double gram){

		double kg;
		kg = gram / kgToGram(1);
		return kg;
	}

	// time conversion
	
	public double secondsToHr(double seconds){

		double hr;
		hr = seconds / 3600.0;
		return hr;
	}

	public double hrToSeconds(double hr){

		double seconds;
		seconds = hr / secondsToHr(1);
		return seconds;
		
	}

	// length conversion
	// (not doing this yet)
	

	// temperature conversion
	//
	
	public double fToC(double tempF){

		double tempC;
		tempC = (tempF-32.0)*5.0/9.0;
		return tempF;

	}

	public double cToF(double tempC){

		double tempF;
		tempF = (tempC*9.0/5.0)+32.0;
		return tempF;

	}
}

// now we need to use the interface UnitConversion.Models.IBaseConversion
//
// but since that interface is already in the same namespace, we can
// use it right away




public class ComplexEnergyConversion : IEnergyConversion{

	private readonly double specificHeatH2OSI;

	// for dependency injection, we use interface as in place of classes
	

	private readonly IBaseUnitConversion _baseUnitConversion;

	
	public ComplexEnergyConversion(IBaseUnitConversion baseUnitConversion){

		specificHeatH2OSI = 4184;
		// this is in joules per kg per degC

		_baseUnitConversion = baseUnitConversion;

	}

	private double oneBtuInJoules(){

		// 1 btu = energy req to heat 1 lbm water 1 degF
		// first let's calculate 1 lbm of water in kg
		// and one degree fahrenheit in degree celsius
		
		double oneLbmInKg = _baseUnitConversion.lbmToKg(1);

		double oneFInC = 5.0/9.0;

		double oneBtuInJoules = specificHeatH2OSI * oneLbmInKg * oneFInC;

		return oneBtuInJoules;
	}


	
	public double btuToJoule(double btu){

		double joule;
		joule = btu*oneBtuInJoules();
		return joule;

	}

	public double jouleToBtu(double joule){

		double btu;
		btu = joule/oneBtuInJoules();
		return btu;

	}

	private double oneKcalInJoules(){

		// 1 cal = energy req to heat 1 kg water 1 degC
		//
		//
		double oneCalInJoules = specificHeatH2OSI*1.0*1.0;
		double oneKcalInJoules = 1.0/1000.0 * oneCalInJoules;


		return oneKcalInJoules;
	}

	public double jouleToKcal(double joule){		

		double kcal;
		kcal = joule/oneKcalInJoules();
		return kcal;

	}

	public double kcalToJoule(double kcal){

		double joule;
		joule = kcal*oneKcalInJoules();
		return joule;
	}

}
