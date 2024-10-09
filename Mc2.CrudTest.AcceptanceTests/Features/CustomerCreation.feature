Feature: Customer Creation

  As an operator
  I wish to be able to create customers

  @mytag
  Scenario: Successfully create a customer
    Given I have the following customer details:
      | FirstName | LastName | DateOfBirth | PhoneNumber  | Email              | BankAccountNumber |
      | John      | Doe      | 1990-01-01  | +989193227055  | johndoe2@email.com | 1234567890  |
    When I create a customer
    Then the customer should be created successfully
    And I should see a success message "Customer created successfully"

  @negative
  Scenario: Fail to create customer with invalid phone number
    Given I have the following customer details:
      | FirstName | LastName | DateOfBirth | PhoneNumber      | Email               | BankAccountNumber |
      | Bob       | Brown    | 1995-03-03  | invalid_phone     | bob.brown@example.com| 1234567890123458  |
    When I create a customer
    Then I should see an error message "Invalid phone number"
