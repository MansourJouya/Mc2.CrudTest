using Mc2.CrudTest.Presentation.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    /// <summary>
    /// Interface for customer services.
    /// </summary>
    public interface ICustomerService
    {
        // Query Methods

        /// <summary>
        /// Retrieves a customer by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer.</returns>
        Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber);



        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Retrieves all customers from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of customers.</returns>
        Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync();

        // Command Methods

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">The customer to create.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in an ActionResult of the created customer.</returns>
        Task<ActionResult<Customer>> CreateCustomer(Customer customer);

        /// <summary>
        /// Updates an existing customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to update.</param>
        /// <param name="customer">The updated customer data.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in an IActionResult.</returns>
        Task<IActionResult> UpdateCustomerAsync(int id, Customer customer);

        /// <summary>
        /// Deletes a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in an IActionResult.</returns>
        Task<IActionResult> DeleteCustomerAsync(int id);
    }
}
