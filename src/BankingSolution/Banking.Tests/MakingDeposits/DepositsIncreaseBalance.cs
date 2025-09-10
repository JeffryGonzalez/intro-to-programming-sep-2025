

using Banking.Domain;

namespace Banking.Tests.MakingDeposits;
public class DepositsIncreaseBalance
{
    [Theory]
    [InlineData(110.10)]
    [InlineData(0.25)]
    [Trait("Category", "Unit")]
    public void MakingADeposit(decimal amountToDeposit)
    {
        // Given 
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
     

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
