using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public class NotExpression : UnaryExpression, IExpression<bool>
    {
        private IExpression<bool> Right { get; set; }
        public NotExpression(IExpression<bool> expression)
            : base(0, 0, 0, 0)
        {
            Right = expression;
        }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }

        public bool Evaluate() => !Right.Evaluate();
    }
}
