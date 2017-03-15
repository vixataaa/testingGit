using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Startup
    {
        static void Main(string[] args)
        {
            School leSchool = new School("Telerik");

            Student gosho = new Student("Gosho", "badboy");
            Student pesho = new Student("Pesho");
            Student tosho = new Student("Tosho", "nerd");
            Student stoqn = new Student("Stoqn", "c# master", "has a doge");

            Student strahil = new Student("Strahil");
            Student penka = new Student("Penka");
            Student petq = new Student("Petq", "short");
            Student stoqnka = new Student("Stoqnka");
            Student sara = new Student("Sara");

            Discipline math = new Discipline("Math", 10, 5, "Annoying");
            Discipline history = new Discipline("History", 10, 0);
            Discipline biology = new Discipline("Biology", 10, 15);
            Discipline chemistry = new Discipline("Chemistry", 5, 15);
            Discipline physics = new Discipline("Physics", 10, 10, "Something");

            Teacher stoqnov = new Teacher("G-n Stoqnov", "Surov no spravedliv");
            stoqnov.AddDiscipline(math);
            stoqnov.AddDiscipline(chemistry);
            stoqnov.AddDiscipline(physics);

            Teacher stoqnova = new Teacher("G-ja Stoqnova");
            stoqnova.AddDiscipline(history);
            stoqnova.AddDiscipline(biology);

            Teacher goshov = new Teacher("G-n Goshov");
            goshov.AddDiscipline(physics);
            goshov.AddDiscipline(chemistry);            

            Teacher goshova = new Teacher("G-ca Goshova");
            goshova.AddDiscipline(biology);
            goshova.AddDiscipline(history);
            goshova.AddDiscipline(math);


            //
            ClassOfStudents sedmiA = new ClassOfStudents("7a");
            sedmiA.AddTeacher(stoqnov);
            sedmiA.AddTeacher(stoqnova);

            sedmiA.AddStudent(gosho);
            sedmiA.AddStudent(pesho);
            sedmiA.AddStudent(tosho);
            sedmiA.AddStudent(stoqn);


            ClassOfStudents sedmiB = new ClassOfStudents("7b", "best class ever?");
            sedmiB.AddTeacher(goshov);
            sedmiB.AddTeacher(goshova);

            sedmiB.AddStudent(strahil);
            sedmiB.AddStudent(penka);
            sedmiB.AddStudent(petq);
            sedmiB.AddStudent(stoqnka);
            sedmiB.AddStudent(sara);

            leSchool.AddClass(sedmiA);
            leSchool.AddClass(sedmiB);
            //print
            Console.WriteLine(leSchool);
        }
    }
}
