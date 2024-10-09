namespace Mc2.CrudTest.Presentation.Shared.Models
{
    /// <summary>
    /// Represents a customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the customer.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the bank account number of the customer.
        /// </summary>
        public string BankAccountNumber { get; set; }
    }
}
