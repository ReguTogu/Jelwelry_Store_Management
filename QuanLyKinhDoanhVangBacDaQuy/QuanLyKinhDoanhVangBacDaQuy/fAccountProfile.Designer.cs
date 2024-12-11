namespace QuanLyKinhDoanhVangBacDaQuy
{
    partial class fAccountProfile
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
            panel2 = new Panel();
            txbUserName = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            txbDisplayName = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            txbPassword = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            txbNewPass = new TextBox();
            labelPassword = new Label();
            panel5 = new Panel();
            txbReEnterPass = new TextBox();
            label4 = new Label();
            panel6 = new Panel();
            txb_Job = new TextBox();
            label5 = new Label();
            btn_Update = new Button();
            Profile_ShowPass = new CheckBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txbUserName);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(356, 117);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(538, 77);
            panel2.TabIndex = 0;
            // 
            // txbUserName
            // 
            txbUserName.Anchor = AnchorStyles.Right;
            txbUserName.BorderStyle = BorderStyle.FixedSingle;
            txbUserName.Enabled = false;
            txbUserName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbUserName.Location = new Point(185, 26);
            txbUserName.Margin = new Padding(2);
            txbUserName.Name = "txbUserName";
            txbUserName.ReadOnly = true;
            txbUserName.Size = new Size(272, 31);
            txbUserName.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Fz Poppins", 9F);
            label1.Location = new Point(95, 29);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 26);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản:";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txbDisplayName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(356, 196);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 77);
            panel1.TabIndex = 4;
            // 
            // txbDisplayName
            // 
            txbDisplayName.Anchor = AnchorStyles.Right;
            txbDisplayName.BackColor = SystemColors.HighlightText;
            txbDisplayName.BorderStyle = BorderStyle.FixedSingle;
            txbDisplayName.Font = new Font("Segoe UI", 10.8F);
            txbDisplayName.Location = new Point(185, 26);
            txbDisplayName.Margin = new Padding(2);
            txbDisplayName.Name = "txbDisplayName";
            txbDisplayName.Size = new Size(272, 31);
            txbDisplayName.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Fz Poppins", 9F);
            label2.Location = new Point(82, 29);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 26);
            label2.TabIndex = 0;
            label2.Text = "Tên hiển thị:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txbPassword);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(356, 356);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(538, 77);
            panel3.TabIndex = 0;
            // 
            // txbPassword
            // 
            txbPassword.BorderStyle = BorderStyle.FixedSingle;
            txbPassword.Font = new Font("Segoe UI", 10.8F);
            txbPassword.Location = new Point(185, 20);
            txbPassword.Margin = new Padding(2);
            txbPassword.Name = "txbPassword";
            txbPassword.PasswordChar = '•';
            txbPassword.Size = new Size(272, 31);
            txbPassword.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Fz Poppins", 9F);
            label3.Location = new Point(99, 23);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 26);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txbNewPass);
            panel4.Controls.Add(labelPassword);
            panel4.Location = new Point(356, 437);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(538, 77);
            panel4.TabIndex = 1;
            // 
            // txbNewPass
            // 
            txbNewPass.Anchor = AnchorStyles.Right;
            txbNewPass.BackColor = SystemColors.HighlightText;
            txbNewPass.BorderStyle = BorderStyle.FixedSingle;
            txbNewPass.Font = new Font("Segoe UI", 10.8F);
            txbNewPass.Location = new Point(185, 24);
            txbNewPass.Margin = new Padding(2);
            txbNewPass.Name = "txbNewPass";
            txbNewPass.PasswordChar = '•';
            txbNewPass.Size = new Size(272, 31);
            txbNewPass.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Fz Poppins", 9F);
            labelPassword.Location = new Point(66, 26);
            labelPassword.Margin = new Padding(2, 0, 2, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(118, 26);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Mật khẩu mới:";
            labelPassword.Click += label4_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(txbReEnterPass);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(356, 518);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(538, 77);
            panel5.TabIndex = 2;
            // 
            // txbReEnterPass
            // 
            txbReEnterPass.Anchor = AnchorStyles.Right;
            txbReEnterPass.BackColor = Color.White;
            txbReEnterPass.BorderStyle = BorderStyle.FixedSingle;
            txbReEnterPass.Font = new Font("Segoe UI", 10.8F);
            txbReEnterPass.Location = new Point(185, 24);
            txbReEnterPass.Margin = new Padding(2);
            txbReEnterPass.Name = "txbReEnterPass";
            txbReEnterPass.PasswordChar = '•';
            txbReEnterPass.Size = new Size(272, 31);
            txbReEnterPass.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Fz Poppins", 9F);
            label4.Location = new Point(-3, 27);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(187, 26);
            label4.TabIndex = 0;
            label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // panel6
            // 
            panel6.Controls.Add(txb_Job);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(356, 276);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(538, 77);
            panel6.TabIndex = 2;
            // 
            // txb_Job
            // 
            txb_Job.BorderStyle = BorderStyle.FixedSingle;
            txb_Job.Enabled = false;
            txb_Job.Font = new Font("Segoe UI", 10.8F);
            txb_Job.Location = new Point(185, 20);
            txb_Job.Margin = new Padding(2);
            txb_Job.Name = "txb_Job";
            txb_Job.ReadOnly = true;
            txb_Job.Size = new Size(272, 31);
            txb_Job.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Fz Poppins", 9F);
            label5.Location = new Point(106, 23);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(78, 26);
            label5.TabIndex = 0;
            label5.Text = "Chức vụ:";
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.FromArgb(130, 0, 190);
            btn_Update.FlatAppearance.BorderSize = 0;
            btn_Update.FlatStyle = FlatStyle.Flat;
            btn_Update.Font = new Font("Fz Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Update.ForeColor = Color.White;
            btn_Update.Location = new Point(699, 620);
            btn_Update.Margin = new Padding(2);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(155, 34);
            btn_Update.TabIndex = 3;
            btn_Update.Text = "Cập nhật";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // Profile_ShowPass
            // 
            Profile_ShowPass.AutoSize = true;
            Profile_ShowPass.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Profile_ShowPass.Location = new Point(541, 595);
            Profile_ShowPass.Name = "Profile_ShowPass";
            Profile_ShowPass.Size = new Size(143, 30);
            Profile_ShowPass.TabIndex = 7;
            Profile_ShowPass.Text = "Hiện mật khẩu";
            Profile_ShowPass.UseVisualStyleBackColor = true;
            Profile_ShowPass.CheckedChanged += Profile_ShowPass_CheckedChanged;
            // 
            // fAccountProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1200, 800);
            Controls.Add(Profile_ShowPass);
            Controls.Add(btn_Update);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "fAccountProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            Load += fAccountProfile_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private TextBox txbUserName;
        private Label label1;
        private Panel panel1;
        private TextBox txbDisplayName;
        private Label label2;
        private Panel panel3;
        private TextBox txbPassword;
        private Label label3;
        private Panel panel4;
        private TextBox txbNewPass;
        private Label labelPassword;
        private Panel panel5;
        private TextBox txbReEnterPass;
        private Label label4;
        private Panel panel6;
        private TextBox txb_Job;
        private Label label5;
        private Button btn_Update;
        private CheckBox Profile_ShowPass;
    }
}