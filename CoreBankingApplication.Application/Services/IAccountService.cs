using CoreBankingApplication.Domain.Entities;
using CoreBankingApplication.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CoreBankingApplication.Application.Services
{
    public interface IAccountService
    {
        Task<List<AccountListItemViewModel>> GetAccountListAsync();
        Task<BankAccount?> GetAccountByIdAsync(int id);
        Task<BankAccountViewModel?> GetBankAccountViewModelByIdAsync(int id);
        Task<BankAccount> CreateAccountAsync(BankAccount account);
        Task UpdateAccountAsync(BankAccount account);
    }
}
