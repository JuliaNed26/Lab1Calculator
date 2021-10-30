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
        private string expression;
        public string Name { get; }
        public uint Row { get; }
        public uint Column { get; }
        public string Expr 
        {
            get { return expression; }
            set
            {
                if (Name != "")
                {
                    Regex regex = new Regex(this.Name);
                    MatchCollection matches = regex.Matches(value);
                    if (matches.Count > 0)
                    {
                        throw new ArgumentException("Can't calculate loop expression.");
                    }
                }
                expression = value;
            }
        }//if we can't calculate expression

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
        public void FillCellsIDependOn(ref Dictionary<string, MyCell> avail_cells)
        {//maybe should add avail_cells to constructor
            this.CellsIDependOn.Clear();

            foreach(var cell in avail_cells)
            {
                if (cell.Value != this)
                {
                    Regex regex = new Regex(cell.Key);
                    MatchCollection matches = regex.Matches(this.Expr);
                    if (matches.Count > 0)// знайшли адресу комірки в виразі
                    {
                        CellsIDependOn.Add(cell.Value);//додаємо в список комірок, від яких залежить дана
                        avail_cells[cell.Key].CellsDependsOnMe.Add(this);//додаємо в список залежних від cell комірок дану
                    }
                    else
                    {
                        if (avail_cells[cell.Key].CellsDependsOnMe.Contains(this))//якщо змінили вираз і тепер дана комірка не залежить
                                                                                  //від cell, видаляемо з залежних від cell комірок дану
                        {
                            avail_cells[cell.Key].CellsDependsOnMe.Remove(this);
                        }
                    }
                }
            }
        }
    }
}
