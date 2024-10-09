using System;
using TechTalk.SpecFlow;
using BoDi;
using Mc2.CrudTest.Presentation.Server.Services;
using Mc2.CrudTest.Presentation.Server.Repositories.Commands;
using Mc2.CrudTest.Presentation.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;   
using Mc2.CrudTest.Presentation.Server.Repositories.Queries;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks : IDisposable
    {
        private readonly IObjectContainer _objectContainer;
        private DbContextCustomer _dbContext;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Registers dependencies before each scenario.
        /// </summary>
        [BeforeScenario]
        public void RegisterDependencies()
        {
            var options = new DbContextOptionsBuilder<DbContextCustomer>()
                .UseInMemoryDatabase("JouyaTest") // .NET 7 compatible method
                .Options;

            // Initialize the in-memory database context
            _dbContext = new DbContextCustomer(options);
            _objectContainer.RegisterInstanceAs(_dbContext);

            // Register services and repositories in the IoC container
            _objectContainer.RegisterTypeAs<CustomerService, ICustomerService>();
            _objectContainer.RegisterTypeAs<CustomerCommandRepository, ICustomerCommandRepository>();
            _objectContainer.RegisterTypeAs<CustomerQueryRepository, ICustomerQueryRepository>(); // Register the query repository
            _objectContainer.RegisterTypeAs<ValidationService, IValidationService>(); // Register the validation service
        }

        /// <summary>
        /// Runs before each scenario to log the start of the scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("A new scenario is starting.");
        }

        /// <summary>
        /// Runs after each scenario to log the end of the scenario and clean up resources.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Scenario has finished.");
            Dispose();
        }

        /// <summary>
        /// Disposes of the database context.
        /// </summary>
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
