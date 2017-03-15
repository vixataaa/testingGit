using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8
{
    class OtherMyTimerSubscriber
    {
        private MyTimer timer;  //Timer which eventually to subscribe to

        public int Number { get; private set; }

        public OtherMyTimerSubscriber()
        {
            this.Number = 1;
        }

        public void SubscribeTo(MyTimer timer)
        {
            this.timer = timer; //sets to use the given timer
            this.timer.Raise += this.HandleMyTimerEvent;    //adds the event handler
        }

        public void HandleMyTimerEvent(object sender, EventArgs e)
        {
            this.Number *= 2;
            //Console.WriteLine(this.Number);
        }
    }
}
