

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

    [Fact]
    public void MayWithdrawFullBalance()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance);

        Assert.Equal(0, account.GetBalance());
    }
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void InvalidAmountsCannotBeWithdrawan(decimal amountToDeposit)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        Assert.Throws<InvalidTransactionAmountException>(() => account.Withdraw(amountToDeposit));

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
