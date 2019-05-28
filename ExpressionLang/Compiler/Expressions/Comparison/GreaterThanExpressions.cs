using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class GreaterThanExpression<T> : Expression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public GreaterThanExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntGreaterThanExpression : GreaterThanExpression<int>
    {
        public IntGreaterThanExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() > Right.Evaluate();
    }

    public class FloatGreaterThanExpression : GreaterThanExpression<float>
    {
        public FloatGreaterThanExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() > Right.Evaluate();
    }
}
