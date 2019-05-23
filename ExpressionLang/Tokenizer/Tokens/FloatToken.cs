using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class FloatToken : IToken
    {
        public TokenType TokenType => TokenType.Float;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public FloatToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
