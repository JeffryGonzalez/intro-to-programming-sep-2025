

namespace StringCalculator.Helpers;
public static class CalculatorExtensions
{
    public static bool HasACustomDelimeter(this string numbers)
    {
        return numbers.StartsWith("//");
    }
    public static bool IsEmptyString(this string numbers)
    {
        return numbers == "";
    }

}
