


using Banking.Tests.TestDoubles;

namespace Banking.Tests.MakingDeposits;
    [Trait("Category", "Unit")]
public class DepositsIncreaseBalance
{

    [Theory]
    [InlineData(110.10)]
    [InlineData(0.25)]

    public void MakingADeposit(decimal amountToDeposit)
    {
        // Given 
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
     

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }

  
}
