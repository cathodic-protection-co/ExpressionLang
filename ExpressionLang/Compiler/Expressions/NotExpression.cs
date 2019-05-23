using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public class NotExpression : Expression, IExpression<bool>
    {
        public NotExpression(Expression expression)
        {
            // Something
        }

        public bool Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
