﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Test.CSharp9.DocumentationRules
{
    using Microsoft.CodeAnalysis.Testing;
    using StyleCop.Analyzers.Test.CSharp8.DocumentationRules;

    public class SA1600CSharp9UnitTests : SA1600CSharp8UnitTests
    {
        protected override DiagnosticResult[] GetExpectedResultTestRegressionMethodGlobalNamespace(string code, int column)
        {
            if (code == "public void TestMember() { }" && column == 13)
            {
                return new[]
                {
                    // error CS8805: Program using top-level statements must be an executable.
                    DiagnosticResult.CompilerError("CS8805"),

                    // /0/Test0.cs(4,1): error CS0106: The modifier 'public' is not valid for this item
                    DiagnosticResult.CompilerError("CS0106").WithSpan(4, 1, 4, 7).WithArguments("public"),

                    // /0/Test0.cs(4,1): error CS8652: The feature 'top-level statements' is currently in Preview and *unsupported*. To use Preview features, use the 'preview' language version.
                    DiagnosticResult.CompilerError("CS8652").WithSpan(4, 1, 4, 29).WithArguments("top-level statements"),
                };
            }

            return base.GetExpectedResultTestRegressionMethodGlobalNamespace(code, column);
        }
    }
}
