using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler
{
    public interface IVariable<T>
    {
        T Value { get; set; }
    }

    public abstract class Variable
    {
        public string Identifier { get; set; }

        public Variable()
        {

        }

        public Variable(string ident)
        {
            Identifier = ident;
        }
    }

    public class FloatVariable : Variable, IVariable<float>
    {
        public float Value { get; set; }

        public FloatVariable()
        {

        }

        public FloatVariable(string ident, float val) : base (ident)
        {
            Value = val;
        }
    }

    public class BoolVariable : Variable, IVariable<bool>
    {
        public bool Value { get; set; }

        public BoolVariable()
        {

        }

        public BoolVariable(string ident, bool val) : base (ident)
        {
            Value = val;
        }
    }
}
