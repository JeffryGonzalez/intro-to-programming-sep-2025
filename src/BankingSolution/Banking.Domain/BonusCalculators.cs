

namespace Banking.Domain;
public class BonusCalculators : ICalculateBonusesForBankAccount
{
    // a whole bunch of Emily weird and complex functionality based on decades of research
    // this class OWNS the idea of bonus calculation in the bank.
    // It might do things like calculate bonuses for certificates of deposits, savings accounts, IRAs, etc.
    // It's her box of tricks.
    public decimal GetBonusForDepositOn(decimal balance, TransactionAmount amountToDeposit)
    {
        return balance >= 5000M ? amountToDeposit * .12M : 0;
    }
}
