

using BankAccountErrors = Banking.Domain.DomainExceptions;

namespace Banking.Domain;
public struct TransactionAmount
{
    private decimal _amount;

    public TransactionAmount(decimal amount)
    {
        if (IsNotPositiveAmount(amount))
        {
            throw new BankAccountErrors.InvalidTransactionAmountException();
        }
        if (IsAboveThreshold(amount))
        {
            throw new BankAccountErrors.TransactionAmountAboveLimitException();
        }
        _amount = amount;

    }

    private static bool IsAboveThreshold(decimal amount)
    {
        return amount > 10_000M; // must come into the bank to do this much
    }

    private static bool IsNotPositiveAmount(decimal amount)
    {
        return amount <= 0;
    }

    // this allows an "implict" converstion from TransactionAmount to a decimal.
    // so: decimal x = t; 
    public static implicit operator decimal(TransactionAmount tx)
    {
        return tx._amount;
    }

    public static implicit operator TransactionAmount(decimal val)
    {
        return new TransactionAmount(val);
    }
}
