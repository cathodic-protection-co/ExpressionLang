using ExpressionLang.Compiler.Expressions;
using ExpressionLang.Compiler.Expressions.Comparison;
using ExpressionLang.Compiler.Expressions.Literal;
using ExpressionLang.Tokenizer;
using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionLang.Compiler
{
    public class Compiler
    {
        private Stack<IToken> Tokens;
        private IDictionary<string, float> Variables;
        public Expression Compile(ICollection<IToken> tokens, IDictionary<string, float> variables)
        {
            Tokens = new Stack<IToken>(tokens.Reverse());
            Variables = variables;

            return ParseWholeExpression();
        }

        bool Peek(params TokenType[] tokenTypes)
        {
            IToken token = Tokens.Peek();
            return tokenTypes.Any(x => x == token.TokenType);
        }

        bool Expect(TokenType tokenType)
        {
            IToken token = Tokens.Pop();
            if (token.TokenType == tokenType)
                return true;
            else
                throw new Exception($"Expected token: {tokenType}, got {token.TokenType}");
        }

        bool Accept(TokenType tokenType)
        {
            IToken token;
            if (Peek(tokenType))
            {
                token = Tokens.Pop();
                return token.TokenType == tokenType;
            }
            else
            {
                token = null;
                return false;
            }
        }

        bool Accept(TokenType tokenType, out IToken token)
        {
            if (Peek(tokenType))
            {
                token = Tokens.Pop();
                return token.TokenType == tokenType;
            }
            else
            {
                token = null;
                return false;
            }
        }

        Expression ParseWholeExpression()
        {
            Expression expr = ParseExpression();
            if (Accept(TokenType.EndOfFile))
                return expr;
            else
                throw new Exception("End of file not reached");
        }

        Expression ParseExpression()
        {
            Expression left = ParseLogicalTerm();
            if (Accept(TokenType.LogicalOr))
            {
                Expression right = ParseLogicalFactor();
                if (left is IExpression<bool> && right is IExpression<bool>)
                    return new OrExpression(left.As<bool>(), right.As<bool>());
                else
                    throw new Exception($"Can't logical or on {left} & {right}");
            }
            else
            {
                return left;
            }
        }

        Expression ParseLogicalTerm()
        {
            Expression left = ParseLogicalFactor();
            if (Accept(TokenType.LogicalAnd))
            {
                Expression right = ParseLogicalFactor();
                if (left is IExpression<bool> && right is IExpression<bool>)
                    return new AndExpression(left.As<bool>(), right.As<bool>());
                else
                    throw new Exception($"Can't logical and on {left} & {right}");
            }
            else
            {
                return left;
            }
        }

        Expression ParseLogicalFactor()
        {
            Expression left = ParseEqualityTerm();
            if (Accept(TokenType.Equals))
            {
                Expression right = ParseEqualityTerm();
                if (left is IExpression<int>)
                    return new IntEqualsExpression(left.As<int>(), right.As<int>());
                else if (left is IExpression<int>)
                    return new FloatEqualsExpression(left.As<float>(), right.As<float>());
                else
                    throw new Exception("Invalid Type");
            }
            else if(Accept(TokenType.NotEquals))
            {
                Expression right = ParseEqualityTerm();
                if (left is IExpression<int>)
                    return new IntNotEqualsExpression(left.As<int>(), right.As<int>());
                else if (left is IExpression<int>)
                    return new FloatNotEqualsExpression(left.As<float>(), right.As<float>());
                else
                    throw new Exception("Invalid Type");
            }
            else
            {
                return left;
            }
        }

        Expression ParseEqualityTerm()
        {
            Expression left = ParseComparisonTerm();
            while (Peek(TokenType.GreaterThan, TokenType.LessThan, TokenType.GreaterThanEquals, TokenType.LessThanEquals))
            {
                if (Accept(TokenType.GreaterThan))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntGreaterThanExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        return new FloatGreaterThanExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.LessThan))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntLessThanExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        return new FloatLessThanExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.GreaterThanEquals))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntGreaterThanEqualsExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        return new FloatGreaterThanEqualsExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.LessThanEquals))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntLessThanEqualsExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        return new FloatLessThanEqualsExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else
                {
                    return left;
                }
            }

            return left;
        }

        Expression ParseComparisonTerm()
        {
            Expression left = ParseTerm();
            while (Peek(TokenType.Addition, TokenType.Subtraction))
            {
                if (Accept(TokenType.Addition))
                {
                    Expression right = ParseTerm();
                    if (left is IExpression<int>)
                        left = new IntAdditionExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        left = new FloatAdditionExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.Subtraction))
                {
                    Expression right = ParseTerm();
                    if (left is IExpression<int>)
                        left = new IntSubtractionExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        left = new FloatSubtractionExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else
                {
                    return left;
                }
            }
            return left;
        }

        Expression ParseTerm()
        {
            Expression left = ParseFactor();
            while (Peek(TokenType.Multiplication, TokenType.Division))
            {
                if (Accept(TokenType.Multiplication))
                {
                    Expression right = ParseFactor();
                    if (left is IExpression<int>)
                        left = new IntMultiplicationExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        left = new FloatMultiplicationExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.Division))
                {
                    Expression right = ParseFactor();
                    if (left is IExpression<int>)
                        left = new IntDivisionExpression(left.As<int>(), right.As<int>());
                    else if (left is IExpression<float>)
                        left = new FloatDivisionExpression(left.As<float>(), right.As<float>());
                    else
                        throw new Exception("Invalid type");
                }
                else
                {
                    return left;
                }
            }
            return left;
        }

        Expression ParseFactor()
        {
            if (Accept(TokenType.Not))
                return new NotExpression(ParseAtom());
            else
                return ParseAtom();
        }

        Expression ParseAtom()
        {
            if (Accept(TokenType.Int, out IToken token))
            {
                return new IntLiteralExpression(token);
            }
            else if (Accept(TokenType.Float, out token))
            {
                return new FloatLiteralExpression(token);
            }
            else if (Accept(TokenType.Ident, out token))
            {
                if (Variables.TryGetValue(token.Text, out float val))
                    return new FloatLiteralExpression(new FloatToken(val.ToString(), token.LineNumber, token.ColumnNumber));
                else
                    throw new Exception($"Invalid identifier {token.Text}");
            }
            else if (Accept(TokenType.OpenBracket))
            {
                Expression innerExpression = ParseExpression();
                if (Expect(TokenType.CloseBracket))
                    return innerExpression;
                else
                    throw new Exception($"Missing matching close bracket for open at {innerExpression.EndLine}:{innerExpression.EndColumn}");
            }
            else
            {
                throw new Exception($"Invalid token at PUT LINE NUMBER HERE SOMEHOW");
            }
        }
    }
}
