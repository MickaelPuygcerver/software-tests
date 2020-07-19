using MediatR;
using UnitTests.Lib.Notification;
using UnitTests.Lib.Repository;

namespace UnitTests.Lib.Services
{
    public class BenefitsService : IBenefitsService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public BenefitsService(IEmployeeRepository employeeRepository,
            IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public void ChooseHealthPlan(Employee employee, HealthPlan healthPlan)
        {
            employee.SetHelthPlan(healthPlan);
            _employeeRepository.Update(employee);

            _mediator.Publish(new EmployeeEmailNotification(
                "no-reply@corporate.com",
                employee.Email,
                "Health Plan Approved",
                $"Congratulations {employee.Name}, your helth plan is aproved!"));
        }
    }
}
