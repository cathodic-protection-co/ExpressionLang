using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public class OrExpression : UnaryExpression, IExpression<bool>
    {
        internal IExpression<bool> Left { get; }
        internal IExpression<bool> Right { get; }

        public OrExpression(IExpression<bool> left, IExpression<bool> right)
            : base(left.StartLine, left.StartColumn, right.EndLine, right.EndColumn)
        {
            Left = left;
            Right = right;
        }

        public bool Evaluate()
        {
            return Left.Evaluate() || Right.Evaluate();
        }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }
    }
}
