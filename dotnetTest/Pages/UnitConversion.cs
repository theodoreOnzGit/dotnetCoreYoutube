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

		public double fToC(double tempF, int decPlaces){

			double tempC;

			tempC = (tempF - 32.0) * 5.0/9.0;

			tempC = Math.Round(tempC,decPlaces);

			return tempC;

		}


	}

}
