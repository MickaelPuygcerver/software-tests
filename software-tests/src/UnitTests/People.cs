namespace UnitTests.Lib
{
    public class People
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Nickname { get; set; }

        public string GetFullName()
        {
            return $"{Name} {Surname}";
        }
    }
}