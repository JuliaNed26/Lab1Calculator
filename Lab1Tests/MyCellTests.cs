using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1Calculator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab1Tests
{
    [TestClass]
    public class MyCellTests
    {
        [TestMethod]
        public void SetExprTest()
        {
            Table table = new Table(1, 2);
            try
            {
                table.cells["A0"].SetExpression("A0*2", table.cells);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                if (ex.Message != "Can't calculate loop expression.")
                {
                    Assert.Fail();
                }
            }
            table.cells["A0"].SetExpression("3*3", table.cells);
            Assert.AreEqual("3*3", table.cells["A0"].Expr);
            table.cells["A0"].SetExpression("B0 + 1", table.cells);
            Assert.AreEqual("B0 + 1", table.cells["A0"].Expr);
            try
            {
                table.cells["B0"].SetExpression("A0*2", table.cells);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                if (ex.Message != "Recursion occured!")
                {
                    Assert.Fail();
                }
            }

        }
    }
}
