using ExpressionLang.Compiler.Expressions;
using ExpressionLang.Compiler.Expressions.Comparison;
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
                    return new OrExpression((IExpression<bool>)left, (IExpression<bool>)right);
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
                    return new AndExpression((IExpression<bool>)left, (IExpression<bool>)right);
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
                    return new IntEqualsExpression((IExpression<int>)left, (IExpression<int>)right);
                else if (left is IExpression<int>)
                    return new FloatEqualsExpression((IExpression<float>)left, (IExpression<float>)right);
                else
                    throw new Exception("Invalid Type");
            }
            else if(Accept(TokenType.NotEquals))
            {
                Expression right = ParseEqualityTerm();
                if (left is IExpression<int>)
                    return new IntNotEqualsExpression((IExpression<int>)left, (IExpression<int>)right);
                else if (left is IExpression<int>)
                    return new FloatNotEqualsExpression((IExpression<float>)left, (IExpression<float>)right);
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
                        return new IntGreaterThanExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatGreaterThanExpression((IExpression<float>)left, (IExpression<float>)right);
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.LessThan))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntLessThanExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatLessThanExpression((IExpression<float>)left, (IExpression<float>)right);
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.GreaterThanEquals))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntGreaterThanEqualsExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatGreaterThanEqualsExpression((IExpression<float>)left, (IExpression<float>)right);
                    else
                        throw new Exception("Invalid type");
                }
                else if (Accept(TokenType.LessThanEquals))
                {
                    Expression right = ParseComparisonTerm();
                    if (left is IExpression<int>)
                        return new IntLessThanEqualsExpression((IExpression<int>)left, (IExpression<int>)right);
                    else if (left is IExpression<float>)
                        return new FloatLessThanEqualsExpression((IExpression<float>)left, (IExpression<float>)right);
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
