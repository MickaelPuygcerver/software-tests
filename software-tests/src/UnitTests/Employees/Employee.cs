using System;
using System.Collections.Generic;

namespace UnitTests.Lib
{

    public class Employee : People
    {
        public Guid Id { get; set; }
        public decimal Salary { get; private set; }
        public ProfessionalLevel ProfessionalLevel { get; private set; }
        public IList<string> Skills { get; private set; }
        public HealthPlan HealthPlan { get; private set; }


        public Employee(string name, string surname, decimal salary, string email, DateTime bithDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = bithDate;

            SetSalary(salary);
            SetSkills();
        }

        public bool IsValid()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            var diff = DateTime.Now - BirthDate;
            int years = (zeroTime + diff).Year - 1;

            return years >= 16;
        }

        public void SetSalary(decimal salario)
        {
            if(salario < 500) throw new Exception("Salary less than allowed");

            Salary = salario;
            if (salario < 2000) ProfessionalLevel = ProfessionalLevel.Junior;
            else if (salario >= 2000 && salario < 8000) ProfessionalLevel = ProfessionalLevel.MidLevel;
            else if (salario >= 8000) ProfessionalLevel = ProfessionalLevel.Senior;
        }

        public void SetHelthPlan(HealthPlan healthPlan)
        {
            HealthPlan = healthPlan;
        }

        private void SetSkills()
        {
            var habilidadesBasicas = new List<string>()
            {
                "Programming logic",
                "OOP"
            };

            Skills = habilidadesBasicas;

            switch (ProfessionalLevel)
            {
                case ProfessionalLevel.MidLevel:
                    Skills.Add("Tests");
                    break;
                case ProfessionalLevel.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Microservices");
                    break;
            }
        }
    }

    public class EmployeeFactory
    {
        public static Employee Create(string name, string surname, decimal salary, string email, DateTime bithDate)
        {
            return new Employee(name, surname, salary, email, bithDate);
        }
    }
}