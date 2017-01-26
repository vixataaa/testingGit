using System;

namespace OOP_Homework1
{
    class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;
        //fields

        public Battery()
        {
            this.model = null;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
            this.batteryType = BatteryType.none;
        }   //default        

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }   //with parameters

        public override string ToString()
        {
            return String.Format("Battery model: {0} \nHours Idle: {1} \nTalk time: {2} \nBattery type: {3}",
                this.model, this.hoursIdle, this.hoursTalk, this.batteryType);
        }   //toString() override for Battery

        public string BatteryModel
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
        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }   //hoursIdle property
        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }   //hoursTalk property
        public BatteryType BatteryType
        {
            set
            {
                this.batteryType = value;
            }
            get
            {
                return this.batteryType;
            }
        }   //battery type property
    }
}
