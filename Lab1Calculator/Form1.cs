using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab1Calculator
{
    public partial class Form1 : Form
    {
        Table table;
        Calculator calculator;
        uint row_count = 0;
        uint col_count = 0;
        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            const int size = 200;
            table = new Table(size, size);
            CreateDataGridView(size, size);//заповнюємо dataGridView1
            row_count += size;
            col_count += size;
            calculator = new Calculator(ref table.cells_values);
            this.ActiveControl = dataGridView1;
        }

        private void CreateDataGridView(uint row_count, uint col_count)
        {
            for(uint i = 0; i < col_count; i++)
            {
                DataGridViewColumn new_col = new DataGridViewColumn();
                MyCell new_cell = new MyCell();
                new_col.HeaderText = table.GetColName(i);
                new_col.Name = new_col.HeaderText;
                new_col.CellTemplate = new_cell;
                dataGridView1.Columns.Add(new_col);
            }
            for(uint i = 0; i < row_count; i++)
            {
                DataGridViewRow new_row = new DataGridViewRow();
                new_row.HeaderCell.Value = i.ToString();
                dataGridView1.Rows.Add(new_row);
            }
        }

        private void add_row_btn_Click(object sender, EventArgs e)
        {
            DataGridViewRow new_row = new DataGridViewRow();
            new_row.HeaderCell.Value = row_count.ToString();
            row_count++;
            table.AddRow();
            dataGridView1.Rows.Add(new_row);
        }

        private void remove_row_btn_Click(object sender, EventArgs e)
        {
            try
            {
                table.RemoveRow();
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                row_count--;
            }
            catch(ArgumentException ex)//намагаємося видалити комірку, коли є комірки,що від неї залежать
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_column_btn_Click(object sender, EventArgs e)
        {
            DataGridViewColumn new_col = new DataGridViewColumn();
            MyCell new_cell = new MyCell();
            new_col.HeaderText = table.GetColName(col_count);
            new_col.Name = new_col.HeaderText;
            new_col.CellTemplate = new_cell;
            table.AddColumn();
            dataGridView1.Columns.Add(new_col);
            col_count++;
        }

        private void remove_column_btn_Click(object sender, EventArgs e)
        {
            try
            {
                table.RemoveColumn();
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
                col_count--;
            }
            catch (ArgumentException ex)//намагаємося видалити комірку, коли є комірки,що від неї залежать
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = table.GetCellName((uint)dataGridView1.CurrentCell.RowIndex, (uint)dataGridView1.CurrentCell.ColumnIndex);
            expressionTb.Text = table.cells[cellName].Expr;
        }

        private void ReevaluateCell(string cellName)//повертаємо минулі значення
        {
            if (table.cells[cellName].Expr != "")
            {
                table.cells[cellName].Value = calculator.Evaluate(table.cells[cellName].Expr);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)// recursion error!
        {
            string cellName = table.GetCellName((uint)dataGridView1.CurrentCell.RowIndex, (uint)dataGridView1.CurrentCell.ColumnIndex);
            if (table.cells.ContainsKey(cellName))
            {
                try
                {
                    string expr = dataGridView1.CurrentCell.Value.ToString();//watch expression
                    double value = calculator.Evaluate(expr);//try to calculate it
                    table.cells[cellName].SetExpression(expr, table.cells);//save expression
                    table.SetCellValue(cellName, value);//save value to cell
                    dataGridView1.CurrentCell.Value = table.cells[cellName].Value;//виводимо значення в dataGridView1
                    RefreshDependentCells(table.cells[cellName]);//оновлюємо значення комірок,що залежать від даної
                }
                catch (ArgumentException ex)//виключення,що можуть виникнути,якщо вираз неправильний
                {
                    ReevaluateCell(cellName);//повертаємо минулі значення
                    dataGridView1.CurrentCell.Value = table.cells[cellName].Value;
                    MessageBox.Show(ex.Message);
                }
                catch (DivideByZeroException)
                {
                    ReevaluateCell(cellName);//повертаємо минулі значення
                    dataGridView1.CurrentCell.Value = table.cells[cellName].Value;
                    MessageBox.Show("Division by zero!");
                }
            }
        }
        private void RefreshDependentCells(MyCell cell)//оновлюємо значення комірок,що залежать від комірки cell
        {
            foreach (var cur_cell in cell.CellsDependsOnMe)
            {
                cur_cell.Value = calculator.Evaluate(cur_cell.Expr);
                table.cells_values[cur_cell.Name] = Convert.ToDouble(cur_cell.Value);//оновлюємо значення комірки в таблиці
                RefreshDependentCells(cur_cell);
                dataGridView1[(int)cur_cell.Column, (int)cur_cell.Row].Value = cur_cell.Value;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string cellName = table.GetCellName((uint)dataGridView1.CurrentCell.RowIndex, (uint)dataGridView1.CurrentCell.ColumnIndex);
            dataGridView1.CurrentCell.Value = table.cells[cellName].Expr;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("Columns: " + col_count + " Rows: " + row_count);
                    foreach (var cell in table.cells_values)
                    {
                        if (table.cells[cell.Key].Expr != "")//показувати лише заповнені комірки
                        {
                            writer.Write(cell.Key + " = ");
                            if (cell.Value == double.PositiveInfinity)
                            {
                                writer.Write("PositiveInfinity");
                            }
                            else if (cell.Value == double.NegativeInfinity)
                            {
                                writer.Write("NegativeInfinity");
                            }
                            else
                            {
                                writer.Write(cell.Value);
                            }
                            writer.Write(" Expression: " + table.cells[cell.Key].Expr + '\n');
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Can't save to this file.");
            }
        }

        private void FillCell(string cellInfo)
        {
            Regex cellNameRegex = new Regex(@"[A-Z]+[0-9]+");
            string cellName = cellNameRegex.Matches(cellInfo)[0].ToString();
            double value = 0;
            if (cellInfo.Contains("NegativeInfinity"))
            {
                value = double.NegativeInfinity;
            }
            else if (cellInfo.Contains("PositiveInfinity"))
            {
                value = double.PositiveInfinity;
            }
            else
            {
                Regex valueRegex = new Regex(@"\d+\.?\d*");
                value = Convert.ToDouble(valueRegex.Matches(cellInfo)[1].ToString());
            }
            string expression = cellInfo.Substring(cellInfo.LastIndexOf(": ") + 2,
                 cellInfo.Length - cellInfo.LastIndexOf(": ") - 2);
            table.cells[cellName].SetExpression(expression, table.cells);
            table.cells[cellName].Value = value;
            table.cells_values[cellName] = value;
            if (expression != "")
            {
                dataGridView1[(int)table.cells[cellName].Column, (int)table.cells[cellName].Row].Value = value;
            }
        }

        private void FillTable(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    line = reader.ReadLine();
                    Regex numberRegex = new Regex(@"\d+");
                    col_count = Convert.ToUInt32(numberRegex.Matches(line)[0].ToString());
                    row_count = Convert.ToUInt32(numberRegex.Matches(line)[1].ToString());
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    table = new Table(row_count, col_count);
                    CreateDataGridView(row_count, col_count);
                    while ((line = reader.ReadLine()) != null)
                    {
                        FillCell(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {

            table.cells.Clear();
            table.cells_values.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            FillTable(openFileDialog1.FileName);
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 69;
            dataGridView1.Height = this.Height - 145;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save result?", "Exit", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(null, null);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Laboratory work №1 version 7\n\nYou can use such operations:\n" +
                "1) +,-,*,/(binary operations)\n2) +,-(sign of a number)\n3)^\n4)inc, dec\n5)max(a,b), min(a,b)\n" +
                "As an operands use decimal numbers or addresses of cells.\n" +
                "In a menu strip you can either save your table or load existing table.\n\n" +
                "Made with love by Julia Nedavnaya K-26:)";
            MessageBox.Show(text,"Help");
        }
    }
}
