using Mc2.CrudTest.Presentation.Shared.Models;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Repositories.Commands
{
    /// <summary>
    /// Interface for Customer command repository operations.
    /// </summary>
    public interface ICustomerCommandRepository
    {
        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer if found; otherwise, null.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Adds a new customer to the repository.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        Task AddCustomerAsync(Customer customer);

        /// <summary>
        /// Updates an existing customer in the repository.
        /// </summary>
        /// <param name="customer">The customer with updated information.</param>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Deletes a customer from the repository by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        Task DeleteCustomerAsync(int id);
    }
}
