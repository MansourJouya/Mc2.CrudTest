Feature: Customer Listing

  As an operator
  I wish to be able to list all customers

  @mytag
  Scenario: List all customers when there are customers available
    Given I have created two customers with the following details:
      | FirstName | LastName | DateOfBirth | PhoneNumber    | Email               | BankAccountNumber |
      | John      | Doe      | 1990-01-01  | +1234567890    | john.doe@example.com| 1234567890123456  |
      | Jane      | Smith    | 1991-02-02  | +0987654321    | jane.smith@example.com| 6543210987654321  |
    When I list all customers
    Then I should see the customers listed

  Scenario: List all customers when there are none
    When I list all customers
    Then I should see a message indicating no customers are available
