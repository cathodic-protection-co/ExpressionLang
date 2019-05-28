using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class LessThanEqualsExpression<T> : UnaryExpression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public LessThanEqualsExpression(IExpression<T> left, IExpression<T> right)
            : base(left.StartLine, left.StartColumn, right.EndLine, right.EndColumn)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntLessThanEqualsExpression : LessThanEqualsExpression<int>
    {
        public IntLessThanEqualsExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() <= Right.Evaluate();
    }

    public class FloatLessThanEqualsExpression : LessThanEqualsExpression<float>
    {
        public FloatLessThanEqualsExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() <= Right.Evaluate();
    }
}
