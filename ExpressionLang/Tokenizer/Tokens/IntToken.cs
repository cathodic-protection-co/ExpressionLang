using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class IntToken : IToken
    {
        public TokenType TokenType => TokenType.Int;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public IntToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
