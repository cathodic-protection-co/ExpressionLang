using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class NotEqualsExpression<T> : Expression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public NotEqualsExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntNotEqualsExpression : NotEqualsExpression<int>
    {
        public IntNotEqualsExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }
        public override bool Evaluate() => Left.Evaluate() != Right.Evaluate();
    }

    public class FloatNotEqualsExpression : NotEqualsExpression<float>
    {
        public FloatNotEqualsExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }
        public override bool Evaluate() => Left.Evaluate() != Right.Evaluate();
    }
}
