 


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mc2.CrudTest.Presentation.Shared.Models;

namespace Mc2.CrudTest.Presentation.Server.Data.Configurations
{
    /// <summary>
    /// Configures the <see cref="Customer"/> entity for EF Core.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the properties of the <see cref="Customer"/> entity.
        /// </summary>
        /// <param name="builder">The entity type builder.</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Set the primary key
            builder.HasKey(c => c.Id);

            // Configure properties with validation rules
            builder.Property(c => c.FirstName)
                .IsRequired() // First name is required
                .HasMaxLength(100); // Maximum length is 100 characters

            builder.Property(c => c.LastName)
                .IsRequired() // Last name is required
                .HasMaxLength(100); // Maximum length is 100 characters

            builder.Property(c => c.Email)
                .IsRequired() // Email is required
                .HasMaxLength(200); // Maximum length is 200 characters

            builder.Property(c => c.PhoneNumber)
                .IsRequired() // Phone number is required
                .HasMaxLength(15); // Maximum length is 15 characters

            builder.Property(c => c.BankAccountNumber)
                .IsRequired() // Bank account number is required
                .HasMaxLength(20); // Maximum length is 20 characters

            // Additional configuration for unique constraints can be added here
            builder.HasIndex(c => c.Email).IsUnique(); // Ensure unique email addresses
            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique(); // Ensure uniqueness of FirstName, LastName, and DateOfBirth
        }
    }
}
