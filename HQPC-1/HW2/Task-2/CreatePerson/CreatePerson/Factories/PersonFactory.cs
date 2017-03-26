using System;
using CreatePerson.Constants;
using CreatePerson.Contracts;
using CreatePerson.Enumerations;
using CreatePerson.Models;

namespace CreatePerson.Factories
{
    public static class PersonFactory
    {
        /// <summary>
        /// Returns a new person instance with gender based on number passed
        /// </summary>
        /// <param name="magicalNumber"></param>
        /// <returns>Person</returns>
        public static IPerson CreatePerson(int magicalNumber)
        {
            bool numberIsEven = (magicalNumber % 2) == 0;

            string name;
            Gender gender;
            Random random = new Random();

            if (numberIsEven)
            {
                name = Names.MALE_NAMES[random.Next(0, 5)];
                gender = Gender.Male;
            }
            else
            {
                name = Names.FEMALE_NAMES[random.Next(0, 5)];
                gender = Gender.Female;
            }

            int age = magicalNumber;

            return new Person(name, age, gender);
        }
    }
}
