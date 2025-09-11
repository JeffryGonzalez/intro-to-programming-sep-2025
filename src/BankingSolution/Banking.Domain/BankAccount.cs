


namespace Banking.Domain;

// An object owns some data and the transformations associated with that data.
// Sound like a service? yep..
public class BankAccount(ICalculateBonusesForBankAccount bonusCalculator)
{
    private decimal balance = 5000M; // Fields
    public virtual void Deposit(TransactionAmount amountToDeposit)
    {
     

       decimal bonus = bonusCalculator.GetBonusForDepositOn( balance, amountToDeposit);
        balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
    
        return balance; // "Slime" 
    }

    public void Withdraw(TransactionAmount amountToWithdraw)
    {
       
        if (amountToWithdraw <= balance)
        {
            balance -= amountToWithdraw;
        } else
        {
            throw new AccountOverdraftException();
        }
    }
}
