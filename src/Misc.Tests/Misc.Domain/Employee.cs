

namespace Misc.Domain;
// public - anywhere, including other assemblies (projects) that have a reference to this.
// internal - just within this assembly - other types in here can use this, but not outside.
// private* - but this is mostly for "nested" classes.

public class Employee : IProvideEmployeeInformation
{
    // State and Behavior of any instances of this class.
    private decimal salary = 0;

    //private string name = ""; // backing private field

    //public string Name // properties.
    //{
    //    get { return name; } // var x = emp.Name;
    //    set { name = value; } // emp.Name = "Bob";
    //}
    // "Auto Property"
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;


    public decimal Balance { get; private set; }

    public void MakeDeposit(decimal amount)
    {
        Balance += amount;
    }

    public decimal GetSalary()
    {

        return salary;
    }

    public void GiveRaise(decimal amount)
    {
        this.salary += amount;
    }

    public decimal ProjectSalaryWithIncrease(
        decimal currentSalary,
        decimal percentOfIncrease)
    {
        currentSalary = currentSalary * percentOfIncrease;
        return currentSalary;
    }


}

public static class Swapper
{
    public static void Swap<T>(ref T a,ref T b)
    {
        T temp = a;
        a = b; b = temp;
       
    }
   
}