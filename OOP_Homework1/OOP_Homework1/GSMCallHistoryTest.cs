using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Homework1
{
    class GSMCallHistoryTest
    {
        private GSM gsm;
        private int numberOfCalls;

        public GSMCallHistoryTest(int numberOfCalls)
        {
            this.gsm = new GSM("10", "HTC");
            this.numberOfCalls = numberOfCalls;
        }   //constructor, requires number of calls in call history

        public void FillCallHistory()
        {
            Random rnd = new Random();

            for (int i = 0; i < this.numberOfCalls; i++)
            {
                string tmpDialedNumber = String.Format("+3598" + "{0}", rnd.Next(70000000, 99999999));
                int tmpDuration = rnd.Next(1, 200);

                this.gsm.AddCall(new Call(tmpDialedNumber, tmpDuration));
            }
        }   //randomly fills call history
        public void PrintCallHistory()
        {
            if (numberOfCalls > 0)
            {
                foreach (var item in this.gsm.CallHistory)
                {
                    Console.WriteLine();
                    Console.WriteLine(item.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Call history empty");
            }
        }   //prints the call history
        public double CallPrice(double price)
        {
            return this.gsm.CallPrice(price);
        }   //price of calls
        public void RemoveLongestCall()
        {
            int index = 0;
            double maxDuration = 0;

            for (int i = 0; i < numberOfCalls; i++)
            {
                if (this.gsm.CallHistory[i].Duration > maxDuration)
                {
                    maxDuration = this.gsm.CallHistory[i].Duration;
                    index = i;
                }
            }
            this.gsm.RemoveCall(index);
            numberOfCalls--;
        }   //removes longest call from the list
        public void ClearHistory()
        {
            this.gsm.ClearCallHistory();
            numberOfCalls = 0;
        }   //clears history
    }
}
