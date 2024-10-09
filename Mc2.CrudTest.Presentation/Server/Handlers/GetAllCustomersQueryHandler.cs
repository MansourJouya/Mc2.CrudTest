using Mc2.CrudTest.Presentation.Server.Queries;
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;  
using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handles the retrieval of all <see cref="Customer"/> records via the <see cref="GetAllCustomersQuery"/>.
/// </summary>
public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
    private readonly ICustomerQueryRepository _customerQueryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCustomersQueryHandler"/> class.
    /// </summary>
    /// <param name="customerQueryRepository">The repository for customer queries.</param>
    public GetAllCustomersQueryHandler(ICustomerQueryRepository customerQueryRepository)
    {
        _customerQueryRepository = customerQueryRepository;
    }

    /// <summary>
    /// Handles the retrieval of customers based on the specified query parameters.
    /// </summary>
    /// <param name="request">The query containing filter parameters for retrieving customers.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation, with a collection of <see cref="Customer"/> as a result.</returns>
    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all customers from the repository
        var customers = await _customerQueryRepository.GetAllCustomersAsync();

        // Filter customers based on provided parameters, if any
        if (!string.IsNullOrEmpty(request.FirstName))
        {
            customers = customers.Where(c => c.FirstName.Contains(request.FirstName));
        }
        if (!string.IsNullOrEmpty(request.LastName))
        {
            customers = customers.Where(c => c.LastName.Contains(request.LastName));
        }

        // Return the filtered list of customers
        return customers;
    }
}
