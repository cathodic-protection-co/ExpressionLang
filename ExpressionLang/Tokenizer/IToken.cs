using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Tokenizer
{
    public enum TokenType
    {
        EndOfFile,
        NewLine,
        Ignored,
        Operator,
        Ident,
        Int,
        Float,
        Bool,
        LogicalOr,
        LogicalAnd,
        Equals,
        NotEquals,
        LessThan,
        GreaterThan,
        LessThanEquals,
        GreaterThanEquals,
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Modulo,
        Not,
        OpenBracket,
        CloseBracket
    }

    public interface IToken
    {
        TokenType TokenType { get; }
        string Text { get; }
        int LineNumber { get; }
        int ColumnNumber { get; }
    }
}
