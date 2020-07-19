using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Lib.Services
{
    public interface IBenefitsService
    {
        void ChooseHealthPlan(Employee employee, HealthPlan healthPlan);
    }
}
