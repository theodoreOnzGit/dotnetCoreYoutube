using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

public class Component
{
	public int Id { get; set; }

	public string name { get; set; }

	public string componentType { get; set; }

	public double temperatureC { get; set; }

	public double pressurePa { get; set; }

	public double massFlowrateKgPerS { get; set; }
}
