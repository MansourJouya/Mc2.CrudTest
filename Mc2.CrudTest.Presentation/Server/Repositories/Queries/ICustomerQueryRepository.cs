using Mc2.CrudTest.Presentation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Repositories.Queries
{
    /// <summary>
    /// Defines the operations for querying customer data.
    /// </summary>
    public interface ICustomerQueryRepository
    {
        /// <summary>
        /// Retrieves a customer by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer if found; otherwise, null.</returns>
        Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber);

        /// <summary>
        /// Retrieves all customers from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of customers.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer if found; otherwise, null.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Checks if a customer exists based on their name and date of birth.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="dateOfBirth">The date of birth of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing true if the customer exists; otherwise, false.</returns>
        Task<bool> CustomerExists(string firstName, string lastName, DateTime dateOfBirth);

        /// <summary>
        /// Checks if an email already exists in the repository.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>A task that represents the asynchronous operation, containing true if the email exists; otherwise, false.</returns>
        Task<bool> EmailExists(string email);

        /// <summary>
        /// Checks if a phone number already exists in the repository.
        /// </summary>
        /// <param name="phoneNumber">The phone number to check.</param>
        /// <returns>A task that represents the asynchronous operation, containing true if the phone number exists; otherwise, false.</returns>
        Task<bool> PhoneNumberExists(string phoneNumber);
    }
}
