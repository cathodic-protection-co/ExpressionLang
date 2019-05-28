using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public interface IExpression<T>
    {
        T Evaluate();

        int StartLine { get; }
        int StartColumn { get; }

        int EndLine { get; }
        int EndColumn { get; }
    }
}
