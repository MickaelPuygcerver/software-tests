using System;
using UnitTests.Lib;
using Xunit;

namespace UnitTests.Tests
{
    // With colletion definition we can use the same instance of objects
    // Objects created in a fixture is valid all along time in colletion, its be very usefull in cases like in memory database
    [CollectionDefinition(nameof(EmployeeColletion))]
    public class EmployeeColletion : ICollectionFixture<EmployeeTestFixture>
    { }


    // A fixture can be used in any tests classes 
    public class EmployeeTestFixture : IDisposable
    {
        public Employee CreateValidEmployee()
        {
            var employee = EmployeeFactory.Create("Mickael", 1000);
            return employee;
        }

        public Employee CreateInvalidEmployee()
        {
            var employee = EmployeeFactory.Create("Mickael", 100);
            return employee;
        }

        public void Dispose()
        {
        }
    }
}
