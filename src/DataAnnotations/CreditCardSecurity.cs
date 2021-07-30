using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenCodeDev.Forms.Validation.DataAnnotations
{
    public class CreditCardSecurity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,  ValidationContext validationContext)
        {
            if (value == default)
            {
                return null;
            }
            Regex patt = new Regex(ValidationPatterns.CREDIT_CARD_CVV);
            if (patt.IsMatch(value.ToString()))
            {
                return null;
            }
            return new ValidationResult($"Credit card security number has an invalid format.",
            new[] { validationContext.MemberName });
        }
    }
}
