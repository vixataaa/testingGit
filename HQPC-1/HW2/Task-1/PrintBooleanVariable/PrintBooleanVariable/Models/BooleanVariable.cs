using System;
using PrintBooleanVariable.Contracts;

namespace PrintBooleanVariable.Models
{
    public class BooleanVariable : IPrintable
    {
        public BooleanVariable(bool booleanVariable)
        {
            this.VariableValue = booleanVariable;
        }

        public bool VariableValue { get; set; }

        public string StringValue
        {
            get
            {
                return this.VariableValue.ToString();
            }
        }
    }
}
