using System;
using System.Collections.Generic;

namespace UnitTests.Lib
{

    public class Employee : People
    {
        public double Salary { get; private set; }
        public ProfessionalLevel ProfessionalLevel { get; private set; }
        public IList<string> Skills { get; private set; }

        public Employee(string name, double surname)
        {
            Name = string.IsNullOrEmpty(name) ? "NoName" : name;
            SetSalary(surname);
            SetSkills();
        }

        public bool IsValid()
        {
            return true;
        }

        public void SetSalary(double salario)
        {
            if(salario < 500) throw new Exception("Salary less than allowed");

            Salary = salario;
            if (salario < 2000) ProfessionalLevel = ProfessionalLevel.Junior;
            else if (salario >= 2000 && salario < 8000) ProfessionalLevel = ProfessionalLevel.MidLevel;
            else if (salario >= 8000) ProfessionalLevel = ProfessionalLevel.Senior;
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
        public static Employee Create(string name, double salary)
        {
            return new Employee(name, salary);
        }
    }
}