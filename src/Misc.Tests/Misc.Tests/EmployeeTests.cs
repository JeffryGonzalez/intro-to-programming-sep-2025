

using System.Text;
using Misc.Domain;

namespace Misc.Tests;
public class EmployeeTests
{
    [Fact]
    public void DoingStuffWithEmployes()
    {
        var bob = new Employee();
        var sue = new Employee();

        Assert.Equal(0, bob.GetSalary());
        Assert.Equal(0, sue.GetSalary());
        bob.GiveRaise(1000);
        bob.GiveRaise(500);

        Assert.Equal(1500, bob.GetSalary());
        Assert.Equal(0, sue.GetSalary());

        sue = bob; // = is not "equal" in C#. It is ASSIGNMENT.
        // note: == is "equals"

        sue.GiveRaise(100000);

        Assert.Equal(101500, bob.GetSalary());

    }

    [Fact]
    public void ValueTypesWorkTheSameWayButDontSeemLikeItMaybe()
    {
        int myAge = 55;

        int yourAge = 24;

        myAge++;

        Assert.Equal(56, myAge);
        Assert.Equal(24, yourAge);


        myAge = yourAge;

        yourAge++;

        Assert.Equal(24, myAge);
        Assert.Equal(25, yourAge);

    }

    [Fact]

    public void Strings()
    {
        // In terms of assignment, strings act like value types 
        // they do this be overloading the assignment operator.

        var myName = "Jeff";
        var yourName = "Sam";

      

        Assert.Equal("Jeff", myName);
        Assert.Equal("Sam", yourName);

        myName = yourName;

        myName = "Putintane";

        Assert.Equal("Sam", yourName);

      
    }

    [Fact(Skip ="Bad Code")]
    public void BigOleString()
    {
        var numbers = "";
        foreach(var n in Enumerable.Range(1, 100_000))
        {
            numbers += n;
        }

        Assert.Equal("dog", numbers);
    }
    [Fact]
    public void StringBuilding()
    {
        var numbers = new StringBuilder();
        foreach (var n in Enumerable.Range(1, 100_000))
        {
            numbers.Append(n);
        }

        Assert.StartsWith("123456789", numbers.ToString());
    }

    [Fact]
    public void InnieOutie()
    {
        var emp = new Employee();
        var currentSalary = 100000M;
        var d = emp.ProjectSalaryWithIncrease(currentSalary, .25M);

        Assert.Equal(25000, d);

        Assert.Equal(100000, currentSalary);
    }

    [Fact(Skip = "bummer")]
    public void Swaparoo()
    {
        int a = 10;
        int b = 99;

        Swapper.Swap<int>(ref a, ref b);
        Assert.Equal(99, a);
        Assert.Equal(10, b);


        decimal myPay = 32.23M;
        decimal yourPay = 18.23M;
       
        Swapper.Swap<decimal>(ref myPay, ref yourPay);
        Assert.Equal(999.99M, myPay);

    }

    [Fact]
    public void Converting()
    {

        var numbers = "99.99";

        if (decimal.TryParse(numbers, out decimal number))
        {
            Assert.Equal(99.99M, number);

        }
        else
        {
            Assert.Fail("Not a decimal");
        }
    }

    [Fact]
    public void UsingProperties()
    {
        var emp = new Employee();
        emp.Name = "Bob"; // this will call the "set" block
        Assert.Equal("Bob", emp.Name); // this will call the "get"

        emp.MakeDeposit(300);
        Assert.Equal(300M, emp.Balance);
                                       
    }

    [Fact]
    public void SideEffectsAreBad()
    {
        var sue = new Employee();
        sue.EmailAddress = "sue@aol.com";
        sue.GiveRaise(3000);

        var marketing = new Marketing();
        var note = "Good Job! You Rock!";
        var x = 12;
        marketing.SendEmailToEmployeeWithThanks(sue, note, x);

        Assert.Equal("Good Job! You Rock!", note);
        Assert.Equal(12, x); 
        Assert.Equal("sue@aol.com", sue.EmailAddress);
        Assert.Equal(3000, sue.GetSalary());

    }

}
