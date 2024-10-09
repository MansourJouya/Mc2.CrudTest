using Mc2.CrudTest.Presentation.Server.Repositories.Commands;
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;
using Mc2.CrudTest.Presentation.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    /// <summary>
    /// Provides services for managing customers.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IValidationService _validationService;

        public CustomerService(ICustomerCommandRepository customerCommandRepository,
                               ICustomerQueryRepository customerQueryRepository,
                               IValidationService validationService)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
            _validationService = validationService;
        }

        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer if found.</returns>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerQueryRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer with this ID does not exist.");
            }
            return customer;
        }

        /// <summary>
        /// Retrieves all customers from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a list of customers.</returns>
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            var customers = await _customerQueryRepository.GetAllCustomersAsync();
            return new OkObjectResult(customers);
        }

        /// <summary>
        /// Deletes a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be deleted.</param>
        /// <returns>An action result indicating the outcome of the delete operation.</returns>
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var customer = await _customerQueryRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return new NotFoundObjectResult("Customer with this ID does not exist.");
            }

            await _customerCommandRepository.DeleteCustomerAsync(id);
            return new NoContentResult();
        }

        /// <summary>
        /// Deletes a customer by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the customer to be deleted.</param>
        /// <returns>An action result indicating the outcome of the delete operation.</returns>
        public async Task<IActionResult> DeleteCustomerAsync(string phoneNumber)
        {
            // Search for the customer using their phone number
            var customer = await _customerQueryRepository.GetCustomerByPhoneNumberAsync(phoneNumber);
            if (customer == null)
            {
                return new NotFoundObjectResult("Customer with this phone number does not exist.");
            }

            await _customerCommandRepository.DeleteCustomerAsync(customer.Id);
            return new NoContentResult(); // or any other successful result
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">The customer to be created.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created customer.</returns>
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            // Input validation
            if (customer == null)
            {
                return new BadRequestObjectResult("Invalid input.");
            }

            // Validate the phone number format
            if (!_validationService.IsValidPhoneNumber(customer.PhoneNumber))
            {
                return new BadRequestObjectResult("Invalid phone number.");
            }

            // Check for existing customer by phone number
            if (await _customerQueryRepository.PhoneNumberExists(customer.PhoneNumber))
            {
                return new ConflictObjectResult(new { message = "Phone number already in use." });
            }

            // Check for existing customer by name and email
            if (await _customerQueryRepository.CustomerExists(customer.FirstName, customer.LastName, customer.DateOfBirth) ||
                await _customerQueryRepository.EmailExists(customer.Email))
            {
                return new ConflictObjectResult(new { message = "Customer with these details already exists." });
            }

            // Add customer to repository
            await _customerCommandRepository.AddCustomerAsync(customer);
            return new CreatedAtActionResult(nameof(GetCustomerByIdAsync), "Customer", new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Updates an existing customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be updated.</param>
        /// <param name="customer">The updated customer details.</param>
        /// <returns>An action result indicating the outcome of the update operation.</returns>
        public async Task<IActionResult> UpdateCustomerAsync(int id, Customer customer)
        {
            if (customer == null)
            {
                return new BadRequestObjectResult("Invalid input.");
            }

            // Check if customer exists
            var existingCustomer = await _customerQueryRepository.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return new NotFoundObjectResult($"Customer with ID {id} not found.");
            }

            // Validate input
            if (string.IsNullOrEmpty(customer.FirstName) ||
                string.IsNullOrEmpty(customer.LastName) ||
                string.IsNullOrEmpty(customer.Email) ||
                !_validationService.IsValidPhoneNumber(customer.PhoneNumber) ||
                !_validationService.IsValidEmail(customer.Email) ||
                !_validationService.IsValidBankAccountNumber(customer.BankAccountNumber))
            {
                return new BadRequestObjectResult("Inputs are not valid.");
            }

            // Update customer
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.DateOfBirth = customer.DateOfBirth;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Email = customer.Email;
            existingCustomer.BankAccountNumber = customer.BankAccountNumber;

            await _customerCommandRepository.UpdateCustomerAsync(existingCustomer);
            return new OkObjectResult(existingCustomer);
        }

        /// <summary>
        /// Retrieves a customer by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <returns>A task that represents the asynchronous operation, containing the customer if found.</returns>
        public async Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            // Validate the input
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));
            }

            // Retrieve the customer from the query repository
            var customer = await _customerQueryRepository.GetCustomerByPhoneNumberAsync(phoneNumber);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer with this phone number does not exist.");
            }

            return customer;
        }
    }
}
