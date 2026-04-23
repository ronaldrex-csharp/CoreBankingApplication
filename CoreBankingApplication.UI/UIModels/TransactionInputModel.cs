using CoreBankingApplication.UI.Validation;
using System.ComponentModel.DataAnnotations;

namespace CoreBankingApplication.UI.UIModels;



    public class TransactionInputModel
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(typeof(decimal), "0.01", "500.00", ErrorMessage = "Amount must be between $0.01 and $500.00")]
        [DecimalPlaces(2, ErrorMessage = "Amount must have no more than 2 decimal places")]
        public decimal? Amount { get; set; }

        public string Type { get; set; } = "Deposit";
    }
