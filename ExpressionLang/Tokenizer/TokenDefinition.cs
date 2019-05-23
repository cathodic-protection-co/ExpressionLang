using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressionLang.Tokenizer
{
    public class TokenDefinition
    {
        public TokenType TokenType { get; }
        public string SearchPattern { get; }

        private Regex Regex { get; }

        public TokenDefinition(TokenType tokenType, string searchPattern)
        {
            TokenType = tokenType;
            SearchPattern = searchPattern;
            Regex = new Regex(searchPattern);
        }

        public Match Match(string buffer)
        {
            return Regex.Match(buffer);
        }
    }
}
