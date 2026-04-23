using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Application.ViewModels;

public class BankAccountViewModel
{
    public int Id { get; set; }
    public string MaskedAccountNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public decimal Balance { get; set; } = 0m;

}
