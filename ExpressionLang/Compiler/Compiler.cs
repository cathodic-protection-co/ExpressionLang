using ExpressionLang.Compiler.Expressions;
using ExpressionLang.Tokenizer;
using ExpressionLang.Tokenizer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler
{
    public class Compiler
    {
        bool Peek(params TokenType[] tokenTypes)
        {
            throw new NotImplementedException();
        }

        bool Expect(TokenType tokenType)
        {
            throw new NotImplementedException();
        }

        bool Accept(TokenType tokenType)
        {
            throw new NotImplementedException();
        }

        bool Accept(TokenType tokenType, out IToken token)
        {
            throw new NotImplementedException();
        }

        Expression ParseWholeExpression()
        {
            throw new NotImplementedException();
        }

        Expression ParseExpression()
        {
            throw new NotImplementedException();
        }

        Expression ParseLogicalTerm()
        {
            throw new NotImplementedException();
        }

        Expression ParseLogicalFactor()
        {
            throw new NotImplementedException();
        }

        Expression ParseEqualityTerm()
        {
            throw new NotImplementedException();
        }

        Expression ParseComparisonTerm()
        {
            Expression left = ParseFactor();
            while (Peek(TokenType.Addition, TokenType.Subtraction))
            {
                if (Accept(TokenType.Addition))
                {
                    Expression right = ParseFactor();
                    if (left is IExpression<int>)
                        return new IntAdditionExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatAdditionExpression((IExpression<float>)left, (IExpression<float>)right);
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.Subtraction))
                {
                    Expression right = ParseFactor();
                    if (left is IExpression<int>)
                        return new IntSubtractionExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatSubtractionExpression((IExpression<float>)left, (IExpression<float>)right);
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
                        return new IntMultiplicationExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatMultiplicationExpression((IExpression<float>)left, (IExpression<float>)right);
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.Division))
                {
                    Expression right = ParseFactor();
                    if (left is IExpression<int>)
                        return new IntDivisionExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatDivisionExpression((IExpression<float>)left, (IExpression<float>)right);
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
