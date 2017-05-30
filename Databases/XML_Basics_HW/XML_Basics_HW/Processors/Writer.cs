using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XML_Basics_HW.Models;

namespace XML_Basics_HW.Processors
{
    public class Writer
    {
        public Writer()
        {

        }

        public void AddNewStudent(IList<Student> students, XmlWriter writer)
        {
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("students");

                foreach (var student in students)
                {
                    writer.WriteStartElement("student");

                    writer.WriteStartElement("name");
                    writer.WriteString(student.Name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("sex");
                    writer.WriteString(student.Sex);
                    writer.WriteEndElement();

                    writer.WriteStartElement("phone");
                    writer.WriteString(student.Phone);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }


                writer.WriteEndDocument();
            }
        }
    }
}
