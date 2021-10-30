
namespace Lab1Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.add_row_btn = new System.Windows.Forms.Button();
            this.remove_row_btn = new System.Windows.Forms.Button();
            this.add_column_btn = new System.Windows.Forms.Button();
            this.remove_column_btn = new System.Windows.Forms.Button();
            this.expressionTb = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_row_btn
            // 
            this.add_row_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.add_row_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_row_btn.Location = new System.Drawing.Point(22, 34);
            this.add_row_btn.Name = "add_row_btn";
            this.add_row_btn.Size = new System.Drawing.Size(109, 25);
            this.add_row_btn.TabIndex = 0;
            this.add_row_btn.Text = "Add row";
            this.add_row_btn.UseVisualStyleBackColor = false;
            this.add_row_btn.Click += new System.EventHandler(this.add_row_btn_Click);
            // 
            // remove_row_btn
            // 
            this.remove_row_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.remove_row_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.remove_row_btn.Location = new System.Drawing.Point(155, 34);
            this.remove_row_btn.Name = "remove_row_btn";
            this.remove_row_btn.Size = new System.Drawing.Size(109, 25);
            this.remove_row_btn.TabIndex = 1;
            this.remove_row_btn.Text = "Remove row";
            this.remove_row_btn.UseVisualStyleBackColor = false;
            this.remove_row_btn.Click += new System.EventHandler(this.remove_row_btn_Click);
            // 
            // add_column_btn
            // 
            this.add_column_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.add_column_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_column_btn.Location = new System.Drawing.Point(289, 34);
            this.add_column_btn.Name = "add_column_btn";
            this.add_column_btn.Size = new System.Drawing.Size(109, 25);
            this.add_column_btn.TabIndex = 2;
            this.add_column_btn.Text = "Add column";
            this.add_column_btn.UseVisualStyleBackColor = false;
            this.add_column_btn.Click += new System.EventHandler(this.add_column_btn_Click);
            // 
            // remove_column_btn
            // 
            this.remove_column_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.remove_column_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.remove_column_btn.Location = new System.Drawing.Point(429, 34);
            this.remove_column_btn.Name = "remove_column_btn";
            this.remove_column_btn.Size = new System.Drawing.Size(109, 25);
            this.remove_column_btn.TabIndex = 3;
            this.remove_column_btn.Text = "Remove column";
            this.remove_column_btn.UseVisualStyleBackColor = false;
            this.remove_column_btn.Click += new System.EventHandler(this.remove_column_btn_Click);
            // 
            // expressionTb
            // 
            this.expressionTb.BackColor = System.Drawing.Color.Snow;
            this.expressionTb.Location = new System.Drawing.Point(563, 37);
            this.expressionTb.Name = "expressionTb";
            this.expressionTb.ReadOnly = true;
            this.expressionTb.Size = new System.Drawing.Size(257, 20);
            this.expressionTb.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.Size = new System.Drawing.Size(875, 344);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadFromToolStripMenuItem
            // 
            this.loadFromToolStripMenuItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.loadFromToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loadFromToolStripMenuItem.Name = "loadFromToolStripMenuItem";
            this.loadFromToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.loadFromToolStripMenuItem.Text = "Load from";
            this.loadFromToolStripMenuItem.Click += new System.EventHandler(this.loadFromToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadFromToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(928, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(928, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.expressionTb);
            this.Controls.Add(this.remove_column_btn);
            this.Controls.Add(this.add_column_btn);
            this.Controls.Add(this.remove_row_btn);
            this.Controls.Add(this.add_row_btn);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CalculatorTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_row_btn;
        private System.Windows.Forms.Button remove_row_btn;
        private System.Windows.Forms.Button add_column_btn;
        private System.Windows.Forms.Button remove_column_btn;
        private System.Windows.Forms.TextBox expressionTb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

