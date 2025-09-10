

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
    [InlineData("3", 3)]
    [InlineData("120", 120)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("108,2", 110)]
    [InlineData("1,1008", 1009)]

    public void TwoNumbers(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void Arbitrary(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2\n3", 6)]
   

    public void Mixed(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
}
