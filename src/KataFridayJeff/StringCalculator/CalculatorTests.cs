
namespace StringCalculator;

public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("319", 319)]
    public void SingleNumberReturnsValue(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("10,20", 30)]
    [InlineData("100,250", 350)]
    public void TwoNumbersCommaDelimitedReturnsSum(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("10,20,3,40", 73)]
    public void ArbitraryLength(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("10,20\n3,40", 73)]
    public void MixedDelimeters(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\n1#2", 3)]
    [InlineData("//#\n1#2,3", 6)]
    [InlineData("//;\n10;20;3;40", 73)]
    [InlineData("//a\n1a2a3", 6)]
    [InlineData("//z\n10z20,3\n40", 73)]

    public void CustomDelimeters(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,-2", "-2")]
    [InlineData("//;\n10;-20;3;-40", "-20, -40")]
    public void ThrowsOnNegativeNumbers(string input, string negatives)
    {
        var calculator = new Calculator();
        var exception = Assert.Throws<NegativeNumbersNotAllowedException>(() => calculator.Add(input));
        Assert.Equal(negatives, exception.Message);
    }

    [Theory]
    [InlineData("1001", 0)]
    [InlineData("2,1001", 2)]
    [InlineData("1000,1001", 1000)]
    [InlineData("//;\n1000;1001;2", 1002)]
    public void NumbersGreaterThan1000AreIgnored(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }
}
