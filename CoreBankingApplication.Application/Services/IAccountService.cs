using CoreBankingApplication.Domain.Entities;
using CoreBankingApplication.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CoreBankingApplication.Application.Services
{
    
    /// <summary>
    /// Defines methods for managing and retrieving bank account information.
    /// </summary>
    /// <remarks>Implementations of this interface provide asynchronous operations for listing, retrieving,
    /// creating, and updating bank accounts. Methods may return null if the specified account is not found. All
    /// operations are asynchronous and should be awaited to avoid blocking the calling thread.</remarks>
    public interface IAccountService
    {
        Task<List<AccountListItemViewModel>> GetAccountListAsync();
        Task<BankAccount?> GetAccountByIdAsync(int id);
        Task<BankAccountViewModel?> GetBankAccountViewModelByIdAsync(int id);
        Task<BankAccount> CreateAccountAsync(BankAccount account);
        Task UpdateAccountAsync(BankAccount account);
    }
}
