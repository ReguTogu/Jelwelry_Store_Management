namespace QuanLyKinhDoanhVangBacDaQuy
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            panel1 = new Panel();
            Register_ShowPass = new CheckBox();
            panel6 = new Panel();
            ChucVu_tb = new TextBox();
            labelChucVu = new Label();
            panel5 = new Panel();
            TenNV_tb = new TextBox();
            labelTenNV = new Label();
            panel4 = new Panel();
            regConfPassword = new TextBox();
            labelCMatkhau = new Label();
            userBoxReg = new PictureBox();
            gotoLogin = new Label();
            label2 = new Label();
            RegisterLabel = new Label();
            btnSignUp = new Button();
            panel3 = new Panel();
            regPassword = new TextBox();
            labelMatKhau = new Label();
            panel2 = new Panel();
            regUsername = new TextBox();
            labelTaiKhoan = new Label();
            panel7 = new Panel();
            Minimize_btn = new Button();
            Exitbutton = new Button();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userBoxReg).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(Register_ShowPass);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(userBoxReg);
            panel1.Controls.Add(gotoLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(RegisterLabel);
            panel1.Controls.Add(btnSignUp);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(10, 40);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(680, 600);
            panel1.TabIndex = 5;
            // 
            // Register_ShowPass
            // 
            Register_ShowPass.AutoSize = true;
            Register_ShowPass.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Register_ShowPass.Location = new Point(352, 456);
            Register_ShowPass.Name = "Register_ShowPass";
            Register_ShowPass.Size = new Size(143, 30);
            Register_ShowPass.TabIndex = 4;
            Register_ShowPass.Text = "Hiện mật khẩu";
            Register_ShowPass.UseVisualStyleBackColor = true;
            Register_ShowPass.CheckedChanged += Register_ShowPass_CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(ChucVu_tb);
            panel6.Controls.Add(labelChucVu);
            panel6.Location = new Point(75, 223);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(496, 55);
            panel6.TabIndex = 4;
            // 
            // ChucVu_tb
            // 
            ChucVu_tb.Cursor = Cursors.IBeam;
            ChucVu_tb.Enabled = false;
            ChucVu_tb.Location = new Point(141, 14);
            ChucVu_tb.Margin = new Padding(2);
            ChucVu_tb.Name = "ChucVu_tb";
            ChucVu_tb.ReadOnly = true;
            ChucVu_tb.Size = new Size(276, 27);
            ChucVu_tb.TabIndex = 4;
            ChucVu_tb.TabStop = false;
            ChucVu_tb.Text = "Nhân viên mới";
            // 
            // labelChucVu
            // 
            labelChucVu.AutoSize = true;
            labelChucVu.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChucVu.Location = new Point(55, 15);
            labelChucVu.Margin = new Padding(2, 0, 2, 0);
            labelChucVu.Name = "labelChucVu";
            labelChucVu.Size = new Size(75, 26);
            labelChucVu.TabIndex = 0;
            labelChucVu.Text = "Chức vụ";
            // 
            // panel5
            // 
            panel5.Controls.Add(TenNV_tb);
            panel5.Controls.Add(labelTenNV);
            panel5.Location = new Point(75, 164);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(496, 55);
            panel5.TabIndex = 0;
            // 
            // TenNV_tb
            // 
            TenNV_tb.Cursor = Cursors.IBeam;
            TenNV_tb.Location = new Point(141, 14);
            TenNV_tb.Margin = new Padding(2);
            TenNV_tb.Name = "TenNV_tb";
            TenNV_tb.Size = new Size(276, 27);
            TenNV_tb.TabIndex = 0;
            // 
            // labelTenNV
            // 
            labelTenNV.AutoSize = true;
            labelTenNV.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTenNV.Location = new Point(19, 15);
            labelTenNV.Margin = new Padding(2, 0, 2, 0);
            labelTenNV.Name = "labelTenNV";
            labelTenNV.Size = new Size(118, 26);
            labelTenNV.TabIndex = 0;
            labelTenNV.Text = "Tên nhân viên";
            // 
            // panel4
            // 
            panel4.Controls.Add(regConfPassword);
            panel4.Controls.Add(labelCMatkhau);
            panel4.Location = new Point(45, 403);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(526, 55);
            panel4.TabIndex = 3;
            // 
            // regConfPassword
            // 
            regConfPassword.Cursor = Cursors.IBeam;
            regConfPassword.Location = new Point(171, 14);
            regConfPassword.Margin = new Padding(2);
            regConfPassword.Name = "regConfPassword";
            regConfPassword.PasswordChar = '•';
            regConfPassword.Size = new Size(276, 27);
            regConfPassword.TabIndex = 2;
            // 
            // labelCMatkhau
            // 
            labelCMatkhau.AutoSize = true;
            labelCMatkhau.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCMatkhau.Location = new Point(7, 15);
            labelCMatkhau.Margin = new Padding(2, 0, 2, 0);
            labelCMatkhau.Name = "labelCMatkhau";
            labelCMatkhau.Size = new Size(160, 26);
            labelCMatkhau.TabIndex = 0;
            labelCMatkhau.Text = "Xác nhận mật khẩu";
            // 
            // userBoxReg
            // 
            userBoxReg.Image = Properties.Resources.user1;
            userBoxReg.Location = new Point(295, 26);
            userBoxReg.Name = "userBoxReg";
            userBoxReg.Size = new Size(103, 100);
            userBoxReg.TabIndex = 5;
            userBoxReg.TabStop = false;
            // 
            // gotoLogin
            // 
            gotoLogin.AutoSize = true;
            gotoLogin.Cursor = Cursors.Hand;
            gotoLogin.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gotoLogin.ForeColor = Color.SlateBlue;
            gotoLogin.Location = new Point(367, 547);
            gotoLogin.Name = "gotoLogin";
            gotoLogin.Size = new Size(97, 26);
            gotoLogin.TabIndex = 6;
            gotoLogin.Text = "Đăng nhập";
            gotoLogin.Click += gotoLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(227, 547);
            label2.Name = "label2";
            label2.Size = new Size(139, 26);
            label2.TabIndex = 3;
            label2.Text = "Đã có tài khoản?";
            // 
            // RegisterLabel
            // 
            RegisterLabel.Font = new Font("Fz Poppins", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterLabel.Location = new Point(264, 127);
            RegisterLabel.Name = "RegisterLabel";
            RegisterLabel.Size = new Size(168, 46);
            RegisterLabel.TabIndex = 1;
            RegisterLabel.Text = "Đăng ký";
            RegisterLabel.TextAlign = ContentAlignment.MiddleCenter;
            RegisterLabel.UseCompatibleTextRendering = true;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(107, 0, 128);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Fz Poppins SemBd", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Location = new Point(224, 499);
            btnSignUp.Margin = new Padding(2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(240, 44);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Đăng ký";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(regPassword);
            panel3.Controls.Add(labelMatKhau);
            panel3.Location = new Point(75, 344);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(496, 55);
            panel3.TabIndex = 2;
            // 
            // regPassword
            // 
            regPassword.Cursor = Cursors.IBeam;
            regPassword.Location = new Point(141, 14);
            regPassword.Margin = new Padding(2);
            regPassword.Name = "regPassword";
            regPassword.PasswordChar = '•';
            regPassword.Size = new Size(276, 27);
            regPassword.TabIndex = 1;
            // 
            // labelMatKhau
            // 
            labelMatKhau.AutoSize = true;
            labelMatKhau.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMatKhau.Location = new Point(55, 15);
            labelMatKhau.Margin = new Padding(2, 0, 2, 0);
            labelMatKhau.Name = "labelMatKhau";
            labelMatKhau.Size = new Size(82, 26);
            labelMatKhau.TabIndex = 0;
            labelMatKhau.Text = "Mật khẩu";
            // 
            // panel2
            // 
            panel2.Controls.Add(regUsername);
            panel2.Controls.Add(labelTaiKhoan);
            panel2.Location = new Point(75, 281);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(496, 60);
            panel2.TabIndex = 1;
            // 
            // regUsername
            // 
            regUsername.Cursor = Cursors.IBeam;
            regUsername.Location = new Point(141, 20);
            regUsername.Margin = new Padding(2);
            regUsername.Name = "regUsername";
            regUsername.Size = new Size(276, 27);
            regUsername.TabIndex = 0;
            // 
            // labelTaiKhoan
            // 
            labelTaiKhoan.AutoSize = true;
            labelTaiKhoan.Font = new Font("Fz Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTaiKhoan.Location = new Point(51, 20);
            labelTaiKhoan.Margin = new Padding(2, 0, 2, 0);
            labelTaiKhoan.Name = "labelTaiKhoan";
            labelTaiKhoan.Size = new Size(86, 26);
            labelTaiKhoan.TabIndex = 0;
            labelTaiKhoan.Text = "Tài khoản";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Lavender;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(Minimize_btn);
            panel7.Controls.Add(Exitbutton);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(700, 30);
            panel7.TabIndex = 9;
            // 
            // Minimize_btn
            // 
            Minimize_btn.BackColor = Color.FromArgb(173, 188, 223);
            Minimize_btn.FlatAppearance.BorderColor = Color.Lavender;
            Minimize_btn.FlatAppearance.BorderSize = 0;
            Minimize_btn.FlatStyle = FlatStyle.Flat;
            Minimize_btn.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Minimize_btn.ForeColor = SystemColors.ButtonHighlight;
            Minimize_btn.Image = (Image)resources.GetObject("Minimize_btn.Image");
            Minimize_btn.Location = new Point(627, 0);
            Minimize_btn.Name = "Minimize_btn";
            Minimize_btn.Size = new Size(35, 30);
            Minimize_btn.TabIndex = 7;
            Minimize_btn.TabStop = false;
            Minimize_btn.UseVisualStyleBackColor = false;
            Minimize_btn.Click += Minimize_btn_Click;
            // 
            // Exitbutton
            // 
            Exitbutton.BackColor = Color.Firebrick;
            Exitbutton.FlatAppearance.BorderColor = Color.Lavender;
            Exitbutton.FlatAppearance.BorderSize = 0;
            Exitbutton.FlatStyle = FlatStyle.Flat;
            Exitbutton.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exitbutton.ForeColor = SystemColors.ButtonHighlight;
            Exitbutton.Image = (Image)resources.GetObject("Exitbutton.Image");
            Exitbutton.Location = new Point(663, 0);
            Exitbutton.Name = "Exitbutton";
            Exitbutton.Size = new Size(35, 30);
            Exitbutton.TabIndex = 6;
            Exitbutton.TabStop = false;
            Exitbutton.UseVisualStyleBackColor = false;
            Exitbutton.Click += Exitbutton_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(96, 0, 128);
            ClientSize = new Size(700, 650);
            Controls.Add(panel7);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userBoxReg).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox userBoxReg;
        private Label gotoLogin;
        private Label label2;
        private Label RegisterLabel;
        private Button btnSignUp;
        private Panel panel3;
        private TextBox regPassword;
        private Label labelMatKhau;
        private Panel panel2;
        private TextBox regUsername;
        private Label labelTaiKhoan;
        private Panel panel4;
        private TextBox regConfPassword;
        private Label labelCMatkhau;
        private Panel panel6;
        private TextBox ChucVu_tb;
        private Label labelChucVu;
        private Panel panel5;
        private TextBox TenNV_tb;
        private Label labelTenNV;
        private Panel panel7;
        private Button Minimize_btn;
        private Button Exitbutton;
        private CheckBox Register_ShowPass;
    }
}