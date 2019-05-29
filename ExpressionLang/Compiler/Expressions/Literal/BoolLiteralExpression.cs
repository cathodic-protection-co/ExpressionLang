using ExpressionLang.Tokenizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Literal
{
    public class BoolLiteralExpression : LiteralExpression, IExpression<bool>
    {
        private bool Value { get; }

        /// <summary>
        /// Constructor used for literals (not variables).
        /// </summary>
        public BoolLiteralExpression(IToken token)
            : base(token.LineNumber, token.ColumnNumber, token.LineNumber, token.ColumnNumber)
        {
            Value = bool.Parse(token.Text);
        }

        /// <summary>
        /// Constructor used for variable identifiers.
        /// </summary>
        public BoolLiteralExpression(bool val, int startLine, int startColumn, int endLine, int endColumn)
            : base(startLine, startColumn, endLine, endColumn)
        {
            Value = val;
        }

        public bool Evaluate()
        {
            return Value;
        }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) == typeof(bool))
                return (IExpression<T>)this;
            else
                throw new InvalidCastException($"Can't cast from type bool to type {typeof(T)}");
        }
    }
}
