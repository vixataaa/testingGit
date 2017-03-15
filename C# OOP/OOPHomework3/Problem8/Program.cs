using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTimer timer = new MyTimer(500);

            MyTimerSubscriber sub1 = new MyTimerSubscriber();
            sub1.SubscribeTo(timer);

            MyTimerSubscriber sub2 = new MyTimerSubscriber();
            ////
            OtherMyTimerSubscriber sub3 = new OtherMyTimerSubscriber();
            sub3.SubscribeTo(timer);

            timer.Start();

            Console.WriteLine($"sub1 - subscribed - Number = {sub1.Number}");       //handles event by adding 1
            Console.WriteLine($"sub2 - not subscribed - Number = {sub2.Number}");
            Console.WriteLine($"sub3 - subscribed - Number = {sub3.Number}");       //OtherTimerSub handles event by multiplying by 2


        }
    }
}
