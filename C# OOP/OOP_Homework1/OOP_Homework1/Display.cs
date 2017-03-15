using System;

namespace OOP_Homework1
{
    class Display
    {
        private double size;
        private int numberOfColors;
        //fields

        public Display()
        {
            this.size = 0;
            this.numberOfColors = 0;
        }   //default

        public Display(double size, int numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }   //with parameters

        public override string ToString()
        {
            return string.Format("Display size: {0} \nDisplay color number: {1}",
                this.size, this.numberOfColors);
        }   //ToString() override for Display

        public double Size
        {
            set
            {
                this.size = value;
            }
            get
            {
                return this.size;
            }
        }   //size property
        public int NumberOfColors
        {
            set
            {
                this.numberOfColors = value;
            }
            get
            {
                return this.numberOfColors;
            }
        }   //numberOfColors property
    }
}
