using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// here i load in DataModels for Temp Conversion


using Razor_Form_Submit.Models;

// here i load in my IEnergyConversion and IBaseConversion classes
// or more correctly, interfaces

using UnitConversion.Models;

namespace UnitConversion{

	public interface ITemperatureConverter{

		public double cToF(double tempC, int decPlaces );

		public double fToC(double tempF, int decPlaces );
	}
	
	public interface IPowerConverter{

		public double btuPerHrToWatts(double btuPerHr);

		public double wattsToBtuPerHr(double watts);


	}


}
