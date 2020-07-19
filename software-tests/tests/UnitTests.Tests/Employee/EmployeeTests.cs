using MediatR;
using Moq;
using System.Threading;
using UnitTests.Lib.Repository;
using UnitTests.Lib.Services;
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
        public void Employee_NewEmployee_IsValid()
        {
            // Arrange
            var employee = _employeeTestFixture.CreateValidEmployee();

            // Act
            var isValid = employee.IsValid();

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        [Trait("Category", "Employee")]
        public void Employee_NewEmployee_IsInvalid()
        {
            // Arrange
            var employee = _employeeTestFixture.CreateInvalidEmployee();

            // Act
            var isValid = employee.IsValid();

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        [Trait("Category", "Employee")]
        public void Employee_SetHelthPlan_Success()
        {
            #region Arrange
            var employee = _employeeTestFixture.CreateValidEmployee();

            /* Mocking the objects 
            Interface is a more real way to get closer to reality than implementation */
            var employeeRepository = new Mock<IEmployeeRepository>();
            var mediator = new Mock<IMediator>();

            // Using mock objects to instantiate a service
            var benefitsService = new BenefitsService(employeeRepository.Object, mediator.Object);
            #endregion

            // Act
            benefitsService.ChooseHealthPlan(employee, Lib.HealthPlan.Plan123);

            #region  Assert
            // Check if method update from EmployeeRepository is called just one time
            employeeRepository.Verify(method => method.Update(employee), times: Times.Once);
            // Check if mediator throw once any notification inheriting of INotification 
            mediator.Verify(method =>
                method.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);
            #endregion
        }
    }
}
