﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions
{
    public abstract class AdditionExpression<T> : Expression, IExpression<T>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public AdditionExpression(IExpression<T> left, IExpression<T> right)
        {
            Left = left;
            Right = right;
        }

        public abstract T Evaluate();
    }

    public class IntAdditionExpression : AdditionExpression<int>
    {
        public IntAdditionExpression(IExpression<int> left, IExpression<int> right) : base (left, right)
        {

        }

        public override int Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }

    public class FloatAdditionExpression : AdditionExpression<float>
    {
        public FloatAdditionExpression(IExpression<float> left, IExpression<float> right) : base(left, right)
        {

        }

        public override float Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }
}