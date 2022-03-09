using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;


public class Data : IData
{


        public string Name { get; set; }

        public double Value { get; set; }

        public string Unit { get; set; }

	// We have a constructor to initialise some values
	//
	public Data(){

		Name = "please enter name";
		Value = 0.0;
		Unit = "please enter unit";

	}



}

