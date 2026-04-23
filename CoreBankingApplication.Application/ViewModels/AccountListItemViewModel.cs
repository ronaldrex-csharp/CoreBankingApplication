using CoreBankingApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Application.ViewModels;

public class AccountListItemViewModel
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string MaskedAccountNumber { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string Status { get; set; } = "Active";
}
