using Mc2.CrudTest.Presentation.Server.Commands;
using Mc2.CrudTest.Presentation.Server.Repositories.Commands;  
using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handles the creation of a new <see cref="Customer"/> via the <see cref="CreateCustomerCommand"/>.
/// </summary>
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCustomerCommandHandler"/> class.
    /// </summary>
    /// <param name="customerCommandRepository">The repository for customer commands.</param>
    public CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
    {
        _customerCommandRepository = customerCommandRepository;
    }

    /// <summary>
    /// Handles the creation of a new customer.
    /// </summary>
    /// <param name="request">The command containing customer details.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation, with a <see cref="Customer"/> as a result.</returns>
    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Create a new Customer object from the command request
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber
        };

        // Add the new customer using the repository
        await _customerCommandRepository.AddCustomerAsync(customer);

        // Return the created customer
        return customer;
    }
}
