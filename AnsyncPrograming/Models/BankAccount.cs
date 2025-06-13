namespace IngoProject.AsyncProgramming.Models;

public class BankAccount
{
    public int AccountId { get; set; }
    private decimal _balance;
    private readonly object _lock = new();

    public BankAccount(int accountId, decimal initialBalance)
    {
        AccountId = accountId;
        _balance = initialBalance;
    }
    public decimal GetBalance()
    {
        lock (_lock)
        {
            return _balance;
        }
    }
    public bool TryDebit(decimal amount)
    {
        lock (_lock)
        {
            if (amount <= 0 || amount > _balance)
            {
                return false; // Invalid amount or insufficient balance
            }
            _balance -= amount;
            return true; // Debit successful
        }
    }

    public void Credit(decimal amount)
    {
        lock (_lock)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }
            _balance += amount;
        }
    }
    
}
