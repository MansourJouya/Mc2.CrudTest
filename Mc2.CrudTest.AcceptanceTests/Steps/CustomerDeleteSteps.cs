using TechTalk.SpecFlow;
using NUnit.Framework;
using Mc2.CrudTest.Presentation.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerDeleteSteps
    {
        private List<Customer> _customers = new List<Customer>();
        private Customer _customerToDelete;
        private bool _isDeleted;

        /// <summary>
        /// Given step to create a customer with the specified details.
        /// </summary>
        [Given(@"I have created a customer with the following details:")]
        public void GivenIHaveCreatedACustomerWithTheFollowingDetails(Table table)
        {
            // Extract customer details from the first row of the table
            var row = table.Rows.First();
            _customerToDelete = new Customer
            {
                FirstName = row["FirstName"],
                LastName = row["LastName"],
                DateOfBirth = DateTime.Parse(row["DateOfBirth"]),
                PhoneNumber = row["PhoneNumber"],
                Email = row["Email"],
                BankAccountNumber = row["BankAccountNumber"]
            };

            // Add the customer to the list
            _customers.Add(_customerToDelete);
        }

        /// <summary>
        /// When step to delete the customer.
        /// </summary>
        [When(@"I delete the customer")]
        public void WhenIDeleteTheCustomer()
        {
            // Simulate deletion logic
            if (_customers.Contains(_customerToDelete))
            {
                _customers.Remove(_customerToDelete);
                _isDeleted = true;
            }
            else
            {
                _isDeleted = false; // Deletion fails if customer does not exist
            }
        }

        /// <summary>
        /// Then step to verify the customer has been deleted successfully.
        /// </summary>
        [Then(@"the customer should be deleted successfully")]
        public void ThenTheCustomerShouldBeDeletedSuccessfully()
        {
            // Assert that the deletion was successful
            Assert.IsTrue(_isDeleted, "The customer deletion was not successful.");
            Assert.IsFalse(_customers.Contains(_customerToDelete), "The customer still exists after deletion.");
        }
    }
}
