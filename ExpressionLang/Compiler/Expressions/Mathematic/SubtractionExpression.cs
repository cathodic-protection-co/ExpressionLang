using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class SubtractionExpression<T> : Expression, IExpression<T>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public SubtractionExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract T Evaluate();
    }

    public class IntSubtractionExpression : SubtractionExpression<int>
    {
        public IntSubtractionExpression(IExpression<int> left, IExpression<int> right) : base (left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override int Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }
    }

    public class FloatSubtractionExpression : SubtractionExpression<float>
    {
        public FloatSubtractionExpression(IExpression<float> left, IExpression<float> right) : base (left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override float Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }
    }
}
