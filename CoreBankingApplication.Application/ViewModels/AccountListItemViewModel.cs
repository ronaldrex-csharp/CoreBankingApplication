using CoreBankingApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Application.ViewModels;
/// <summary>
/// Model representing a bank account item in a list, containing essential information such as account ID, customer name, masked account number, balance, and status
/// for display purposes in the application.
/// </summary>
public class AccountListItemViewModel
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string MaskedAccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string Status { get; set; } = "Active";
}
