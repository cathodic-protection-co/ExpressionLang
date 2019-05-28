using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class DivisionExpression<T> : Expression, IExpression<T>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public DivisionExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract T Evaluate();
    }

    public class IntDivisionExpression : DivisionExpression<int>
    {
        public IntDivisionExpression(IExpression<int> left, IExpression<int> right) : base (left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override int Evaluate()
        {
            return Left.Evaluate() / Right.Evaluate();
        }
    }

    public class FloatDivisionExpression : DivisionExpression<float>
    {
        public FloatDivisionExpression(IExpression<float> left, IExpression<float> right) : base(left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override float Evaluate()
        {
            return Left.Evaluate() / Right.Evaluate();
        }
    }
}
