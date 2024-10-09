using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Repositories.Commands;
using Mc2.CrudTest.Presentation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class CustomerCommandRepository : ICustomerCommandRepository
{
    private readonly DbContextCustomer _context;

    public CustomerCommandRepository(DbContextCustomer context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new customer to the database.
    /// </summary>
    /// <param name="customer">The customer to add.</param>
    public async Task AddCustomerAsync(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing customer in the database.
    /// </summary>
    /// <param name="customer">The customer with updated information.</param>
    public async Task UpdateCustomerAsync(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <exception cref="ArgumentException">Thrown when the customer does not exist.</exception>
    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
            throw new ArgumentException("No customer found with this ID.");

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to retrieve.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
}
