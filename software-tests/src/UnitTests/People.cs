using System;

namespace UnitTests.Lib
{
    public class People
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Email { get; protected set; }

        public string GetFullName()
        {
            return $"{Name} {Surname}";
        }
    }
}