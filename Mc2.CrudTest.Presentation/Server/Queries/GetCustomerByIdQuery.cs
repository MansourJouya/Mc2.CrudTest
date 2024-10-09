using MediatR;
using Mc2.CrudTest.Presentation.Shared.Models;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    /// <summary>
    /// Represents a query to retrieve a customer by their unique identifier.
    /// </summary>
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer to be retrieved.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomerByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
