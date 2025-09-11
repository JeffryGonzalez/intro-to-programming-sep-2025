

using Banking.Domain;

namespace Banking.Tests;
public class TransactionAmountTests
{
    [Theory]
    [InlineData(120.23)]
    [InlineData(0.01)]
    public void ValidTransactionAmounts(decimal amount)
    {
        new TransactionAmount(amount);

    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.01)]
    public void InvalidTransactionAmounts(decimal amount)
    {
        Assert.Throws<InvalidTransactionAmountException>(() => new TransactionAmount(amount));
    }
}
