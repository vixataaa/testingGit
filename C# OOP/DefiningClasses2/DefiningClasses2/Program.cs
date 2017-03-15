using System;
using Points;
using GenericList;
using Matrix;
using VersionAttribute;

namespace OOP_Homework2
{
    [CustomAttribute(6, 1)]
    class Program
    {
        public static T Min<T>(GenericList<T> list)
            where T : IComparable<T>
        {
            T result = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(result) < 0)
                {
                    result = list[i];
                }
            }

            return result;
        }   //min element in the list

        public static T Max<T>(GenericList<T> list)
    where T : IComparable<T>
        {
            T result = list[0];

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(result) > 0)
                {
                    result = list[i];
                }
            }

            return result;
        }   //max element in the list

        public static void Main()
        {
            Type type = typeof(Program);
            object[] allAttributes = type.GetCustomAttributes(true);

            Console.Write("Version: ");
            foreach (CustomAttribute attr in allAttributes)
            {
                Console.Write("{0}.{1}", attr.Major, attr.Minor);
            }
            Console.WriteLine();
            Console.WriteLine("------------");
            //prints version


            /*Path a = new Path();
            `
            for(int i = 0; i <= 10; i++)
            {
                a.AddPoint(new Point3D(i, i + 1, i + 2));
            }

            PathStorage.SaveToFile(a, "neshto.txt");

            a = PathStorage.LoadFromFile("neshto.txt");

            Console.WriteLine(a);
            //Points test
            */
            
            
            
            
            /*var list = new GenericList<int>(7);
            for (int i = 0; i <= 12; i++)
            {
                list.Add(i * 2);
            }

            list.Add(15);
            list.Add(5);
            list.Add(100);

            Console.WriteLine(Min<int>(list));
            Console.WriteLine(Max<int>(list));
            Console.WriteLine(list);
            //list test
            */
            
            
            
            
            Matrix<int> matr1 = new Matrix<int>(2, 3);
            Matrix<int> matr2 = new Matrix<int>(3, 2);

            matr1[0, 0] = 1;
            matr1[0, 1] = 2;
            matr1[0, 2] = 3;
            matr1[1, 0] = 4;
            matr1[1, 1] = 5;
            matr1[1, 2] = 6;

            matr2[0, 0] = 7;
            matr2[0, 1] = 8;
            matr2[1, 0] = 9;
            matr2[1, 1] = 10;
            matr2[2, 0] = 11;
            matr2[2, 1] = 12;

            //var result = matr1 + matr2;
            //Console.WriteLine(result);

            var result = matr1 * matr2;
            //result[0, 0] = 0;

            //Console.WriteLine(result);

            Console.WriteLine(result ? "matrix has no zero elements" : "there is a zero in the matrix");


            //matrices test

        }
    }
}

//true operator not done.
//attribute not done.