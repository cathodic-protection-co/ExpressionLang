using ExpressionLang.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public class IntLiteralExpression : Expression, IExpression<int>
    {
        private int Value { get; }

        public IntLiteralExpression(IToken token)
        {
            StartLine = token.LineNumber;
            StartColumn = token.ColumnNumber;
            EndLine = token.LineNumber;
            EndColumn = token.ColumnNumber;

            Value = int.Parse(token.Text);
        }

        public int Evaluate()
        {
            return Value;
        }
    }
}
