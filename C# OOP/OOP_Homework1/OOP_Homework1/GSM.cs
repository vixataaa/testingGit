using System;
using System.Collections.Generic;

namespace OOP_Homework1
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        private static GSM IPhone4s = new GSM("4S", "iPhone", 42.5, "iPhone 4S user",
                                      new Battery("iPhone battery", 200, 14, BatteryType.LiPo),
                                      new Display(3.5, 16000000));  //iPhone 4S static field
        //fields

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = 0;
            this.owner = null;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }   //model, manuf
        public GSM(string model, string manufacturer, double price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = null;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }   //model, manuf, price
        public GSM(string model, string manufacturer, double price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = new Battery();
            this.display = new Display();
            this.callHistory = new List<Call>();
        }   //model, manuf, price, owner
        public GSM(string model, string manufacturer, double price, string owner, Battery battery)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = new Display();
            this.callHistory = new List<Call>();
        }   //model, manuf, price, owner, battery
        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            this.callHistory = new List<Call>();
        }  //model, manuf, price, owner, battery, display
        //constructors

        public override string ToString()
        {
            return String.Format("Model: {0} \nManufacturer: {1} \nPrice: {2} \nOwner: {3} \n{4} \n{5}",
                this.model, this.manufacturer, this.price, this.owner, this.battery.ToString(), this.display.ToString());
        }   //ToString() override for GSM

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }   //model property
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }   //manufacturer property
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }   //price property
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }   //owner property
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }   //battery property
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }   //display property
        public static GSM IPhone4S
        {
            get
            {
                return GSM.IPhone4s;
            }
        }   //iphone4s property
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }   //callHistory property

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }   //add call to history
        public void RemoveCall(int index)
        {
            this.callHistory.RemoveAt(index);
        }   //removes from history by index
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }   //clears call history
        public double CallPrice(double price)
        {
            double result = 0;

            for(int i = 0; i < this.callHistory.Count; i++)
            {
                result += (this.callHistory[i].Duration * price);
            }

            return result;
        }   //calculates total call price from history
        


    }
}
