using System;

namespace OOP_Homework1
{
    class Call
    {
        private DateTime dateTime;
        private string dialedNumber;
        private double duration;
        //fields

        public Call(string dialedNumber, int duration)
        {
            this.dateTime = DateTime.Now;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }   //constructor

        public double Duration
        {
            get
            {
                return this.duration;
            }
        }   //duration property

        public override string ToString()
        {
            return String.Format("Date and time: {0} \nDialed number: {1} \nDuration(seconds): {2}", this.dateTime.ToString(), this.dialedNumber, this.duration);
        }   //call info toString
    }
}
