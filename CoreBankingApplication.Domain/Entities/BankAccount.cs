using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Domain.Entities;

public class BankAccount
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public  BankAccountType bankAccountType { get; set; }
    public decimal Balance { get; set; } = 0m;

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

public enum BankAccountType 
{
    Checking,
    Savings
}