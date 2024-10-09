using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Presentation.Shared.Models;
using Mc2.CrudTest.Presentation.Server.Data.Configurations;

namespace Mc2.CrudTest.Presentation.Server.Data
{
    /// <summary>
    /// Represents the database context for managing <see cref="Customer"/> entities.
    /// </summary>
    public class DbContextCustomer : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextCustomer"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public DbContextCustomer(DbContextOptions<DbContextCustomer> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of <see cref="Customer"/> entities.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Configures the model for the context using the specified <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The builder for configuring the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply the configuration for the Customer entity
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            // Call the base method to ensure the configuration is applied correctly
            base.OnModelCreating(modelBuilder);
        }
    }
}
