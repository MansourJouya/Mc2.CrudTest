using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    /// <summary>
    /// Implementation of validation services for customer data.
    /// </summary>
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Validates a phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is a valid mobile number; otherwise, false.</returns>
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                // Attempt to parse the phone number
                var number = phoneNumberUtil.Parse(phoneNumber, null);

                // Check if the number is valid and specifically a mobile number
                return phoneNumberUtil.IsValidNumber(number) &&
                       phoneNumberUtil.GetNumberType(number) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false; // Return false for invalid formats
            }
        }
    

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid; otherwise, false.</returns>
        public bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        /// <summary>
        /// Validates a bank account number.
        /// </summary>
        /// <param name="bankAccountNumber">The bank account number to validate.</param>
        /// <returns>True if the bank account number is valid; otherwise, false.</returns>
        public bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            return !string.IsNullOrEmpty(bankAccountNumber) && bankAccountNumber.All(char.IsDigit);
        }
    }
}
