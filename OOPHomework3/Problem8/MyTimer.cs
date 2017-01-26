using System;
using System.Timers;
using System.Threading;

namespace Problem8
{
    public class MyTimer
    {
        public event EventHandler Raise;    //event that is going to be raised

        public double Interval { get; private set; }    //interval for the Thread.Sleep

        public MyTimer(int interval)
        {
            this.Interval = interval;
        }//Constructor to set interval

        public void Start()
        {
            Console.WriteLine($"Raising event every {this.Interval / 1000} second(s).");
            Console.WriteLine("Press a key to stop.");
            while(!Console.KeyAvailable)
            {
                Notify(this, new EventArgs());
                Thread.Sleep((int)this.Interval);
            }
        }   //When called, calls the function responsible for raising the event and then Thread.Sleeps
            //Loop keeps going until a key is pressed 

        public void Notify(object sender, EventArgs e)
        {
            if(Raise != null)
            {
                Raise.Invoke(this, e);
                //Console.WriteLine();
            }
        }   //Raises the event
    }
}
