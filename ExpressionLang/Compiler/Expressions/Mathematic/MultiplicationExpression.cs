using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class MultiplicationExpression<T> : Expression, IExpression<T>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public MultiplicationExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract T Evaluate();
    }

    public class IntMultiplicationExpression : MultiplicationExpression<int>
    {
        public IntMultiplicationExpression(IExpression<int> left, IExpression<int> right) : base (left, right)
        {

        }

        public override int Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }
    }

    public class FloatMultiplicationExpression : MultiplicationExpression<float>
    {
        public FloatMultiplicationExpression(IExpression<float> left, IExpression<float> right) : base (left, right)
        {

        }

        public override float Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }
    }
}
