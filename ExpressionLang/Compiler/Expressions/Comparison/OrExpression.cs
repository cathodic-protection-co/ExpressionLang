﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public class OrExpression : Expression, IExpression<bool>
    {
        internal IExpression<bool> Left { get; }
        internal IExpression<bool> Right { get; }

        public OrExpression(IExpression<bool> left, IExpression<bool> right)
        {
            Left = left;
            Right = right;
        }

        public bool Evaluate()
        {
            return Left.Evaluate() || Right.Evaluate();
        }
    }
}
