using Microsoft.AspNetCore.Mvc;

// this is the csLibrary we need to import
using csLibrary;

// this is the vbLibrary we need to import (root namespace)
using vbLibrary;

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



public class MathVbLib : IMath
{

	public vbLibMath vbLib = new vbLibMath();


	public double addition(double x){

		double y;

		y = this.vbLib.addTwo(x);

		return y;

	}
}
