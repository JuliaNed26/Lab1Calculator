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
            MyCell A0 = new MyCell("A0", 0, 0);
            try
            {
                A0.Expr = "A0*2";
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                if (ex.Message != "Can't calculate loop expression.")
                {
                    Assert.Fail();
                }
            }
            A0.Expr = "3*3";
            Assert.AreEqual("3*3", A0.Expr);
        }

        [TestMethod]
        public void FillCellsIDependOnTest()
        {
            Dictionary<string, MyCell> test_cells = new Dictionary<string, MyCell>();
            MyCell A0 = new MyCell("A0", 0, 0);
            MyCell A1 = new MyCell("A1", 1, 0);
            test_cells.Add("A0", A0);
            test_cells.Add("A1", A1);
            A0.Expr = "incA1";
            A0.FillCellsIDependOn(ref test_cells);
            Assert.AreEqual(0, A1.CellsIDependOn.Count);
            Assert.IsTrue(A0.CellsIDependOn.Contains(A1));
            Assert.AreEqual(1, A0.CellsIDependOn.Count);
            Assert.AreEqual(1, A1.CellsDependsOnMe.Count);
            A0.Expr = "";
            A0.FillCellsIDependOn(ref test_cells);
            A1.Expr = "incA0";
            A1.FillCellsIDependOn(ref test_cells);
            Assert.AreEqual(0, A0.CellsIDependOn.Count);
            Assert.IsTrue(A1.CellsIDependOn.Contains(A0));
            Assert.AreEqual(1, A1.CellsIDependOn.Count);
            Assert.AreEqual(1, A0.CellsDependsOnMe.Count);
        }
    }
}
