﻿using ExpressionLang.Compiler.Expressions;
using ExpressionLang.Tokenizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExpressionLang.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test stream
            // Foo = 10.5
            // Bar = 20
            string test = "10 + foo > 20 and 10 + 20 == 30";
            byte[] byteArray = Encoding.ASCII.GetBytes(test);
            MemoryStream stream = new MemoryStream(byteArray);

            var Tokenizer = new Tokenizer.Tokenizer();

            // Token definitions
            Tokenizer.AddTokenDefinition(TokenType.Ignored, @" ");
            Tokenizer.AddTokenDefinition(TokenType.NewLine, @"\\n\\r");
            Tokenizer.AddTokenDefinition(TokenType.EndOfFile, "");
            Tokenizer.AddTokenDefinition(TokenType.LogicalOr, @"\|\|");
            Tokenizer.AddTokenDefinition(TokenType.LogicalOr, @"or");
            Tokenizer.AddTokenDefinition(TokenType.LogicalAnd, @"&&");
            Tokenizer.AddTokenDefinition(TokenType.LogicalAnd, @"and");
            Tokenizer.AddTokenDefinition(TokenType.Ident, "[a-zA-Z][a-zA-Z0-9]+");
            Tokenizer.AddTokenDefinition(TokenType.Int, "(-)?[0-9]+");
            Tokenizer.AddTokenDefinition(TokenType.Float, @"(-)?[0-9]+(\.[0-9]+)?(e\+[0-9]+)?");
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

            // Tokenizer debug output
            foreach (IToken token in Tokenizer.Tokens)
                Console.WriteLine($"{token.TokenType}, {token.Text}, {token.LineNumber}:{token.ColumnNumber}");

            Dictionary<string, float> vars = new Dictionary<string, float>();
            vars.Add("foo", 10.5f);
            vars.Add("bar", 20);

            Compiler.Compiler compiler = new Compiler.Compiler();
            Expression expr = compiler.Compile(Tokenizer.Tokens, vars);

            Console.WriteLine();
            Console.WriteLine($"Expression Output: {(expr as IExpression<bool>).Evaluate()}");

            Console.ReadLine();
        }
    }
}