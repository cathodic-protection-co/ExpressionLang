using ExpressionLang.Tokenizer;
using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Literal
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

        public FloatLiteralExpression(float val, int startLine, int startColumn, int endLine, int endColumn)
        {
            StartLine = startLine;
            StartColumn = startColumn;
            EndLine = endLine;
            EndColumn = endColumn;

            Value = val;
        }

        public float Evaluate()
        {
            return Value;
        }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) == typeof(float))
                return (IExpression<T>)this;
            else if (typeof(T) == typeof(int))
                return (IExpression<T>)(new IntLiteralExpression((int)Value, StartLine, StartColumn, EndLine, EndColumn));
            else
                throw new InvalidCastException($"Can't cast from type float to type {typeof(T)}");
        }
    }
}
