using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models;

// here's an interface for some of our data models
// we can use databases later

public interface IData{

        string Name { get; set; }

        double Value { get; set; }

        string Unit { get; set; }
}

