using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;

// note: the I in front of BaseUnitConversion stands for interface
// interface is just shows inputs and outputs you need for each function
// in the class

public interface IBaseUnitConversion
{
	// this class is only 

	// mass conversion
	
	double lbmToKg(double lbm);
	double kgToLbm(double kg);

	double kgToGram(double kg);
	double gramToKg(double gram);

	// time conversion
	
	double secondsToHr(double seconds);
	double hrToSeconds(double hr);

	// length conversion
	// (not doing this yet)
	

	// temperature conversion
	//
	
	double fToC(double tempF);
	double cToF(double tempC);
}

public interface IEnergyConversion{

	double btuToJoule(double btu);
	double jouleToBtu(double joule);

	double jouleToKcal(double joule);
	double kcalToJoule(double kcal);

}
