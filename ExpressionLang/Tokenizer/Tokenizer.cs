using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressionLang.Tokenizer
{
    public class Tokenizer
    {
        public ICollection<TokenDefinition> TokenDefinitions { get; private set; } = new List<TokenDefinition>();
        public ICollection<IToken> Tokens { get; private set; } = new List<IToken>();

        private int lineNumber = 1;
        private int columnNumber = 0;

        public void AddTokenDefinition(TokenType tokenType, string searchPattern)
        {
            TokenDefinitions.Add(new TokenDefinition(tokenType, searchPattern));
        }

        public void Tokenize(Stream stream)
        {
            Tokens.Clear();

            IToken token;
            using (var reader = new StreamReader(stream))
                while ((token = MatchLongest(reader, "")).TokenType != TokenType.EndOfFile)
                    Tokens.Add(token);

            Tokens.Add(new EndOfFileToken(lineNumber, columnNumber));
        }

        private IToken MatchLongest(StreamReader reader, string buffer)
        {
            // If the end of the stream is reached
            if (reader.EndOfStream)
                return new EndOfFileToken(lineNumber, columnNumber);

            // Read the first char (advance column counter).
            buffer += (char)reader.Read();
            columnNumber += 1;

            // Try to match 
            var pair = Match(reader, buffer);

            // Try to match the next one along too
            string temp = buffer;
            temp += (char)reader.Peek();

            // Float edgecase
            if (temp[temp.Length - 1] == '.')
            {
                reader.Read();
                temp += (char)reader.Peek();

                if (Match(reader, temp) != null)
                    return MatchLongest(reader, temp);
            }

            if (Match(reader, temp) != null)
            {
                // Can match to longer, so recurse
                return MatchLongest(reader, buffer);                                // Recurse (carry buffer / same token)
            }
            else
            {
                switch (pair?.Value.TokenType)
                {
                    case TokenType.NewLine:
                        lineNumber += 1;                                            // Increment line counter
                        columnNumber = 0;                                           // Reset column counter
                        return MatchLongest(reader, "");                            // Recurse (reset buffer / next token)
                    case TokenType.Ignored:
                        return MatchLongest(reader, "");                            // Recurse (reset buffer / next token)

                    // Literals
                    case TokenType.Int:
                        return new IntToken(buffer, lineNumber, columnNumber);
                    case TokenType.Float:
                        return new FloatToken(buffer, lineNumber, columnNumber);
                    case TokenType.Bool:
                        return new BoolToken(buffer, lineNumber, columnNumber);
                    case TokenType.Ident:
                        return new IdentToken(buffer, lineNumber, columnNumber);

                    // Operators
                    case TokenType.Addition:
                    case TokenType.Subtraction:
                    case TokenType.Multiplication:
                    case TokenType.Division:
                    case TokenType.Modulo:
                    case TokenType.Not:
                        return new OperatorToken(buffer, lineNumber, columnNumber, (TokenType)pair?.Value.TokenType);

                    // Comparitors
                    case TokenType.GreaterThan:
                    case TokenType.GreaterThanEquals:
                    case TokenType.LessThan:
                    case TokenType.LessThanEquals:
                    case TokenType.Equals:
                    case TokenType.NotEquals:
                        return new ComparitorToken(buffer, lineNumber, columnNumber, (TokenType)pair?.Value.TokenType);

                    case TokenType.LogicalAnd:
                    case TokenType.LogicalOr:
                        return new LogicalToken(buffer, lineNumber, columnNumber, (TokenType)pair?.Value.TokenType);

                    case TokenType.OpenBracket:
                        return new OpenBracketToken(buffer, lineNumber, columnNumber);
                    case TokenType.CloseBracket:
                        return new CloseBracketToken(buffer, lineNumber, columnNumber);

                    default:
                        throw new Exception($"Invalid token type at: {lineNumber}:{columnNumber}");
                }
            }
        }

        private KeyValuePair<Match, TokenDefinition>? Match(StreamReader reader, string buffer)
        {
            foreach (TokenDefinition tokenDefinition in TokenDefinitions)
            {
                Match match = tokenDefinition.Match(buffer);
                if (match.Success && match.Value.Length == buffer.Length)
                    return new KeyValuePair<Match, TokenDefinition>(match, tokenDefinition);
            }

            return null;
        }
    }
}
