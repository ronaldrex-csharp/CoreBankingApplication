using Microsoft.EntityFrameworkCore;
using CoreBankingApplication.Domain.Entities;

namespace CoreBankingApplication.Infrastructure.Data;

public class BankingDbContext : DbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> options)
        : base(options)
    {
    }

    public DbSet<BankAccount> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Customer> Customers { get; set; }
}