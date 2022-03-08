using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;


public class Data : IData
{


        public string Name { get; set; }

        public double Value { get; set; }

        public string Unit { get; set; }



}

