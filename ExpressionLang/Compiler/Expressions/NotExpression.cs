using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public class NotExpression : UnaryExpression, IExpression<bool>
    {
        public NotExpression(Expression expression)
            : base(0, 0, 0, 0)
        {
            // Something
        }

        public override IExpression<T> As<T>()
        {
            throw new NotImplementedException();
        }

        public bool Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
