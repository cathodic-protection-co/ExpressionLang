using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class Expression
    {
        public abstract int StartLine { get; set; }
        public abstract int StartColumn { get; set; }

        public abstract int EndLine { get; set; }
        public abstract int EndColumn { get; set; }

        public abstract IExpression<T> As<T>();
    }
}
