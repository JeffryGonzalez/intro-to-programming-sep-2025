
public class Calculator
{

    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }

        return numbers
            .Split(',', '\n') // ["1", "2", "3"]
            .Select(int.Parse) // [1,2,3]
            .Sum();
    }

}
