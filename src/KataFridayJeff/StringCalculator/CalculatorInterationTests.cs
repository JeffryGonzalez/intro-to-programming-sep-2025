

namespace StringCalculator;
public class CalculatorInterationTests
{

    [Theory]
    [InlineData("1,2,3")]
    [InlineData("22")]
    public void CalculatorLogs(string numbers)
    {
        // Given
        var mockedLogger = Substitute.For<ILogger>();
        var calculator = new Calculator(mockedLogger, Substitute.For<IProvideFailureNotifications>());

        // When
        var response = calculator.Add(numbers);

        // Then
        // I don't have to "check the math" on the response. 
        // hey logger, did your log method get called with a string of response.
        mockedLogger.Received(1).LogCalculation(response.ToString());
    }

    [Theory]
    [InlineData("99")]
    public void AWebServiceIsCalledIfTheLoggerFails(string numbers)
    {
        // a test double for the logger that will a "stub" that will just throw
        var stubbedLogger = Substitute.For<ILogger>();

        stubbedLogger
            .When(l => l.LogCalculation(Arg.Any<string>()))
            .Throw(new IndexOutOfRangeException());
        // a test double for the notification thing that will record it's interactions
        var mockedApi = Substitute.For<IProvideFailureNotifications>();
        var calculator = new Calculator(stubbedLogger, mockedApi);
        var response = calculator.Add(numbers);

        mockedApi.Received().NotifyOfLoggingFailure(response.ToString());
    }

    [Fact]
    public void ApiIsOnlyCalledOnExceptions()
    {

        var dummyLogger = Substitute.For<ILogger>();
        var mockedApi = Substitute.For<IProvideFailureNotifications>();
        var calculator = new Calculator(dummyLogger, mockedApi);

        calculator.Add("1,2");

        mockedApi.DidNotReceive().NotifyOfLoggingFailure(Arg.Any<string>());

    }



}
