using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Commands
{
    /// <summary>
    /// Represents a command to update an existing customer.
    /// Implements the <see cref="IRequest{Unit}"/> interface to define the request and its expected response type.
    /// </summary>
    public class UpdateCustomerCommand : IRequest<Unit>
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
        /// Gets or sets the date of birth of the customer.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the bank account number of the customer.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="dateOfBirth">The date of birth of the customer.</param>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        /// <param name="bankAccountNumber">The bank account number of the customer.</param>
        public UpdateCustomerCommand(int id, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
