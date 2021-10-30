﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\nedav\source\repos\Lab1Calculator\Lab1Calculator\LabCalculator.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Lab1Calculator {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="LabCalculatorParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ILabCalculatorVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>ParenthesizedExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesizedExpr([NotNull] LabCalculatorParser.ParenthesizedExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>ExponentialExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExponentialExpr([NotNull] LabCalculatorParser.ExponentialExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>MultiplicativeExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpr([NotNull] LabCalculatorParser.MultiplicativeExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>AdditiveExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpr([NotNull] LabCalculatorParser.AdditiveExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>IncExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIncExpr([NotNull] LabCalculatorParser.IncExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>DecExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDecExpr([NotNull] LabCalculatorParser.DecExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>MaxExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMaxExpr([NotNull] LabCalculatorParser.MaxExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>MinExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinExpr([NotNull] LabCalculatorParser.MinExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>NumberExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExpr([NotNull] LabCalculatorParser.NumberExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExpr</c>
	/// labeled alternative in <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpr([NotNull] LabCalculatorParser.IdentifierExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="LabCalculatorParser.compileUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompileUnit([NotNull] LabCalculatorParser.CompileUnitContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="LabCalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] LabCalculatorParser.ExpressionContext context);
}
} // namespace Lab1Calculator
