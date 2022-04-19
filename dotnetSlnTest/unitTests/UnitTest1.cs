using Xunit;
using dwsimLibs;

namespace unitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }

	[Theory]
	[InlineData(1,0,-4,2,-2)]
	[InlineData(1,0,-4,-2,2)]
	public void Quadratic_TestShouldCalculate(double a, double b, double c, double expectedRoot1, double expectedRoot2){

		//Arrange (means it set up the variables here)
		// first i need the root namespace
		// the root namespace is dwsimLibs
		// the class is Quadratic

		Quadratic testObj = new Quadratic();
		System.Tuple<double,double> expectedTuple;
		expectedTuple = new System.Tuple<double,double>(expectedRoot1,expectedRoot2);

		System.Tuple<double, double> actualResult;

		// Act

		actualResult = Quadratic.quadForm(a,b,c);
		

		// Assert
		// examples here
		// https://github.com/xunit/xunit/blob/4415ae1a1f2afc1d4e36432f26b837ddea5f66a3/src/xunit.v3.assert.tests/Asserts/CollectionAssertsTests.cs



		Assert.Equal(expectedTuple,actualResult);

		

	}
}
