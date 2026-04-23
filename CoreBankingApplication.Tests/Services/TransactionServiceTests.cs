using CoreBankingApplication.Domain.Entities;
using CoreBankingApplication.Infrastructure.Data;
using CoreBankingApplication.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

public class TransactionServiceTests
{
    private BankingDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<BankingDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new BankingDbContext(options);
    }

    [Fact]
    public async Task Deposit_Should_Increase_Balance()
    {
        // Arrange
        var context = GetDbContext();

        var account = new BankAccount
        {
            Id = 1,
            Balance = 100m
        };

        context.Accounts.Add(account);
        await context.SaveChangesAsync();

        var options = new DbContextOptionsBuilder<BankingDbContext>()
        .UseSqlite("Data Source=:memory:") // in-memory SQLite for testing
        .Options;

        var factory = new PooledDbContextFactory<BankingDbContext>(options);

        var service = new TransactionService(factory);



        // Act
        await service.CreateTransactionAsync(1, 50m, true);

        var updated = await context.Accounts.FirstAsync();

        // Assert
        Assert.Equal(150m, updated.Balance);
    }
}