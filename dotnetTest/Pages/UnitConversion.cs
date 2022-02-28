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

	struct TempObject{

		double temperature;

		string unit;

		public TempObject(){

			temperature = 273;
			unit = "kelvin";
		}

		double getTemperature(){
			return temperature;
		}


		string getUnit(){
			return unit;
		}

		void setTemperature(double tempInput){

			temperature = tempInput;

		}

		void setUnit(string unitInput){

			unit = unitInput;

		}

	}

}
