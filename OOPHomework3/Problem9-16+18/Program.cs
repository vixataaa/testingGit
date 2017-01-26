using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_16_18
{
    class Program
    {
        static void Problem9()
        {
            var students = GenerateRandomStudents(20);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.Group.GroupNumber == 2
                                   orderby student.FirstName ascending
                                   select student;

            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");



        }//group number 2, by firstName

        static void Problem10()
        {
            var students = GenerateRandomStudents(20);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = students.Where(x => x.Group.GroupNumber == 2).OrderBy(x => x.FirstName);
            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");

        }//9 with extensions

        static void Problem11()
        {
            var students = GenerateRandomStudents(20);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.Email.Substring(student.Email.Length - 7) == "@abv.bg"
                                   select student;
            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");


        }//with @abv.bg

        static void Problem12()
        {
            var students = GenerateRandomStudents(30);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.PhoneNumber.Substring(0, 2) == "02"
                                   select student;

            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");

        }//with phones in sofia (start with "02")

        static void Problem13()
        {
            var students = GenerateRandomStudents(20);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.Marks.Contains(6)
                                   select new
                                   {
                                       FullName = student.FirstName + " " + student.LastName,
                                       Marks = student.Marks
                                   };

            foreach (var student in selectedStudents)
            {
                Console.WriteLine($"Full name: {student.FullName}");
                Console.WriteLine($"Marks: {String.Join(", ", student.Marks)}");
                Console.WriteLine("___________");
            }
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");                               
        }//get marks 6

        static void Problem14()
        {
            var students = GenerateRandomStudents(100);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = students.Where(x => ContainedTwice(x.Marks, 2) == true);

            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");


            //var selectedStudents = students
        }//have exactly two "2"s

        static void Problem15()
        {
            var students = GenerateRandomStudents(30);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.FacultyNumber.Substring(4) == "06"
                                   select student.Marks;

            foreach (var mark in selectedStudents)
            {
                Console.WriteLine(String.Join(", ", mark));
            }

        }//marks of students year 2006 (FN ends with 06)

        static void Problem16()
        {
            var students = GenerateRandomStudents(30);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var selectedStudents = from student in students
                                   where student.Group.DepartmentName == "Mathematics"
                                   select student;

            PrintStudents(selectedStudents);
            Console.WriteLine(selectedStudents.Count() + "/" + students.Count + " selected.");

        }//in mathematics department.

        static void Problem18()
        {
            var students = GenerateRandomStudents(30);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var groupedStudents = from student in students
                                   group student by student.Group.GroupNumber;
                                   //select groupedStudents;

            foreach (var student in groupedStudents)
            {
                foreach (var grouped in student)
                {
                    Console.WriteLine(grouped);
                    Console.WriteLine();
                }
                Console.WriteLine("_________________");
            }
        }//groups by groupNumber (linq)

        static void Problem19()
        {
            var students = GenerateRandomStudents(30);
            //Console.WriteLine("Initial");
            //PrintStudents(students);

            var groupedStudents = students.GroupBy(x => x.Group.GroupNumber);

            foreach (var student in groupedStudents)
            {
                foreach (var grouped in student)
                {
                    Console.WriteLine(grouped);
                    Console.WriteLine();
                }
                Console.WriteLine("_______________");
            }
        }//groups by groupNumber (extensions)


        static void Main(string[] args)
        {
            //Problem9();
            //Problem10();
            //Problem11();
            //Problem12();
            //Problem13();
            //Problem14();
            //Problem15();
            //Problem16();
            //Problem18();
            //Problem19();
        }

        static List<Student> GenerateRandomStudents(int count)
        {
            List<Student> result = new List<Student>();

            string[] firstNames = { "Pesho", "Stoqn", "Georgi", "Todor", "Martin", "Balkan", "Zahari" };
            string[] lastNames = { "Peshov", "Stoqnov", "Georgiev", "Todorov", "Martinov", "Balkanov", "Zahariev" };
            string[] mails = { "@abv.bg", "@gmail.com", "@yahoo.com", "@telerikacademy.com" };
            string[] departNames = { "Mathematics", "Architecture", "Politics", "Law", "Chemistry", "Physics", "History" };

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                string fName = firstNames[rnd.Next(0, firstNames.Length - 1)];
                string lName = lastNames[rnd.Next(0, lastNames.Length - 1)];

                string first4DigitsFN = rnd.Next(1000, 9999).ToString();
                string digit5FN = rnd.Next(0, 1).ToString();
                string digit6FN = rnd.Next(0, 7).ToString();
                string facultyNumb = first4DigitsFN + digit5FN + digit6FN;

                string phoneNumber = "0" + rnd.Next(1,9).ToString() + "-" + rnd.Next(111111, 999999).ToString();

                string email = fName.ToLower() + "_" + lName.ToLower() + mails[rnd.Next(0, mails.Length - 1)];

                List<double> marks = GenerateMarksList(4);

                Group group = new Group(rnd.Next(1, 6), departNames[rnd.Next(0, departNames.Length - 1)]);

                Student newStudent = new Student(fName, lName, facultyNumb, phoneNumber, email, marks, group);

                result.Add(newStudent);
            }

            return result;
        }

        static List<double> GenerateMarksList(int count)
        {
            List<double> result = new List<double>();

            Random rnd = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                result.Add(rnd.Next(2, 7));
            }

            return result;
        }

        static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine("_____________________");
            }
        }

        static bool ContainedTwice(IEnumerable<double> marks, double searchedMark)
        {
            int count = 0;

            foreach (var mark in marks)
            {
                if(mark == searchedMark)
                {
                    count++;
                }
            }

            if(count == 2)
            {
                return true;
            }

            return false;
        }
    }
}
