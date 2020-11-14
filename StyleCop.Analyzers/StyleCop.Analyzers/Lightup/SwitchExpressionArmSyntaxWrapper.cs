﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal partial struct SwitchExpressionArmSyntaxWrapper : ISyntaxWrapper<CSharpSyntaxNode>
    {
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode> PatternAccessor;
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode> WhenClauseAccessor;
        private static readonly Func<CSharpSyntaxNode, ExpressionSyntax> ExpressionAccessor;
        private static readonly Func<CSharpSyntaxNode, SyntaxToken> EqualsGreaterThanTokenAccessor;

        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode, CSharpSyntaxNode> WithPatternAccessor;
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode, CSharpSyntaxNode> WithWhenClauseAccessor;
        private static readonly Func<CSharpSyntaxNode, ExpressionSyntax, CSharpSyntaxNode> WithExpressionAccessor;
        private static readonly Func<CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode> WithEqualsGreaterThanTokenAccessor;

        static SwitchExpressionArmSyntaxWrapper()
        {
            WrappedType = WrapperHelper.GetWrappedType(typeof(SwitchExpressionArmSyntaxWrapper));
            PatternAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(Pattern));
            WhenClauseAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(WhenClause));
            ExpressionAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, ExpressionSyntax>(WrappedType, nameof(Expression));
            EqualsGreaterThanTokenAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(EqualsGreaterThanToken));

            WithPatternAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(Pattern));
            WithWhenClauseAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(WhenClause));
            WithExpressionAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, ExpressionSyntax>(WrappedType, nameof(Expression));
            WithEqualsGreaterThanTokenAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(EqualsGreaterThanToken));
        }

        public PatternSyntaxWrapper Pattern
        {
            get
            {
                return (PatternSyntaxWrapper)PatternAccessor(this.SyntaxNode);
            }
        }

        public WhenClauseSyntaxWrapper WhenClause
        {
            get
            {
                return (WhenClauseSyntaxWrapper)WhenClauseAccessor(this.SyntaxNode);
            }
        }

        public ExpressionSyntax Expression
        {
            get
            {
                return ExpressionAccessor(this.SyntaxNode);
            }
        }

        public SyntaxToken EqualsGreaterThanToken
        {
            get
            {
                return EqualsGreaterThanTokenAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator SwitchExpressionArmSyntaxWrapper(SyntaxNode node)
        {
            if (node == null)
            {
                return default;
            }

            if (!IsInstance(node))
            {
                throw new InvalidCastException($"Cannot cast '{node.GetType().FullName}' to '{WrappedTypeName}'");
            }

            return new SwitchExpressionArmSyntaxWrapper((CSharpSyntaxNode)node);
        }

        public SwitchExpressionArmSyntaxWrapper WithPattern(PatternSyntaxWrapper pattern)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithPatternAccessor(this.SyntaxNode, pattern.SyntaxNode));
        }

        public SwitchExpressionArmSyntaxWrapper WithWhenClause(WhenClauseSyntaxWrapper whenClause)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithWhenClauseAccessor(this.SyntaxNode, whenClause));
        }

        public SwitchExpressionArmSyntaxWrapper WithExpression(ExpressionSyntax expression)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithExpressionAccessor(this.SyntaxNode, expression));
        }

        public SwitchExpressionArmSyntaxWrapper WithEqualsGreaterThanToken(SyntaxToken equalsGreaterThanToken)
        {
            return new SwitchExpressionArmSyntaxWrapper(WithEqualsGreaterThanTokenAccessor(this.SyntaxNode, equalsGreaterThanToken));
        }
    }
}
