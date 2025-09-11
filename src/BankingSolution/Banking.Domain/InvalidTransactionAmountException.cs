

namespace Banking.Domain;
public class InvalidTransactionAmountException : ArgumentOutOfRangeException;



public class TransactionAmountAboveLimitException: InvalidTransactionAmountException;