using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class Expression
    {
        internal int StartLine;
        internal int StartColumn;

        internal int EndLine;
        internal int EndColumn;

        public abstract IExpression<T> As<T>();
    }
}
