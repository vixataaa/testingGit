using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XML_Basics_HW.Models;

namespace XML_Basics_HW.Processors
{
    public class Reader
    {
        public Reader()
        {

        }

        public IList<Student> GetAllStudents(XmlReader reader)
        {
            var students = new List<Student>();

            using (reader)
            {
                string name = string.Empty;
                string sex = string.Empty;
                string phone = string.Empty;

                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "name")
                    {
                        reader.Read();
                        name = reader.Value;
                    }

                    if (reader.IsStartElement() && reader.Name == "sex")
                    {
                        reader.Read();
                        sex = reader.Value;
                    }

                    if (reader.IsStartElement() && reader.Name == "phone")
                    {
                        reader.Read();
                        phone = reader.Value;
                    }

                    if (name != string.Empty &&
                        sex != string.Empty &&
                        phone != string.Empty)
                    {
                        students.Add(new Student()
                        {
                            Name = name,
                            Sex = sex,
                            Phone = phone
                        });

                        name = string.Empty;
                        sex = string.Empty;
                        phone = string.Empty;
                    }
                }

                return students;
            }
        }
    }
}
