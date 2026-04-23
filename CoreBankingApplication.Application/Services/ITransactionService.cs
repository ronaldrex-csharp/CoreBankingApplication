using CoreBankingApplication.Application.Common;
using CoreBankingApplication.Application.ViewModels;
using CoreBankingApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Transaction service interface defining methods for managing transactions, including creation and retrieval 
/// of transaction history for bank accounts.

namespace CoreBankingApplication.Application.Services
{
    public interface ITransactionService
    {
        //Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId);
        //Task<Transaction> CreateTransactionAsync(int accountId, decimal amount, bool isDeposit);
        Task CreateTransactionAsync(int accountId, decimal amount, bool isDeposit);
        Task<PagedResult<TransactionListItemViewModel>> GetTransactionsAsync(
                     int accountId,
                     int pageNumber,
                     int pageSize,
                     bool sortDescending);
    }
}
