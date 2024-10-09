using Mc2.CrudTest.Presentation.Server.Commands;
using Mc2.CrudTest.Presentation.Server.Repositories.Commands;  
using MediatR;
using SendGrid.Helpers.Errors.Model;  
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handles the updating of an existing <see cref="Customer"/> via the <see cref="UpdateCustomerCommand"/>.
/// </summary>
public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerCommandRepository _customerCommandRepository; // Repository for customer commands

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCustomerCommandHandler"/> class.
    /// </summary>
    /// <param name="customerCommandRepository">The repository for customer commands.</param>
    public UpdateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
    {
        _customerCommandRepository = customerCommandRepository;
    }

    /// <summary>
    /// Handles the update of a customer.
    /// </summary>
    /// <param name="request">The command containing the customer data to update.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation, with a <see cref="Unit"/> as a result.</returns>
    /// <exception cref="NotFoundException">Thrown when the specified customer is not found.</exception>
    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the existing customer asynchronously
        var existingCustomer = await _customerCommandRepository.GetCustomerByIdAsync(request.Id);

        // Check if the customer was found
        if (existingCustomer == null)
        {
            throw new NotFoundException("Customer not found");
        }

        // Update customer properties with the new values from the request
        existingCustomer.FirstName = request.FirstName;
        existingCustomer.LastName = request.LastName;
        existingCustomer.DateOfBirth = request.DateOfBirth;
        existingCustomer.PhoneNumber = request.PhoneNumber;
        existingCustomer.Email = request.Email;
        existingCustomer.BankAccountNumber = request.BankAccountNumber;

        // Persist the changes to the repository
        await _customerCommandRepository.UpdateCustomerAsync(existingCustomer);

        // Return a value indicating the update was successful
        return Unit.Value;
    }
}
