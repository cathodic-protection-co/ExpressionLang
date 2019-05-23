using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class OpenBracketToken : IToken
    {
        public TokenType TokenType => TokenType.OpenBracket;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public OpenBracketToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }

    public class CloseBracketToken : IToken
    {
        public TokenType TokenType => TokenType.CloseBracket;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public CloseBracketToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
