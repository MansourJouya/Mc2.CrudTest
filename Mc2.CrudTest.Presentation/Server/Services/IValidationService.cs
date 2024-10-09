namespace Mc2.CrudTest.Presentation.Server.Services
{
    /// <summary>
    /// Interface for validation services.
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Validates a phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid; otherwise, false.</returns>
        bool IsValidPhoneNumber(string phoneNumber);

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid; otherwise, false.</returns>
        bool IsValidEmail(string email);

        /// <summary>
        /// Validates a bank account number.
        /// </summary>
        /// <param name="bankAccountNumber">The bank account number to validate.</param>
        /// <returns>True if the bank account number is valid; otherwise, false.</returns>
        bool IsValidBankAccountNumber(string bankAccountNumber);
    }
}
