Feature: Customer Deletion

  As an operator
  I wish to be able to delete customers

  @mytag
  Scenario: Successfully delete a customer
    Given I have created a customer with the following details:
      | FirstName | LastName | DateOfBirth | PhoneNumber    | Email               | BankAccountNumber |
      | Jane      | Smith    | 1991-02-02  | +0987654321    | jane.smith@example.com| 6543210987654321  |
    When I delete the customer
    Then the customer should be deleted successfully
