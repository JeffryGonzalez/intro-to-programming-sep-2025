

namespace Banking.Domain;
public struct TransactionAmount
{
    private decimal _amount;

    public TransactionAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidTransactionAmountException();
        }
        if (amount > 10_000M)
        {
            throw new TransactionAmountAboveLimitException();
        }
        _amount = amount;

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
