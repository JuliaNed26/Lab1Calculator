using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab1Calculator
{
    public class MyCell: DataGridViewTextBoxCell
    {
        public string Name { get; }
        public uint Row { get; }
        public uint Column { get; }
        public string Expr { get; private set; }

        public List<MyCell> CellsIDependOn;//список комірок, від яких залежить дана
        public List<MyCell> CellsDependsOnMe;//список комірок, які залежать від даної
        public MyCell()
        {
            CellsDependsOnMe = new List<MyCell>();
            CellsIDependOn = new List<MyCell>();
            Name = "";
            Expr = "";
            Row = 0;
            Column = 0;
        }//потрібен для додавання рядка в dataGridView1
        public MyCell(string _name, uint _row, uint _column)
        {
            CellsDependsOnMe = new List<MyCell>();
            CellsIDependOn = new List<MyCell>();
            Name = _name;
            Expr = "";
            Row = _row;
            Column = _column;
        }

        public void SetExpression(string expr, Dictionary<string, MyCell> avail_cells)
        {
            if (Name != "")//перевірка,що комірка не посилається на саму себе
            {
                Regex regex = new Regex(this.Name);
                MatchCollection matches = regex.Matches(expr);
                if (matches.Count > 0)
                {
                    throw new ArgumentException("Can't calculate loop expression.");
                }
            }
            FillCellsIDependOn(expr, avail_cells);
            Expr = expr;
        }

        private void FillCellsIDependOn(string expr, Dictionary<string, MyCell> avail_cells)
        {
            List<MyCell> iDepend = new List<MyCell>();
            Regex cellAddress = new Regex(@"[A-Z]+[0-9]+");
            MatchCollection matches = cellAddress.Matches(expr);
            foreach(var cellAddr in matches)
            {
                if(!avail_cells.ContainsKey(cellAddr.ToString()))
                {
                    throw new ArgumentException("Can't find some cells!");
                }
                MyCell cell = avail_cells[cellAddr.ToString()];
                if (avail_cells[cell.Name].CellsIDependOn.Contains(this))//якщо комірка, адресу якої знайшли у виразі
                                                                        //залежить від даної
                {
                    throw new ArgumentException("Recursion occured!");
                }
                iDepend.Add(cell);
            }
            CellsIDependOn.Clear();
            CellsIDependOn.AddRange(iDepend);
        }
    }
}
