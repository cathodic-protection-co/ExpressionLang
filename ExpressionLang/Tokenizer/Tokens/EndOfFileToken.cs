using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class EndOfFileToken : IToken
    {
        public TokenType TokenType => TokenType.EndOfFile;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public EndOfFileToken(int lineNumber, int columnNumber)
        {
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
