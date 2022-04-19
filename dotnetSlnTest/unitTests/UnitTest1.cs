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


		// now, assert equal of the tuples means
		// that the quadratic roots must come in exactly the same
		// order in order to be right
		// this is too restrictive for this quadratic calculator
		// i don't really care if the tuples are in one or the other
		// order

		// so i'm going to design the test such that
		// if it's in the correct order, pass the thing


		if(expectedTuple.Item1 == actualResult.Item1){

			Assert.Equal(expectedTuple,actualResult);

		}
		else if (expectedTuple != actualResult){
			// if it's not equal, then check if inverting the order works

			System.Tuple<double,double> invertedExpectedTuple;
			invertedExpectedTuple = new System.Tuple<double,double>(expectedRoot2,expectedRoot1);

			Assert.Equal(invertedExpectedTuple,actualResult);
			return;
		}



		

	}
}
