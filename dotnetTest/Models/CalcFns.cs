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
	public vbClassLib.myClass1 vbClassLib1;

	public VbLibCalcFns(){

		this.vbClassLib1 = new vbClassLib.myClass1();
	}


	public double addTwo(double x){

		double y;

		y = this.vbClassLib1.AddTwo(x);


		return y;
	}
}
