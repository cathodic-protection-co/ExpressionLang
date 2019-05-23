using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class EqualsExpression<T> : Expression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public EqualsExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntEqualsExpression : EqualsExpression<int>
    {
        public IntEqualsExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }
        public override bool Evaluate() => Left.Evaluate() == Right.Evaluate();
    }

    public class FloatEqualsExpression : EqualsExpression<float>
    {
        public FloatEqualsExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }
        public override bool Evaluate() => Left.Evaluate() == Right.Evaluate();
    }
}
