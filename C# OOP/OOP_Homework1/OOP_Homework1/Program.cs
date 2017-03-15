using System;

namespace OOP_Homework1
{
    class Program
    {
        static void Main()
        {
            GSMTest tester = new GSMTest(15);   //new GSMTest instance containing array of 15 GSMs

            tester.GenerateGSMs();  //fills array in GSMs

            foreach (var item in tester.GetGSMs)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("______________________");
                Console.WriteLine();
            }   //random GSMs from GSMTester array containing GSMS

            tester.IPhone4S();  //iphone4s from GSM tester
            

            GSMCallHistoryTest cht = new GSMCallHistoryTest(6);
            cht.FillCallHistory();
            cht.PrintCallHistory();
            Console.WriteLine("Call price: {0}", cht.CallPrice(0.37));

            cht.RemoveLongestCall();
            
            Console.WriteLine("Call price after removal: {0}", cht.CallPrice(0.37));

            cht.ClearHistory();
            Console.WriteLine("Cleared");
            cht.PrintCallHistory();



        }
    }
}



