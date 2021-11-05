using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Calculator
{
    public class Calculator
    {
        Dictionary<string, double> ident_values;
        public Calculator(ref Dictionary<string,double> _ident_values)
        {
            ident_values = new Dictionary<string, double>();
            ident_values = _ident_values;
        }
        public double Evaluate(string expression)
        {
            var lexer = new LabCalculatorLexer(new AntlrInputStream(expression));//lexer is reading from a string expression
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new LabCalculatorParser(tokens);
            var tree = parser.compileUnit();
            var visitor = new LabCalculatorVisitor();
            visitor.SetIdentifierTable(ident_values);
            return visitor.Visit(tree);
        }
    }
}