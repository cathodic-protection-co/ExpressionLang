using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Mathematic
{
    public abstract class AdditionExpression<T> : BinaryExpression, IExpression<T>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public AdditionExpression(IExpression<T> left, IExpression<T> right)
            : base (left.StartLine, left.StartColumn, right.EndLine, right.EndColumn)
        {
            Left = left;
            Right = right;
        }

        public abstract T Evaluate();
    }

    public class IntAdditionExpression : AdditionExpression<int>
    {
        public IntAdditionExpression(IExpression<int> left, IExpression<int> right) : base (left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override int Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }

    public class FloatAdditionExpression : AdditionExpression<float>
    {
        public FloatAdditionExpression(IExpression<float> left, IExpression<float> right) : base(left, right)
        {

        }

        public override IExpression<T> As<T>()
        {
            return (IExpression<T>)this;
        }

        public override float Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }
}
