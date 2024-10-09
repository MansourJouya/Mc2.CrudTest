using Mc2.CrudTest.Presentation.Shared.Models;
using MediatR;
using System.Collections.Generic;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    /// <summary>
    /// Represents a query to retrieve all customers with optional filtering by first and last name.
    /// </summary>
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        /// <summary>
        /// Gets or sets the first name to filter customers by.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name to filter customers by.
        /// </summary>
        public string LastName { get; set; }

        // You can add additional parameters for filtering as needed.
    }
}
