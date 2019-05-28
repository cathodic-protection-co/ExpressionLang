using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class LogicalToken : IToken
    {
        public TokenType TokenType { get; }
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public LogicalToken(string text, int lineNumber, int columnNumber, TokenType type)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
            TokenType = type;
        }
    }
}
