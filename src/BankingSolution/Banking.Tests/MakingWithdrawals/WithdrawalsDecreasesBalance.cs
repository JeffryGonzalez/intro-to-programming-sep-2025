



using Banking.Tests.TestDoubles;

namespace Banking.Tests.MakingWithdrawals;

[Trait("Category", "Unit")]
public class WithdrawalsDecreasesBalance
{
    [Theory]
    [InlineData(110.00)]
    [InlineData(50)]
    public void Withdrawing(decimal amountToWithdraw)
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        
        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance -  amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void MayWithdrawFullBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance);

        Assert.Equal(0, account.GetBalance());
    }
  
}


