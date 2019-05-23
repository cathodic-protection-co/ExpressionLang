using ExpressionLang.Tokenizer;
using System;
using System.IO;
using System.Text;

namespace ExpressionLang.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test stream
            string test = "10 + 10  / 144231 * 223461 variable";
            byte[] byteArray = Encoding.ASCII.GetBytes(test);
            MemoryStream stream = new MemoryStream(byteArray);

            var Tokenizer = new Tokenizer.Tokenizer();

            // Token definitions
            Tokenizer.AddTokenDefinition(TokenType.Ignored, @" ");
            Tokenizer.AddTokenDefinition(TokenType.NewLine, @"\\n\\r");
            Tokenizer.AddTokenDefinition(TokenType.EndOfFile, "");
            Tokenizer.AddTokenDefinition(TokenType.Ident, "[a-zA-Z][a-zA-Z0-9]+");
            Tokenizer.AddTokenDefinition(TokenType.Int, "(-)?[0-9]+");
            Tokenizer.AddTokenDefinition(TokenType.Float, @"(-)?[0-9]+(\.[0-9]+)?(e\+[0-9]+)?");
            Tokenizer.AddTokenDefinition(TokenType.LogicalOr, @"\|\|");
            Tokenizer.AddTokenDefinition(TokenType.LogicalOr, @"or");
            Tokenizer.AddTokenDefinition(TokenType.LogicalAnd, @"&&");
            Tokenizer.AddTokenDefinition(TokenType.LogicalAnd, @"and");
            Tokenizer.AddTokenDefinition(TokenType.Equals, @"==");
            Tokenizer.AddTokenDefinition(TokenType.NotEquals, @"!=");
            Tokenizer.AddTokenDefinition(TokenType.LessThan, @"<");
            Tokenizer.AddTokenDefinition(TokenType.GreaterThan, @">");
            Tokenizer.AddTokenDefinition(TokenType.LessThanEquals, @"<=");
            Tokenizer.AddTokenDefinition(TokenType.GreaterThanEquals, @">=");
            Tokenizer.AddTokenDefinition(TokenType.Addition, @"\+");
            Tokenizer.AddTokenDefinition(TokenType.Subtraction, @"-");
            Tokenizer.AddTokenDefinition(TokenType.Multiplication, @"\*");
            Tokenizer.AddTokenDefinition(TokenType.Division, @"\/");
            Tokenizer.AddTokenDefinition(TokenType.Modulo, @"%");
            Tokenizer.AddTokenDefinition(TokenType.Not, @"!");
            Tokenizer.AddTokenDefinition(TokenType.OpenBracket, @"\(");
            Tokenizer.AddTokenDefinition(TokenType.CloseBracket, @"\)");

            Tokenizer.Tokenize(stream);

            foreach (IToken token in Tokenizer.Tokens)
                Console.WriteLine($"{token.TokenType}, {token.Text}, {token.LineNumber}:{token.ColumnNumber}");

            Console.ReadLine();
        }
    }
}