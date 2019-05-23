using ExpressionLang.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public class FloatLiteralExpression : Expression, IExpression<float>
    {
        private float Value { get; }

        public FloatLiteralExpression(IToken token)
        {
            StartLine = token.LineNumber;
            StartColumn = token.ColumnNumber;
            EndLine = token.LineNumber;
            EndColumn = token.ColumnNumber;

            Value = float.Parse(token.Text);
        }

        public float Evaluate()
        {
            return Value;
        }
    }
}
