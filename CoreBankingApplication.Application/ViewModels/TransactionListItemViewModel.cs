using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Application.ViewModels
{
    public class TransactionListItemViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
