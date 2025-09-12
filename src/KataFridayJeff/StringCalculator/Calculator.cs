
public class Calculator
{
    public int Add(string numbers)
    {
        var delimeters = new List<char> { ',', '\n' };
        if (numbers == "") { return 0; }
        if (numbers.StartsWith("//"))
        {
            delimeters.Add(numbers[2]);
            numbers = numbers[4..];
        }
        var results = numbers.Split(delimeters.ToArray()).Select(int.Parse);
        if (results.Any(n => n < 0))
        {
            throw new NegativeNumbersNotAllowedException(string.Join(", ", results.Where(n => n < 0)));
        }
        return results
        .Where(n => n <= 1000)
        .Sum();
    }
}

public class NegativeNumbersNotAllowedException : Exception
{
    public NegativeNumbersNotAllowedException(string message) : base(message) { }
}