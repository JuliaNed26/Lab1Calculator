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
    public class TableTests
    {
        [TestMethod]
        public void EmptyTable()
        {
            Table table = new Table(0, 0);
            Assert.AreEqual((uint)0, table.RowCount);
            Assert.AreEqual((uint)0, table.ColCount);
            Assert.AreEqual(0, table.cells.Count);
            Assert.AreEqual(0, table.cells_values.Count);
            table.RemoveRow();
            Assert.AreEqual((uint)0, table.RowCount);
            Assert.AreEqual((uint)0, table.ColCount);
            table.RemoveColumn();
            Assert.AreEqual((uint)0, table.RowCount);
            Assert.AreEqual((uint)0, table.ColCount);
            Assert.AreEqual(0, table.cells.Count);
            Assert.AreEqual(0, table.cells_values.Count());
        }

        [TestMethod]
        public void GetColNameTest()
        {
            Table table = new Table(10, 10);
            Assert.AreEqual("A", table.GetColName(0));
            Assert.AreEqual("Z", table.GetColName(25));
            Assert.AreEqual("AA", table.GetColName(26));
            Assert.AreEqual("AZ", table.GetColName(51));
            Assert.AreEqual("BA", table.GetColName(52));
            Assert.AreEqual("AAA", table.GetColName(702));
        }

        [TestMethod]
        public void GetCellNameTest()
        {
            Table table = new Table(10, 10);
            Assert.AreEqual("A5", table.GetCellName(5, 0));
            Assert.AreEqual("Z0", table.GetCellName(0, 25));
            Assert.AreEqual("AA3", table.GetCellName(3, 26));
            Assert.AreEqual("AZ1000", table.GetCellName(1000, 51));

        }

        [TestMethod]
        public void AddRowAndColumnTest()
        {
            Table emptyTable = new Table(0, 0);
            Assert.AreEqual(false, emptyTable.AddRow());
            Assert.AreEqual((uint)0, emptyTable.RowCount);
            Assert.AreEqual((uint)0, emptyTable.ColCount);
            Assert.AreEqual(0, emptyTable.cells.Count);
            Assert.AreEqual(0, emptyTable.cells_values.Count);
            emptyTable.AddColumn();
            Assert.AreEqual((uint)1, emptyTable.ColCount);
            Assert.AreEqual((uint)0, emptyTable.RowCount);
            Assert.AreEqual(0, emptyTable.cells.Count);
            Assert.AreEqual(0, emptyTable.cells_values.Count);
            emptyTable.AddRow();
            Assert.AreEqual((uint)1, emptyTable.ColCount);
            Assert.AreEqual((uint)1, emptyTable.RowCount);
            Assert.AreEqual(1, emptyTable.cells.Count);
            Assert.AreEqual(1, emptyTable.cells_values.Count);
        }

        [TestMethod]
        public void RemoveRowTest()
        {
            Table emptyTable = new Table(0, 0);
            Assert.AreEqual(false, emptyTable.RemoveRow());
            emptyTable.AddColumn();
            emptyTable.AddRow();
            emptyTable.AddRow();
            Assert.AreEqual(true, emptyTable.RemoveRow());
            Assert.AreEqual((uint)1, emptyTable.RowCount);
            emptyTable.AddRow();
            emptyTable.cells["A0"].SetExpression("incA1", emptyTable.cells);
            emptyTable.SetCellValue("A0", 1);
            try
            {
                emptyTable.RemoveRow();
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual("Some cells may have dependencies.", ex.Message);
            }
        }

        [TestMethod]
        public void RemoveColumnTest()
        {
            Table emptyTable = new Table(0, 0);
            Assert.AreEqual(false, emptyTable.RemoveColumn());
            emptyTable.AddColumn();
            emptyTable.AddColumn();
            emptyTable.AddRow();
            Assert.AreEqual(true, emptyTable.RemoveColumn());
            Assert.AreEqual((uint)1, emptyTable.ColCount);
            emptyTable.AddColumn();
            emptyTable.cells["A0"].SetExpression("incB0", emptyTable.cells);
            emptyTable.SetCellValue("A0", 1);
            try
            {
                emptyTable.RemoveColumn();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Some cells may have dependencies.", ex.Message);
            }
        }
    }
}
