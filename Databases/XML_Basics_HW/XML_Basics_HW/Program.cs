using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XML_Basics_HW.Models;
using XML_Basics_HW.Processors;

namespace XML_Basics_HW
{
    class Program
    {
        static void Main()
        {
            // Read all
            var reader = XmlReader.Create(@"..\..\students.xml");

            var readProcessor = new Reader();

            var result = readProcessor.GetAllStudents(reader);

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            // Write
            var writer = XmlWriter.Create(@"..\..\output.xml");

            var writeProcessor = new Writer();
            var studentToAdd = new Student()
            {
                Name = "Gosho",
                Sex = "1999 Ford Focus",
                Phone = "123456789"
            };

            writeProcessor.AddNewStudent(result, writer);
        }
    }
}