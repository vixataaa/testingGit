using System;
using PrintBooleanVariable.Models;

namespace PrintBooleanVariable
{
    public class Startup
    {
        public static void Main()
        {
            var variable = new BooleanVariable(false);
            var variablePrinter = new VariablePrinter(variable);

            variablePrinter.Print();
        }
    }
}
