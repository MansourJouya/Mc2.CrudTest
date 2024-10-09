using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;
using Mc2.CrudTest.Presentation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Repository for querying customer data.
/// Implements the <see cref="ICustomerQueryRepository"/> interface.
/// </summary>
public class CustomerQueryRepository : ICustomerQueryRepository
{
    private readonly DbContextCustomer _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerQueryRepository"/> class.
    /// </summary>
    /// <param name="context">The database context for customer operations.</param>
    public CustomerQueryRepository(DbContextCustomer context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a customer by their phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number of the customer.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    public async Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }

    /// <summary>
    /// Retrieves a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    /// <summary>
    /// Retrieves all customers from the repository.
    /// </summary>
    /// <returns>A collection of customers.</returns>
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    /// <summary>
    /// Checks if a customer exists based on their name and date of birth.
    /// </summary>
    /// <param name="firstName">The first name of the customer.</param>
    /// <param name="lastName">The last name of the customer.</param>
    /// <param name="dateOfBirth">The date of birth of the customer.</param>
    /// <returns>True if the customer exists; otherwise, false.</returns>
    public async Task<bool> CustomerExists(string firstName, string lastName, DateTime dateOfBirth)
    {
        return await _context.Customers.AnyAsync(c => c.FirstName == firstName &&
                                                       c.LastName == lastName &&
                                                       c.DateOfBirth == dateOfBirth);
    }

    /// <summary>
    /// Checks if an email already exists in the repository.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <returns>True if the email exists; otherwise, false.</returns>
    public async Task<bool> EmailExists(string email)
    {
        return await _context.Customers.AnyAsync(c => c.Email == email);
    }

    /// <summary>
    /// Checks if a phone number already exists in the repository.
    /// </summary>
    /// <param name="phoneNumber">The phone number to check.</param>
    /// <returns>True if the phone number exists; otherwise, false.</returns>
    public async Task<bool> PhoneNumberExists(string phoneNumber)
    {
        return await _context.Customers.AnyAsync(c => c.PhoneNumber == phoneNumber);
    }
}
