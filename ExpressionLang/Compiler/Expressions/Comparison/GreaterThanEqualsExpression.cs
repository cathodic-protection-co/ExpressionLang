using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class GreaterThanEqualsExpression<T> : Expression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public GreaterThanEqualsExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntGreaterThanEqualsExpression : GreaterThanEqualsExpression<int>
    {
        public IntGreaterThanEqualsExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() >= Right.Evaluate();
    }

    public class FloatGreaterThanEqualsExpression : GreaterThanEqualsExpression<float>
    {
        public FloatGreaterThanEqualsExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() >= Right.Evaluate();
    }
}
