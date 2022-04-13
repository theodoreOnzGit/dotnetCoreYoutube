using Microsoft.AspNetCore.Mvc;


public class CsLibCalcFns : ICalcFns
{
	public csClassLib.Class1 csClassLib;


	public CsLibCalcFns(){

		this.csClassLib = new csClassLib.Class1();
	}

	public double addTwo(double x){

		double y;

		y = this.csClassLib.additionBy2(x);

		return y;
	}

}

public class VbLibCalcFns : ICalcFns
{
	public double addTwo(double x){

		double y;

		return 0;
	}
}
