using Microsoft.AspNetCore.Mvc;

// this is the csLibrary we need to import
using csLibrary;

namespace dotnetTest.Models;

public class MathCsLib : IMath
{

	public csLibMath csLib = new csLibMath();


	public double addition(double x){

		double y;

		y = this.csLib.addTwo(x);

		return y;

	}
}
