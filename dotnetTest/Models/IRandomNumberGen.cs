using Microsoft.AspNetCore.Mvc;


namespace UnitConversion.Models.RNG;


public interface IRNG
{
        double Value { get; set; }
}

public interface IRNGTransient
{
        double Value { get; set; }
}
public interface IRNGScoped
{
        double Value { get; set; }
}
public interface IRNGSingleton
{
        double Value { get; set; }
}