# CrudTestProject

A CRUD application built with .NET that allows for managing customer data efficiently. It includes features for validating unique entries, implementing TDD and BDD practices, and utilizing Clean Architecture principles.

## Overview

This project implements a simple CRUD application for managing customer data with the following model:

### Customer Model

- **FirstName**
- **LastName**
- **DateOfBirth**
- **PhoneNumber**
- **Email**
- **BankAccountNumber**

## Implemented Practices and Patterns

1. **Test-Driven Development (TDD)**:
   - Tests are written prior to feature implementation to ensure code meets requirements from the outset.

2. **Behavior-Driven Development (BDD)**:
   - User scenarios guide feature development, ensuring business needs are met.

3. **Domain-Driven Design (DDD)**:
   - The project structure is organized around the domain model, focusing on business logic.

4. **Clean Architecture**:
   - The project is structured to separate concerns into distinct layers:
     - **Presentation Layer**: Manages user interface interactions (Blazor Web).
     - **Application Layer**: Contains business logic and service interactions.
     - **Domain Layer**: Holds core business entities and their behaviors.
     - **Infrastructure Layer**: Manages data access and external services (using Entity Framework for database interactions).

5. **CQRS Pattern (Event Sourcing)**:
   - The application employs the Command Query Responsibility Segregation (CQRS) pattern to separate read and write operations.

## Validation Logic

- **Phone Number Validation**:
  - Uses Google LibPhoneNumber library to validate mobile numbers.

- **Email and Bank Account Validation**:
  - Ensures valid email addresses and bank account numbers before form submission.

- **Uniqueness Constraints**:
  - Database constraints ensure customer uniqueness based on `FirstName`, `LastName`, and `DateOfBirth`. Email addresses must also be unique.

## Storage Optimization

- Phone numbers are stored using minimized space storage techniques, selecting `varchar` or `string` based on efficiency.

## Technologies Used

- **Database**: SQL Server
- **Entity Framework (EF)**: For database interactions.
- **Blazor WebAssembly**: For a modern web interface.
- **Swagger UI**: For API documentation and testing.

## Steps to Create and Update the Database (Using Entity Framework)

1. **Create a Migration**:
   Run the following command in the Package Manager Console to create a migration:
   ```bash
   Add-Migration InitialCreate

2. **Update the Database**:
   Apply the migration to the database by running:
   ```bash
   Update-Database
   ```

## Commit Strategy

- Clean, meaningful commits were made throughout the development process, documenting decisions and design considerations.

## Test Implementation

- Basic unit tests were developed to demonstrate proficiency in testing, with the potential for further expansion.

## Additional Recommendations

1. **Data Mapping**:
   - Utilize mapping libraries (like AutoMapper) for data transformations.

2. **Security Enhancements**:
   - Implement encryption for sensitive customer information.

3. **Asynchronous Processing**:
   - Use asynchronous programming to improve API and database interaction performance.

4. **Containerization**:
   - Consider integrating Docker for consistent environments across development and production.

5. **CI/CD Integration**:
   - Establish CI/CD pipelines for automated testing and deployment.

## Conclusion

This CRUD application is developed with a focus on clean coding practices and modern design principles. It successfully implements TDD, BDD, DDD, and CQRS, providing a solid foundation for future enhancements.
```

You can copy and paste this content into your `README.md` file on GitHub. Let me know if you need any further adjustments!
