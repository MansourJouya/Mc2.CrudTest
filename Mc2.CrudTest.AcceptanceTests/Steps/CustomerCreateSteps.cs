using Mc2.CrudTest.Presentation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerCreateSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly List<Customer> _customers = new();

        public CustomerCreateSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Given step to set up customer details from a table.
        /// </summary>
        [Given(@"I have the following customer details:")]
        public void GivenIHaveTheFollowingCustomerDetails(Table table)
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
        /// When step to create a customer and validate the details.
        /// </summary>
        [When(@"I create a customer")]
        public void WhenICreateACustomer()
        {
            var customerToCreate = _customers[^1]; // Get the last customer details
            _scenarioContext["LastCreatedCustomer"] = customerToCreate;

            // Validate the customer details
            string errorMessage = ValidateCustomer(customerToCreate);

            if (errorMessage != null)
            {
                _scenarioContext["ErrorMessage"] = errorMessage; // Store error message
                Console.WriteLine($"Validation failed: {errorMessage}"); // Debugging
            }
            else
            {
                _customers.Add(customerToCreate); // Add customer to the list
                _scenarioContext["SuccessMessage"] = "Customer created successfully"; // Store success message
                Console.WriteLine("Customer created successfully."); // Debugging
            }
        }

        /// <summary>
        /// Validates the customer details.
        /// </summary>
        /// <param name="customer">The customer to validate.</param>
        /// <returns>Error message if validation fails, otherwise null.</returns>
        private string ValidateCustomer(Customer customer)
        {
            if (!IsValidPhoneNumber(customer.PhoneNumber))
            {
                return "Invalid phone number";
            }

            if (!IsEmailDuplicate(customer.Email))
            {
                return "Email already exists";
            }

            return null; // No validation errors
        }

        /// <summary>
        /// Then step to assert customer creation.
        /// </summary>
        [Then(@"the customer should be created successfully")]
        public void ThenTheCustomerShouldBeCreatedSuccessfully()
        {
            var lastCustomer = (Customer)_scenarioContext["LastCreatedCustomer"];
            if (!_customers.Contains(lastCustomer))
            {
                throw new Exception("Customer was not created successfully.");
            }
        }

        /// <summary>
        /// Then step to check success message.
        /// </summary>
        [Then(@"I should see a success message ""(.*)""")]
        public void ThenIShouldSeeASuccessMessage(string expectedMessage)
        {
            if (!_scenarioContext.TryGetValue("SuccessMessage", out string actualMessage))
            {
                throw new Exception("Success message was not set.");
            }

            if (actualMessage != expectedMessage)
            {
                throw new Exception($"Expected message: {expectedMessage}, but got: {actualMessage}");
            }
        }

        /// <summary>
        /// Then step to check error message.
        /// </summary>
        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string expectedMessage)
        {
            if (!_scenarioContext.TryGetValue("ErrorMessage", out string actualMessage))
            {
                throw new Exception("Error message was not set.");
            }

            if (actualMessage != expectedMessage)
            {
                throw new Exception($"Expected error message: {expectedMessage}, but got: {actualMessage}");
            }
        }

        /// <summary>
        /// Validates the phone number format.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if valid; otherwise false.</returns>
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("+") && phoneNumber.Length >= 10; // Adjust as needed
        }

        /// <summary>
        /// Checks if the email already exists in the customers list.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>True if email exists; otherwise false.</returns>
        private bool IsEmailDuplicate(string email)
        {
            return _customers.Any(c => c.Email == email);
        }
    }
}
