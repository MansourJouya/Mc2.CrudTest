using TechTalk.SpecFlow;
using NUnit.Framework;
using Mc2.CrudTest.Presentation.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerUpdateSteps
    {
        private List<Customer> _customers = new List<Customer>();
        private Customer _customerToUpdate;
        private string _errorMessage;
        private bool _isUpdated;

        /// <summary>
        /// Given step to create a customer with specified details.
        /// </summary>
        [Given(@"I have already created a customer with the following details:")]
        public void GivenIHaveAlreadyCreatedACustomerWithTheFollowingDetails(Table table)
        {
            var row = table.Rows.First();
            _customerToUpdate = new Customer
            {
                FirstName = row["FirstName"],
                LastName = row["LastName"],
                DateOfBirth = DateTime.Parse(row["DateOfBirth"]),
                PhoneNumber = row["PhoneNumber"],
                Email = row["Email"],
                BankAccountNumber = row["BankAccountNumber"]
            };

            _customers.Add(_customerToUpdate);
        }

        /// <summary>
        /// Given step to simulate the creation of a customer with a specific phone number.
        /// </summary>
        [Given(@"I have already created a customer with PhoneNumber ""(.*)""")]
        public void GivenIHaveAlreadyCreatedACustomerWithPhoneNumber(string phoneNumber)
        {
            _customers.Add(new Customer { PhoneNumber = phoneNumber });
        }

        /// <summary>
        /// When step to update an existing customer with new details.
        /// </summary>
        [When(@"I update the customer with the following new details:")]
        public void WhenIUpdateAnExistingCustomerWithTheFollowingNewDetails(Table table)
        {
            var row = table.Rows.First();
            var newCustomerData = new Customer
            {
                FirstName = row["FirstName"],
                LastName = row["LastName"],
                DateOfBirth = DateTime.Parse(row["DateOfBirth"]),
                PhoneNumber = row["PhoneNumber"],
                Email = row["Email"],
                BankAccountNumber = row["BankAccountNumber"]
            };

            _errorMessage = ValidateCustomerData(newCustomerData);
            if (_errorMessage == null)
            {
                _customerToUpdate = newCustomerData; // Update the reference for the updated customer
                _isUpdated = true; // Mark the update as successful
            }
        }

        /// <summary>
        /// Then step to verify the customer has been updated successfully.
        /// </summary>
        [Then(@"the customer should be updated successfully")]
        public void ThenTheCustomerShouldBeUpdatedSuccessfully()
        {
            Assert.IsTrue(_isUpdated, "The customer update was not successful.");
        }

        /// <summary>
        /// Then step to check if an error message indicating invalid email is shown.
        /// </summary>
        [Then(@"I should see an error message indicating the email is invalid")]
        public void ThenIShouldSeeAnErrorMessageIndicatingTheEmailIsInvalid()
        {
            Assert.AreEqual(ErrorMessage.InvalidEmail, _errorMessage);
        }

        /// <summary>
        /// Then step to check if an error message indicating existing phone number is shown.
        /// </summary>
        [Then(@"I should see an error message indicating the phone number already exists")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThePhoneNumberAlreadyExists()
        {
            Assert.AreEqual(ErrorMessage.PhoneNumberExists, _errorMessage);
        }

        /// <summary>
        /// Validates customer data before update.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise null.</returns>
        private string ValidateCustomerData(Customer customer)
        {
            if (!IsValidEmail(customer.Email))
                return ErrorMessage.InvalidEmail;

            if (_customers.Any(c => c.PhoneNumber == customer.PhoneNumber && c != _customerToUpdate))
                return ErrorMessage.PhoneNumberExists;

            return null; // No errors
        }

        /// <summary>
        /// Simple email validation logic.
        /// </summary>
        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.IndexOf("@") < email.Length - 1;
        }

        private static class ErrorMessage
        {
            public const string InvalidEmail = "The email is invalid.";
            public const string PhoneNumberExists = "The phone number already exists.";
        }

        /// <summary>
        /// Given step to define new details for an existing customer.
        /// </summary>
        [Given(@"I have the following new details for an existing customer:")]
        public void GivenIHaveTheFollowingNewDetailsForAnExistingCustomer(Table table)
        {
            var row = table.Rows.First();
            _customerToUpdate = new Customer
            {
                FirstName = row["FirstName"],
                LastName = row["LastName"],
                DateOfBirth = DateTime.Parse(row["DateOfBirth"]),
                PhoneNumber = row["PhoneNumber"],
                Email = row["Email"],
                BankAccountNumber = row["BankAccountNumber"]
            };
        }
    }
}
