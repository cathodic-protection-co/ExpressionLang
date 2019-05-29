using ExpressionLang.Tokenizer;
using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Literal
{
    public class FloatLiteralExpression : LiteralExpression, IExpression<float>
    {
        private float Value { get; }

        /// <summary>
        /// Constructor used for literals (not variables).
        /// </summary>
        public FloatLiteralExpression(IToken token)
            : base (token.LineNumber, token.ColumnNumber, token.LineNumber, token.ColumnNumber)
        {
            Value = float.Parse(token.Text);
        }

        /// <summary>
        /// Constructor used for variable identifiers.
        /// </summary>
        public FloatLiteralExpression(float val, int startLine, int startColumn, int endLine, int endColumn)
            : base (startLine, startColumn, endLine, endColumn)
        {
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
