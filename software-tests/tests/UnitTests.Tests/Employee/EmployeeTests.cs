using Xunit;

namespace UnitTests.Tests
{
    // To fixture works, test class must be part of fixture colletion
    [Collection(nameof(EmployeeColletion))]
    public class EmployeeTests
    {
        private readonly EmployeeTestFixture _employeeTestFixture;

        public EmployeeTests(EmployeeTestFixture employeeTestFixture)
        {
            _employeeTestFixture = employeeTestFixture;
        }

        [Fact]
        [Trait("Category", "Employee")]
        public void Employee_NewEmployee_MustBeValid()
        {
            // Arrange
            var employee = _employeeTestFixture.CreateValidEmployee();

            // Act
            var isValid = employee.IsValid();

            // Assert
            Assert.True(isValid);
        }
    }
}
