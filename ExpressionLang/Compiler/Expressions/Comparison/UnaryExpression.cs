using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public class UnaryExpression : Expression
    {
        public override int StartLine { get; set; }
        public override int StartColumn { get; set; }
        public override int EndLine { get; set; }
        public override int EndColumn { get; set; }

        public UnaryExpression(int startLine, int startColumn, int endLine, int endColumn)
        {
            StartLine = startLine;
            StartColumn = startColumn;
            EndLine = endLine;
            EndColumn = endColumn;
        }

        public override IExpression<T> As<T>()
        {
            throw new NotImplementedException();
        }
    }
}
