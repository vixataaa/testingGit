using System;

namespace OOP_Homework1
{
    class GSMTest
    {
        private GSM[] gsmArray; //array containing GSMs
        
        public GSMTest(int numberOfGSMs)
        {
            this.gsmArray = new GSM[numberOfGSMs];
        }   //constructor

        public void GenerateGSMs()
        {
            string[] manufacturers = { "Samsung", "iPhone", "HTC", "Motorola", "OnePlus", "Huawei", "LG", "Sony" };

            Random rnd = new Random();

            for(int i = 0; i < this.gsmArray.Length; i++)
            {
                this.gsmArray[i] = new GSM(String.Format("Model {0}", rnd.Next(0, 400)), manufacturers[rnd.Next(0, 7)]);
                this.gsmArray[i].Price = rnd.Next(50, 1000);
                this.gsmArray[i].Owner = String.Format("User#{0}", rnd.Next(0, 500));
                this.gsmArray[i].Battery = new Battery(String.Format("Model: {0}", rnd.Next(0, 15)), rnd.Next(10, 100), rnd.Next(10, 100), (BatteryType)rnd.Next(1, 4));
                this.gsmArray[i].Display = new Display(rnd.Next(3, 7), rnd.Next(65000, 16000000));
            }


        }   //randomly fills the array with GSMs
        public GSM[] GetGSMs
        {
            get
            {
                return this.gsmArray;
            }
        }   //return the array
        public void IPhone4S()
        {
            Console.WriteLine(GSM.IPhone4S.ToString());
        }

    }
}
