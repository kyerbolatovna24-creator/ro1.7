using System;

class BankAccount
{
    public string Owner { get; }  // read-only
    public decimal Balance { get; private set; }  // readable outside, writable only inside

    public BankAccount(string owner, decimal initialDeposit)
    {
        if (initialDeposit < 0)
            throw new ArgumentException("Initial deposit cannot be negative");

        Owner = owner;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit must be positive");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal must be positive");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds");

        Balance -= amount;
    }

    public void PrintStatement()
    {
        Console.WriteLine($"Owner: {Owner}, Balance: {Balance}");
    }
}
class Program
{
    static void Main()
    {
        var acc = new BankAccount("Alice", 100m);

        acc.Deposit(50m);
        acc.Withdraw(30m);

        try
        {
            acc.Withdraw(1000m); // should throw
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // acc.Balance = 9999m; 
        // ❌ Compile error: Balance has a private setter,
        // so it cannot be assigned from outside the class.

        acc.PrintStatement();
    }
}