

using Banking.Domain;

namespace Banking.Tests.NewAccounts;
[Trait("Category", "Unit")]
public class HaveCorrectBalance
{
    [Fact]
    public void CorrectBalanceForNewAccounts()
    {
        // WTCYWYH - WRITE THE CODE YOU WISH YOU HAD.
        // Given I have a new bank account
        var account = new BankAccount();
        
        // When I ask that account for the balance
        decimal balance = account.GetBalance();

        // Then it should be ... 

        Assert.Equal(5000M, balance);


    }
}
