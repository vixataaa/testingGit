using System;
using CreatePerson.Factories;

namespace CreatePerson
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var malePerson = PersonFactory.CreatePerson(22);
            var femalePerson = PersonFactory.CreatePerson(21);

            Console.WriteLine(malePerson.Name);
            Console.WriteLine(femalePerson.Name);
        }
    }
}
