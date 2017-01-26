using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Startup
    {
        static Random rnd = new Random();

        static string[] maleNames = { "Gosho", "Rexi", "Max", "Whiskas?", "Pesho", "Tosho" };
        static string[] femaleNames = { "Penka", "Marsi", "Dobrinka", "Todorka", "Sara", "Ariana" };
        static Gender[] genders = { Gender.Male, Gender.Female, Gender.Other };

        static Animal GenerateRandomAnimal()
        {
            int randomNumber = rnd.Next(0, 5);

            switch (randomNumber)
            {
                case 0:
                    Gender gender = genders[rnd.Next(0, 3)];
                    int age = rnd.Next(1, 20);
                    string name;
                    if(gender == Gender.Female)
                    {
                        name = femaleNames[rnd.Next(0, 6)];
                    }
                    else
                    {
                        name = maleNames[rnd.Next(0, 6)];
                    }

                    Cat cate = new Cat(name, age, gender);

                    return cate;

                case 1:
                    Gender dogGender = genders[rnd.Next(0, 3)];
                    int dogAge = rnd.Next(1, 20);
                    string dogName;
                    if (dogGender == Gender.Female)
                    {
                        dogName = femaleNames[rnd.Next(0, 6)];
                    }
                    else
                    {
                        dogName = maleNames[rnd.Next(0, 6)];
                    }

                    Dog doge = new Dog(dogName, dogAge, dogGender);

                    return doge;

                case 2:
                    Gender frogGender = genders[rnd.Next(0, 3)];
                    int frogAge = rnd.Next(1, 20);
                    string frogName;
                    if (frogGender == Gender.Female)
                    {
                        frogName = femaleNames[rnd.Next(0, 6)];
                    }
                    else
                    {
                        frogName = maleNames[rnd.Next(0, 6)];
                    }

                    Frog froge = new Frog(frogName, frogAge, frogGender);

                    return froge;

                case 3:
                    int kittenAge = rnd.Next(1, 3);
                    string kittenName = femaleNames[rnd.Next(0, 6)];

                    Kitten kitty = new Kitten(kittenName, kittenAge);

                    return kitty;

                case 4:
                    int tomcatAge = rnd.Next(1, 3);
                    string tomcatName = maleNames[rnd.Next(0, 6)];

                    Tomcat tomcate = new Tomcat(tomcatName, tomcatAge);

                    return tomcate;

                default:
                    throw new ArgumentOutOfRangeException("random number", "Invalid random number");
            }
        }

        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            int animalsCount = 30;

            //fill list with random animals
            for(int i = 0; i < animalsCount; i++)
            {
                animals.Add(GenerateRandomAnimal());
            }

            //collect average age and count
            double[] dogCountAge = new double[2];
            double[] catCountAge = new double[2];
            double[] frogCountAge = new double[2];
            double[] kittenCountAge = new double[2];
            double[] tomcatCountAge = new double[2];

            //print whole list and add cout and age to above arrays
            foreach (var animal in animals)
            {
                if(animal is Dog)
                {
                    Console.WriteLine(animal + " -- Dog");
                    dogCountAge[0]++;
                    dogCountAge[1] += animal.Age;
                }
                else if (animal is Kitten)
                {
                    kittenCountAge[0]++;
                    kittenCountAge[1] += animal.Age;
                    Console.WriteLine(animal + " -- Kitten");
                }
                else if (animal is Tomcat)
                {
                    tomcatCountAge[0]++;
                    tomcatCountAge[1] += animal.Age;
                    Console.WriteLine(animal + " -- Tomcat");
                }
                else if(animal is Cat)
                {
                    catCountAge[0]++;
                    catCountAge[1] += animal.Age;
                    Console.WriteLine(animal + " -- Cat");
                }
                else
                {
                    frogCountAge[0]++;
                    frogCountAge[1] += animal.Age;
                    Console.WriteLine(animal + " -- Frog");
                }
            }

            //average ages print
            Console.WriteLine();
            Console.WriteLine("Average ages:");
            Console.WriteLine("Dogs : {0:F2}", dogCountAge[1] / dogCountAge[0]);
            Console.WriteLine("Cats : {0:F2}", catCountAge[1] / catCountAge[0]);
            Console.WriteLine("Frogs : {0:F2}", frogCountAge[1] / frogCountAge[0]);
            Console.WriteLine("Kittens : {0:F2}", kittenCountAge[1] / kittenCountAge[0]);
            Console.WriteLine("Tomcats : {0:F2}", tomcatCountAge[1] / tomcatCountAge[0]);
        }
    }
}
