using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_4_5
{
    class Program
    {
        static void Main()
        {
            //Problem3();
            //Problem4();
            //Problem5LambdaExpressions();
            //Problem5LINQ();
        }//main

        static void Problem3()
        {
            var students = FilledList(20);

            Console.WriteLine("Initial list");
            Console.WriteLine();

            Print(students);

            var firstBeforeLastList = from student in students
                                      where student.FirstBeforeLast()
                                      select student;

            Console.WriteLine();
            Console.WriteLine("Only with first name before last");
            Console.WriteLine();

            Print(firstBeforeLastList);
        }//Problem 3

        static void Problem4()
        {
            var students = FilledList(20);

            Console.WriteLine("Initial list");
            Console.WriteLine();

            Print(students);

            var studentsBetween18n24 = from student in students
                                       where student.Age >= 18 && student.Age <= 24
                                       select student;

            Console.WriteLine();
            Console.WriteLine("Between age 18 and 24");
            Console.WriteLine();

            Print(studentsBetween18n24);
        }//Problem 4

        static void Problem5LambdaExpressions()
        {
            var students = FilledList(20);

            Console.WriteLine("Initial");
            Print(students);

            Console.WriteLine();
            Console.WriteLine("Sorted with lambda");
            Console.WriteLine();
            var sorted = students.OrderByDescending(student => student.FirstName).ThenBy(student => student.LastName);

            Print(sorted);
                       
        }//Problem 5

        static void Problem5LINQ()
        {
            var students = FilledList(20);
            Console.WriteLine("Initial");
            Print(students);

            Console.WriteLine();
            Console.WriteLine("Sorted with LINQ");
            Console.WriteLine();

            var sorted = from student in students
                         orderby student.FirstName, student.LastName
                         select student;

            Print(sorted);                       

        }

        static List<Student> FilledList(int count)
        {
            List<Student> students = new List<Student>();

            bool setRandomly = true;

            for (int i = 0; i < count; i++)
            {
                students.Add(new Student(setRandomly));
            }

            return students;
        }//fills list randomly

        static void Print(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine("__________________");
            }
        }
    }
}

