using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab1Calculator
{
    public class Table
    {
        private uint row_count;
        private uint col_count;
        public Dictionary<string, MyCell> cells;
        public Dictionary<string, double> cells_values;//для використання в калькуляторі
        public uint RowCount { get { return row_count; } }
        public uint ColCount { get { return col_count; } }

        public Table(uint _row_count, uint _col_count)
        {
            cells = new Dictionary<string, MyCell>();
            cells_values = new Dictionary<string, double>();
            //створення комірок, поточне значення кожної 0
            for (uint i = 0; i < _row_count; i++)
            {
                for (uint j = 0; j < _col_count; j++)
                {
                    MyCell cell = new MyCell(GetColName(j) + i.ToString(), i, j);
                    cells.Add(cell.Name, cell);
                    cells_values.Add(cell.Name, 0);
                }
            }
            row_count = _row_count;
            col_count = _col_count;
        }
        public string GetColName(uint _column)
        {
            StringBuilder _name = new StringBuilder();
            const int alphabet = 26;
            uint cur_val = _column;
            int counter = 0;
            while (true)
            {
                uint div = cur_val / alphabet;
                uint mod = cur_val % alphabet;
                if(counter != 0)
                {
                    mod--;
                }
                _name.Insert(0, ((char)(mod + 65)).ToString());
                if (div == 0)
                {
                    break;
                }
                cur_val = div;
                counter++;
            }
            return _name.ToString();
        }

        public string GetCellName(uint row, uint column)
        {
            return GetColName(column) + row.ToString();
        }
        public bool AddRow()
        {
            if (col_count != 0)
            {
                for (uint i = 0; i < col_count; i++)
                {
                    MyCell new_cell = new MyCell(GetCellName(row_count, i), row_count, i);
                    cells.Add(new_cell.Name, new_cell);
                    cells_values.Add(new_cell.Name, 0);
                }
                row_count++;
                return true;
            }
            return false;
        }

        public void AddColumn()
        {
            string col_name = GetColName(col_count);
            for (uint i = 0; i < row_count; i++)
            {
                MyCell new_cell = new MyCell(col_name + i.ToString(), i, col_count);
                cells.Add(new_cell.Name, new_cell);
                cells_values.Add(new_cell.Name, 0);
            }
            col_count++;
        }

        public bool RemoveRow()
        {
            if (row_count > 0)
            {
                row_count--;
                for (uint i = 0; i < col_count; i++)
                {
                    if (cells[GetCellName(row_count, i)].CellsDependsOnMe.Count != 0)
                    {
                        throw new ArgumentException("Some cells may have dependencies.");
                    }
                    cells.Remove(GetCellName(row_count, i));
                    cells_values.Remove(GetCellName(row_count, i));
                }
                return true;
            }
            return false;
        }

        public bool RemoveColumn()
        {
            if (col_count > 0)
            {
                col_count--;
                string col_name = GetColName(col_count);
                for (int i = 0; i < row_count; i++)
                {
                    if (cells[col_name + i.ToString()].CellsDependsOnMe.Count != 0)
                    {
                        throw new ArgumentException("Some cells may have dependencies.");
                    }
                    cells.Remove(col_name + i.ToString());
                    cells_values.Remove(col_name + i.ToString());
                }
                return true;
            }
            return false;
        }

        public bool SetCellValue(string cellName, double value)
        {
            if(!cells.ContainsKey(cellName))
            {
                return false;
            }
            RefreshDependencies(cells[cellName]);
            cells[cellName].Value = value;
            cells_values[cellName] = value;
            return true;
        }

        private void RefreshDependencies(MyCell changedCell)
        {
            foreach(var cell in cells)
            {
                if(!changedCell.CellsIDependOn.Contains(cell.Value) &&
                    cell.Value.CellsDependsOnMe.Contains(changedCell))
                {
                    cell.Value.CellsDependsOnMe.Remove(changedCell);
                }
            }
            foreach(var cell in changedCell.CellsIDependOn)
            {
                cell.CellsDependsOnMe.Add(changedCell);
            }
        }
    }
}
