using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class BoolToken : IToken
    {
        public TokenType TokenType => TokenType.Bool;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public BoolToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
