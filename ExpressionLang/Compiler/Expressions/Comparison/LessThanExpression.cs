using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class LessThanExpression<T> : Expression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public LessThanExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntLessThanExpression : LessThanExpression<int>
    {
        public IntLessThanExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate() => Left.Evaluate() < Right.Evaluate();
    }

    public class FloatLessThanExpression : LessThanExpression<float>
    {
        public FloatLessThanExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate() => Left.Evaluate() < Right.Evaluate();
    }
}
