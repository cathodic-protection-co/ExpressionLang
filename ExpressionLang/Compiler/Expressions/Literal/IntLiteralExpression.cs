using ExpressionLang.Tokenizer;
using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Literal
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

        public IntLiteralExpression(int val, int startLine, int startColumn, int endLine, int endColumn)
        {
            StartLine = startLine;
            StartColumn = startColumn;
            EndLine = endLine;
            EndColumn = endColumn;

            Value = val;
        }

        public int Evaluate()
        {
            return Value;
        }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) == typeof(int))
                return (IExpression<T>)this;
            else if (typeof(T) == typeof(float))
                return (IExpression<T>)(new FloatLiteralExpression((float)Value, StartLine, StartColumn, EndLine, EndColumn));
            else
                throw new InvalidCastException($"Can't cast from type float to type {typeof(T)}");
        }
    }
}
