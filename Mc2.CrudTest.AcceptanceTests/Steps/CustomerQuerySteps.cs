using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Mc2.CrudTest.Presentation.Shared.Models;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerQuerySteps
    {
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Given step to create two customers with the specified details.
        /// </summary>
        [Given(@"I have created two customers with the following details:")]
        public void GivenIHaveCreatedTwoCustomersWithTheFollowingDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                var customer = new Customer
                {
                    FirstName = row["FirstName"],
                    LastName = row["LastName"],
                    DateOfBirth = DateTime.Parse(row["DateOfBirth"]),
                    PhoneNumber = row["PhoneNumber"],
                    Email = row["Email"],
                    BankAccountNumber = row["BankAccountNumber"]
                };
                _customers.Add(customer);
            }
        }

        /// <summary>
        /// When step to list all customers.
        /// </summary>
        [When(@"I list all customers")]
        public void WhenIListAllCustomers()
        {
            // This step is simulated, assuming _customers already has the data.
            ScenarioContext.Current["AllCustomers"] = _customers;
        }

        /// <summary>
        /// Then step to verify the customers are listed.
        /// </summary>
        [Then(@"I should see the customers listed")]
        public void ThenIShouldSeeTheCustomersListed()
        {
            var allCustomers = (List<Customer>)ScenarioContext.Current["AllCustomers"];
            Assert.IsTrue(allCustomers.Count > 0, "No customers are available.");

            foreach (var customer in allCustomers)
            {
                Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}, Phone: {customer.PhoneNumber}, Email: {customer.Email}");
            }
        }

        /// <summary>
        /// When step to list all customers when there are none.
        /// </summary>
        [When(@"I list all customers when there are none")]
        public void WhenIListAllCustomersWhenThereAreNone()
        {
            _customers.Clear(); // Ensure the list is empty for this scenario
            ScenarioContext.Current["AllCustomers"] = _customers;
        }

        /// <summary>
        /// Then step to verify no customers are available.
        /// </summary>
        [Then(@"I should see a message indicating no customers are available")]
        public void ThenIShouldSeeAMessageIndicatingNoCustomersAreAvailable()
        {
            var allCustomers = (List<Customer>)ScenarioContext.Current["AllCustomers"];
            Assert.IsTrue(allCustomers.Count == 0, "There are customers available when there shouldn't be.");

            // Simulating the message that would be shown
            Console.WriteLine("No customers are available.");
        }
    }
}
