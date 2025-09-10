

using Banking.Domain;

namespace Banking.Tests.MakingWithdrawals;

[Trait("Category", "Unit")]
public class WithdrawalsDecreasesBalance
{
    [Theory]
    [InlineData(110.00)]
    [InlineData(50)]

    public void Withdrawing(decimal amountToWithdraw)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        
        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance -  amountToWithdraw, account.GetBalance());
    }
}
