using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;

// here is the implementation, the behind the scenes stuff

public class SimpleBaseUnitConversion : IBaseUnitConversion
{

	public double lbmToKg(double lbm){

		double kg;
		kg = lbm / 2.20462;
		return kg;

	}

	public double kgToLbm(double kg){

		double lbm;
		lbm = kg * 2.20462;
		return lbm;

	}

	public double kgToGram(double kg){

		double gram;
		gram = kg * 1000.0;
		return gram;

	}


	public double gramToKg(double gram){

		double kg;
		kg = gram / 1000.0;
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
		seconds = hr * 3600.0;
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


public class SimpleEnergyConversion : IEnergyConversion{

	private readonly double specificHeatH2OSI;
	
	public SimpleEnergyConversion(){

		specificHeatH2OSI = 4.184;

	}

	
	public double btuToJoule(double btu){

		double joule;
		joule = btu*1055.0;
		return joule;

	}

	public double jouleToBtu(double joule){

		double btu;
		btu = joule/1055.0;
		return btu;

	}

	public double jouleToKcal(double joule){		

		double kcal;
		kcal = joule/4184.0;
		return kcal;

	}

	public double kcalToJoule(double kcal){

		double joule;
		joule = kcal*4184.0;
		return joule;
	}

}
