
namespace Banking.Tests.TestDoubles;
public class DummyBonusCalculator : ICalculateBonusesForBankAccount
{
    public decimal GetBonusForDepositOn(decimal balance, TransactionAmount amountToDeposit)
    {
        
        return 0; 
    }
}
