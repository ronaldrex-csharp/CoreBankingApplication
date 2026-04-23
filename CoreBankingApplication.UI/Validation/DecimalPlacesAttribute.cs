using System.ComponentModel.DataAnnotations;

namespace CoreBankingApplication.UI.Validation
{
    public sealed class DecimalPlacesAttribute : ValidationAttribute
    {
        private readonly int _decimalPlaces;

        public DecimalPlacesAttribute(int decimalPlaces)
        {
            _decimalPlaces = decimalPlaces;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is decimal amount)
            {
                var rounded = decimal.Round(amount, _decimalPlaces);

                if (amount != rounded)
                {
                    return new ValidationResult(
                        ErrorMessage ?? $"Value cannot have more than {_decimalPlaces} decimal places.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid decimal value.");
        }
    }
}