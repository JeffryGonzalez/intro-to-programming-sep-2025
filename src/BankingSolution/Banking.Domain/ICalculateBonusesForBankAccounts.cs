namespace Banking.Domain;

public interface ICalculateBonusesForBankAccount
{
    decimal GetBonusForDepositOn(decimal balance, TransactionAmount amountToDeposit);
}