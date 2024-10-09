using Mc2.CrudTest.Presentation.Server.Services;
using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to customers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service used to manage customer operations.</param>
        /// <param name="mediator">The mediator for handling commands and queries.</param>
        public CustomerController(ICustomerService customerService, IMediator mediator)
        {
            _customerService = customerService;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">The customer details.</param>
        /// <returns>The created customer.</returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            // Create customer and retrieve the created instance
            var createdCustomer = await _customerService.CreateCustomer(customer);

            // Check if the created customer is null
            if (createdCustomer == null)
            {
                return BadRequest(); // Return a suitable response if creation fails
            }

            // Return the created customer with a 201 Created status and the location of the new resource
            return Ok();
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>A list of customers.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _customerService.GetAllCustomersAsync();
        }

        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound(); // Return 404 if the customer is not found
            }

            return customer;
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to update.</param>
        /// <param name="customer">The updated customer details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
                     return await _customerService.UpdateCustomerAsync(id, customer); // استفاده از await
        }



        /// <summary>
        /// Deletes a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        /// <returns>An IActionResult indicating the result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (result == null)
            {
                return NoContent(); // Return 204 No Content on successful deletion
            }
            return NotFound(); // Return 404 if the customer to delete does not exist
        }
    }
}
