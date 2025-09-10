
namespace StringCalculator;
public class LinqStuff
{
    [Fact]
    public void TimeTravel()
    {
        // generics provide "parametric polymorphism"
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var onlyTheEvens = numbers.Where(n => n % 2 == 0);

        numbers[0] = 8; // lazy evaluation, "homoiconicity" 

        Assert.Equal(4, onlyTheEvens.Count());
    }
}
