using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// here i load in DataModels for Temp Conversion


// here i load in my IEnergyConversion and IBaseConversion classes
// or more correctly, interfaces

using UnitConversion.Models;

namespace UnitConversion{

	class TempConversion : ITemperatureConverter{

		public double cToF(double tempC, int decPlaces = 2 ){

			double tempF;

			tempF = 9.0/5.0*tempC + 32.0;

			tempF = Math.Round(tempF,decPlaces);

			return tempF;

		}

		public double fToC(double tempF, int decPlaces = 2){

			double tempC;

			tempC = (tempF - 32.0)* 5.0/9.0;

			tempC = Math.Round(tempC,decPlaces);
			
			return tempC;

		}

	}

	public struct TempObject{

		public double temperature;

		public string unit;

		public TempObject(){

			temperature = 273;
			unit = "kelvin";
		}

		public double getTemperature(){
			return temperature;
		}


		public string getUnit(){
			return unit;
		}

		public void setTemperature(double tempInput){

			temperature = tempInput;

		}

		public void setUnit(string unitInput){

			unit = unitInput;

		}

	}


	// here is a energy and power conversion class, wherein i will attempt to demonstrate dependency injection
	// using interfaces and class implementations
	//
	// the power conversion class will be dependent on energy conversion class and time conversion class 
	// so i will need to use those namespaces
	//
	//
	
	
	class PowerConversion : IPowerConverter{

		// we will try watt to kilocalorie, and back
		// joule to kWh and back
		//
		//
		// let's first begin with constructor injection
		//
		//
		private IEnergyConversion _energyConversion;

		private IBaseUnitConversion _baseUnitConversion;

		public PowerConversion(IEnergyConversion energyConversion,
				IBaseUnitConversion baseUnitConversion){

			_energyConversion = energyConversion;	
			_baseUnitConversion = baseUnitConversion;
		}


		public double btuPerHrToWatts(double btuPerHr){

			// first we know one watt is one joule per second
			// let's convert btu to watts first
			//

			double oneBtuInJoules = _energyConversion.btuToJoule(1);
			double oneHrInSeconds = _baseUnitConversion.hrToSeconds(1);

			// then 1 btu/hr is equal 
			// oneBtuInJoules/hr in joule/hr
			// = oneBtuInJoules/oneHrInSeconds watts
			//
			//

			double oneBtuPerHrInWatts = oneBtuInJoules/oneHrInSeconds;

			double watts;

			watts = btuPerHr * oneBtuPerHrInWatts;

			return watts;


		}

		public double wattsToBtuPerHr(double watts){

			double btuPerHr;

			btuPerHr = watts/btuPerHrToWatts(1);		

			return btuPerHr;
		

		}

		
		



	}





}
