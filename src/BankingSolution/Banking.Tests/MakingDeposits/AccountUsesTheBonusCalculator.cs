

using Banking.Tests.TestDoubles;

namespace Banking.Tests.MakingDeposits;
public class AccountUsesTheBonusCalculator
{
    [Fact]
    public void BankAccountUsesTheBonusCalculator()
    {
        // Given
        var stubbedBonusCalculator = Substitute.For<ICalculateBonusesForBankAccount>();
        var account = new BankAccount(stubbedBonusCalculator);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 523.25M;
        stubbedBonusCalculator.GetBonusForDepositOn(openingBalance, amountToDeposit).Returns(420.69M);
        // When
       
        account.Deposit(amountToDeposit);

        // Then
        // ?? 
        var amountExpected = openingBalance + amountToDeposit + 420.69M;
        Assert.Equal(amountExpected, account.GetBalance());

        
    }

}
