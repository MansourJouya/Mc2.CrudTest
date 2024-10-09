using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Commands
{
    /// <summary>
    /// Represents a command to create a new customer.
    /// Implements the <see cref="IRequest{Customer}"/> interface to define the request and its expected response type.
    /// </summary>
    public class CreateCustomerCommand : IRequest<Customer>
    {
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
        /// Initializes a new instance of the <see cref="CreateCustomerCommand"/> class.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="dateOfBirth">The date of birth of the customer.</param>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        /// <param name="bankAccountNumber">The bank account number of the customer.</param>
        public CreateCustomerCommand(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
