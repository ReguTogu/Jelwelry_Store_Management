namespace QuanLyKinhDoanhVangBacDaQuy
{
    partial class FormListServiceReceipt
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_resetSearch = new Button();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btn_resetSearch);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(76, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1124, 769);
            panel1.TabIndex = 2;
            // 
            // btn_resetSearch
            // 
            btn_resetSearch.BackColor = Color.FromArgb(140, 0, 200);
            btn_resetSearch.FlatAppearance.BorderSize = 0;
            btn_resetSearch.FlatStyle = FlatStyle.Flat;
            btn_resetSearch.Font = new Font("Fz Poppins", 12F);
            btn_resetSearch.ForeColor = SystemColors.Window;
            btn_resetSearch.Location = new Point(881, 693);
            btn_resetSearch.Margin = new Padding(2);
            btn_resetSearch.Name = "btn_resetSearch";
            btn_resetSearch.Size = new Size(210, 40);
            btn_resetSearch.TabIndex = 0;
            btn_resetSearch.Text = "Đặt lại";
            btn_resetSearch.UseVisualStyleBackColor = false;
            btn_resetSearch.Click += btn_resetSearch_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(140, 0, 200);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Fz Poppins", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(-8, 36);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1137, 67);
            textBox1.TabIndex = 1;
            textBox1.TabStop = false;
            textBox1.Text = "DANH SÁCH PHIẾU DỊCH VỤ";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(130, 0, 190);
            dataGridViewCellStyle1.Font = new Font("Fz Poppins SemBd", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(28, 158);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1051, 504);
            dataGridView1.TabIndex = 0;
            dataGridView1.TabStop = false;
            // 
            // FormListServiceReceipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(76, 0);
            Margin = new Padding(2);
            Name = "FormListServiceReceipt";
            Text = "FormListServiceReceipt";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btn_resetSearch;
    }
}