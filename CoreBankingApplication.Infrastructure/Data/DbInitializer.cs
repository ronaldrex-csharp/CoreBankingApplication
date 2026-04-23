using CoreBankingApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreBankingApplication.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(BankingDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (await context.Accounts.AnyAsync())
            return;

        // Customers
        var customer1 = new Customer
        {
            FullName = "John Doe"
        };

        var customer2 = new Customer
        {
            FullName = "Jane Smith"
        };

        context.Customers.AddRange(customer1, customer2);
        await context.SaveChangesAsync();

        // Accounts
        var account1 = new BankAccount
        {
            Name = "Checking",
            AccountNumber = "111122223333",
            Balance = 1000,
            CustomerId = customer1.Id
        };

        var account2 = new BankAccount
        {
            Name = "Savings",
            AccountNumber = "444455556666",
            Balance = 2500,
            CustomerId = customer2.Id
        };

        context.Accounts.AddRange(account1, account2);

        await context.SaveChangesAsync();
    }
}