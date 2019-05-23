using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class IdentToken : IToken
    {
        public TokenType TokenType => TokenType.Ident;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public IdentToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
