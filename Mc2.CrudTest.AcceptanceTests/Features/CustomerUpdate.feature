Feature: Customer Update

  As an operator
  I wish to be able to update customer details

  @mytag
  Scenario: Attempt to update a customer with an invalid email
    Given I have already created a customer with the following details:
      | FirstName | LastName | DateOfBirth | PhoneNumber      | Email               | BankAccountNumber |
      | Alice     | Brown    | 1985-03-03  | +14155552671     | alice.brown@example.com| 1234567890123456  |
    When I update the customer with the following new details:
      | FirstName | LastName | DateOfBirth | PhoneNumber      | Email               | BankAccountNumber |
      | Alice     | Brown    | 1985-03-03  | +14155552671     | alice.brown@       | 1234567890123456  |
    Then I should see an error message indicating the email is invalid

  Scenario: Attempt to update a customer with an existing phone number
    Given I have already created a customer with PhoneNumber "+14155551234"
    And I have already created a customer with PhoneNumber "+14155552671"
    And I have the following new details for an existing customer:
      | FirstName | LastName | DateOfBirth | PhoneNumber      | Email               | BankAccountNumber |
      | Bob       | Green    | 1987-04-04  | +14155552671     | bob.green@example.com| 9876543210987654  |
    When I update the customer with the following new details:
      | FirstName | LastName | DateOfBirth | PhoneNumber      | Email               | BankAccountNumber |
      | Bob       | Green    | 1987-04-04  | +14155551234     | bob.new@example.com | 9876543210987654  |
    Then I should see an error message indicating the phone number already exists
