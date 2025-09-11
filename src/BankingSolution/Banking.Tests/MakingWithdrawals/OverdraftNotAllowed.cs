

using Banking.Tests.TestDoubles;

namespace Banking.Tests.MakingWithdrawals;
[Trait("Category", "Unit")]
public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseYourBalance()
    {
        // Given I have an account with X balance
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        // When I withdraw X+1 from that account

        try
        {
            account.Withdraw(openingBalance + .01M);
        }
        catch
        {

            // I don't care what happened, or nothing happened, 
            // we just want to make sure that overdraft doesn't decrease the balance.
        }
        // Then the account still has a balance of X
        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void AnOverdraftExceptionIsProvided()
    {
        // Given I have an account with X balance
        var account = new BankAccount(new DummyBonusCalculator());

        var openingBalance = account.GetBalance();


        Assert.Throws<AccountOverdraftException>(() => account.Withdraw(openingBalance + .01M));

    }
}
