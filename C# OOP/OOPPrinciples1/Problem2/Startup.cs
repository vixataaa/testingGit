using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Startup
    {
        static void Main()
        {
            //students
            List<Student> students = new List<Student>();

            students.Add(new Student("Georgi", "Georgiev", 5));
            students.Add(new Student("Tosho", "Toshov", 2));
            students.Add(new Student("Pesho", "Peshov", 3));
            students.Add(new Student("Minka", "Minkova", 6));
            students.Add(new Student("Viktor", "Toshov", 3));
            students.Add(new Student("Martin", "Martinov", 2));
            students.Add(new Student("Nedqlko", "Nedqlkov", 5));
            students.Add(new Student("Petyr", "Petyrov", 5));
            students.Add(new Student("Todor", "Todorov", 3));
            students.Add(new Student("Mariq", "Todorova", 5));

            //sort by grade
            var sortedByGradeStudents = from student in students
                                        orderby student.Grade ascending
                                        select student;

            foreach (var student in sortedByGradeStudents)
            {
                Console.WriteLine(student);
                Console.WriteLine("Grade: {0}", student.Grade);
                Console.WriteLine();
            }

            Console.WriteLine("_____________________________");

            //workers
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Pesho", "Peshov", 100, 8));
            workers.Add(new Worker("Tosho", "Peshov", 500, 6));
            workers.Add(new Worker("Georgi", "Todorov", 666, 5));
            workers.Add(new Worker("Stoqn", "Georgiev", 777, 8));
            workers.Add(new Worker("Kolyo", "Stoqnov", 999, 12));
            workers.Add(new Worker("Gosho", "Kolev", 1200, 24));
            workers.Add(new Worker("Ivan", "Goshov", 5000, 11));
            workers.Add(new Worker("Grozdan", "Ivanov", 700, 10));
            workers.Add(new Worker("Mitko", "Grozdanov", 150, 5));
            workers.Add(new Worker("Dimityr", "Mitkov", 100, 2));

            //sort by money/hour
            var workersByMoneyPerHour = from worker in workers
                                        orderby worker.MoneyPerHour() descending
                                        select worker;

            foreach (var worker in workersByMoneyPerHour)
            {
                Console.WriteLine(worker);
                Console.WriteLine("{0:F2} per hour.", worker.MoneyPerHour());
                Console.WriteLine();
            }

            Console.WriteLine("____________________________");

            //merged
            List<Human> studentsAndWorkers = new List<Human>();
            studentsAndWorkers.AddRange(students);
            studentsAndWorkers.AddRange(workers);

            //sort by first name and last name
            var sortedStudentsAndWorkers = from person in studentsAndWorkers
                                           orderby person.FirstName, person.LastName
                                           select person;

            foreach (var person in sortedStudentsAndWorkers)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}
