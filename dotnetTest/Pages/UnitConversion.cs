using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConversion{

	class TempConversion{

		public double cToF(double tempC, int decPlaces){

			double tempF;

			tempF = 9.0/5.0*tempC + 32.0;

			tempF = Math.Round(tempF,decPlaces);

			return tempF;

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

}
