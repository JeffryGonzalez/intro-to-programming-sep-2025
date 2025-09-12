
using StringCalculator.Helpers;

public class Calculator(ILogger logger, IProvideFailureNotifications notificationApi)
{
    public int Add(string numbers)
    {
        // Fewest Elements - variables, loops, and if statements.
        // Variables - names for things that VARY - that change.
        // constant - an immutable - never changes.
        var delimeters = new List<char> { ',', '\n' };
        if (numbers.IsEmptyString()) { return 0; }



        if (numbers.HasACustomDelimeter())
        {
            delimeters.Add(numbers[2]);
            numbers = numbers[4..]; // reassigning to a variable.
        }
        var results = numbers.Split(delimeters.ToArray()).Select(int.Parse);
        if (results.Any(n => n < 0))
        {
            throw new NegativeNumbersNotAllowedException(string.Join(", ", results.Where(n => n < 0)));
        }
        var final = results
        .Where(n => n <= 1000)
        .Sum();

        // TODO: Write this to a logging service
        try
        {
            logger.LogCalculation(final.ToString());
        }
        catch (IndexOutOfRangeException)
        {

            notificationApi.NotifyOfLoggingFailure(final.ToString());
        }

        return final;
    }




}

public class NegativeNumbersNotAllowedException : Exception
{
    public NegativeNumbersNotAllowedException(string message) : base(message) { }
}


public interface ILogger
{
    void LogCalculation(string message);
}

public interface IProvideFailureNotifications
{
    void NotifyOfLoggingFailure(string message);
}