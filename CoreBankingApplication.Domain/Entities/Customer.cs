using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CoreBankingApplication.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public ICollection<BankAccount> bankAccounts { get; set; } = new List<BankAccount>();
    }
}
