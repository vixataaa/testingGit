using System;
using PrintBooleanVariable.Contracts;

namespace PrintBooleanVariable
{
    public class VariablePrinter
    {
        public VariablePrinter(IPrintable variable)
        {
            this.Variable = variable;
        }

        public IPrintable Variable { get; set; }

        public void Print()
        {
            Console.WriteLine(this.Variable.StringValue);
        }
    }
}
