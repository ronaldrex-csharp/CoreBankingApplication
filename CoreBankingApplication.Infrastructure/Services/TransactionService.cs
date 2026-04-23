using CoreBankingApplication.Application.Common;
using CoreBankingApplication.Application.Services;
using CoreBankingApplication.Application.ViewModels;
using CoreBankingApplication.Domain.Entities;
using CoreBankingApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBankingApplication.Infrastructure.Services;

public class TransactionService : ITransactionService
{
    private readonly IDbContextFactory<BankingDbContext> _factory;

    public TransactionService(IDbContextFactory<BankingDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<PagedResult<TransactionListItemViewModel>> GetTransactionsAsync(
        int accountId,
        int pageNumber,
        int pageSize,
        bool sortDescending)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var query = context.Transactions
            .AsNoTracking()
            .Where(t => t.AccountId == accountId);

        query = sortDescending
            ? query.OrderByDescending(t => t.Amount)
            : query.OrderBy(t => t.Amount);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(t => new TransactionListItemViewModel
            {
                Id = t.Id,
                Amount = t.Amount,
                Date = t.Date,
                Type = t.transactionType.ToString()
            })
            .ToListAsync();

        return new PagedResult<TransactionListItemViewModel>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task CreateTransactionAsync(int accountId, decimal amount, bool isDeposit)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var account = await context.Accounts
            .FirstOrDefaultAsync(a => a.Id == accountId);

        if (account == null)
            throw new InvalidOperationException("Account not found.");

        if (!isDeposit && account.Balance < amount)
            throw new InvalidOperationException("Insufficient funds.");

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Date = DateTime.UtcNow,
            transactionType = isDeposit
                ? TransactionType.Deposit
                : TransactionType.Withdrawal
        };

        if (isDeposit)
            account.Balance += amount;
        else
            account.Balance -= amount;

        context.Transactions.Add(transaction);

        await context.SaveChangesAsync();
    }
}