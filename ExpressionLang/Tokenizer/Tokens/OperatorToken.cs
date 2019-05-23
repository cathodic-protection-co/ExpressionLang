using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer.Tokens
{
    public class OperatorToken : IToken
    {
        public TokenType TokenType => TokenType.Operator;
        public string Text { get; }
        public int LineNumber { get; }
        public int ColumnNumber { get; }

        public OperatorToken(string text, int lineNumber, int columnNumber)
        {
            Text = text;
            LineNumber = lineNumber;
            ColumnNumber = columnNumber;
        }
    }
}
