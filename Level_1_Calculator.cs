using NUnit.Framework;
namespace gettingstarted;

public class Level_1_Calculator : ICalculator
{
    public int Add(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Subtract(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Multiply(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Divide(int a, int b)
    {
        throw new NotImplementedException();
    }

    public double Sqrt(int a)
    {
        throw new NotImplementedException();
    }

    public double Power(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Modulus(int a, int b)
    {
        throw new NotImplementedException();
    }

    public int Negate(int a)
    {
        throw new NotImplementedException();
    }

    public int Abs(int a)
    {
        throw new NotImplementedException();
    }
}


[TestFixture]
public class CalculatorTests
{
    ICalculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new Level_1_Calculator();
    }

    [Test]
    public void Add_ReturnsCorrectSum()
    {
        int result = calculator.Add(1, 2);
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Subtract_ReturnsCorrectDifference()
    {
        int result = calculator.Subtract(5, 3);
        Assert.AreEqual(2, result);
    }

    [Test]
    public void Multiply_ReturnsProduct()
    {
        int result = calculator.Multiply(3, 4);
        Assert.AreEqual(12, result);
    }

    [Test]
    public void Divide_ReturnsQuotient()
    {
        int result = calculator.Divide(10, 2);
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
    }

    [Test]
    public void Sqrt_ReturnsCorrectResult()
    {
        double result = calculator.Sqrt(16);
        Assert.AreEqual(4, result);
    }

    [Test]
    public void Sqrt_NegativeNumber_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Sqrt(-5));
    }

    [Test]
    public void Power_ReturnsCorrectResult()
    {
        double result = calculator.Power(2, 3);
        Assert.AreEqual(8, result);
    }

    [Test]
    public void Modulus_ReturnsCorrectResult()
    {
        int result = calculator.Modulus(10, 3);
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Negate_ReturnsCorrectResult()
    {
        int result = calculator.Negate(5);
        Assert.AreEqual(-5, result);
    }

    [Test]
    public void Abs_ReturnsCorrectResult()
    {
        int result = calculator.Abs(-5);
        Assert.AreEqual(5, result);
    }
}

public interface ICalculator
{
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    int Add(int a, int b);

    /// <summary>
    /// Subtracts the second integer from the first and returns the result.
    /// </summary>
    int Subtract(int a, int b);

    /// <summary>
    /// Multiplies two integers and returns the result.
    /// </summary>
    int Multiply(int a, int b);

    /// <summary>
    /// Divides the first integer by the second and returns the result.
    /// </summary>
    int Divide(int a, int b);

    /// <summary>
    /// Returns the square root of the given integer.
    /// Throws an ArgumentOutOfRangeException if the argument is a negative number.
    /// </summary>
    double Sqrt(int a);

    /// <summary>
    /// Raises the first integer to the power of the second integer and returns the result.
    /// </summary>
    double Power(int a, int b);

    /// <summary>
    /// Returns the modulus of the first integer divided by the second integer.
    /// </summary>
    int Modulus(int a, int b);

    /// <summary>
    /// Negates the provided integer and returns the result.
    /// </summary>
    int Negate(int a);

    /// <summary>
    /// Returns the absolute value of the given integer.
    /// </summary>
    int Abs(int a);
}