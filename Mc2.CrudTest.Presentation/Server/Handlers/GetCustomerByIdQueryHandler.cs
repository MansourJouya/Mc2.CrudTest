using Mc2.CrudTest.Presentation.Server.Queries;
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;  
using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;
using SendGrid.Helpers.Errors.Model;  

/// <summary>
/// Handles the retrieval of a <see cref="Customer"/> by its ID via the <see cref="GetCustomerByIdQuery"/>.
/// </summary>
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerQueryRepository _customerQueryRepository; // Repository for querying customers

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCustomerByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="customerQueryRepository">The repository for customer queries.</param>
    public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    /// <summary>
    /// Handles the retrieval of a customer by ID.
    /// </summary>
    /// <param name="request">The query containing the customer ID.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation, with a <see cref="Customer"/> as a result.</returns>
    /// <exception cref="NotFoundException">Thrown when a customer with the specified ID is not found.</exception>
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the customer asynchronously
        var customer = await _customerQueryRepository.GetCustomerByIdAsync(request.Id);

        // Check if the customer was found
        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }

        // Return the found customer
        return customer;
    }
}
