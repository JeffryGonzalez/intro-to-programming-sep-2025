


namespace Banking.Domain;

// An object owns some data and the transformations associated with that data.
// Sound like a service? yep..
public class BankAccount
{
    private decimal balance = 5000M; // Fields
    public void Deposit(decimal amountToDeposit)
    {
        balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
    
        return balance; // "Slime" 
    }

    public void Withdraw(decimal amountToWithdraw)
    {
       balance -= amountToWithdraw;
    }
}

