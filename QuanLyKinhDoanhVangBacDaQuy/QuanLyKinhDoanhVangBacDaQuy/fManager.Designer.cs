namespace QuanLyKinhDoanhVangBacDaQuy
{
    partial class fManager
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fManager));
            panel7 = new Panel();
            Sidebarbtn = new PictureBox();
            Loginlabel = new Label();
            Minimize_btn = new Button();
            Exitbutton = new Button();
            sidebar = new FlowLayoutPanel();
            panel4 = new Panel();
            Dashboard_btn = new Button();
            panelSell = new Panel();
            Sell_btn = new Button();
            panelBuy = new Panel();
            Buy_btn = new Button();
            panelService = new Panel();
            Service_btn = new Button();
            panelSearch = new Panel();
            Search_btn = new Button();
            panelInventory = new Panel();
            Inven_btn = new Button();
            menuContainer = new FlowLayoutPanel();
            panel3 = new Panel();
            Settingbtn = new Button();
            panel1 = new Panel();
            Info_btn = new Button();
            panel5 = new Panel();
            Admin_btn = new Button();
            panel2 = new Panel();
            Logout_btn = new Button();
            MenuTransition = new System.Windows.Forms.Timer(components);
            sidebarTransition = new System.Windows.Forms.Timer(components);
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Sidebarbtn).BeginInit();
            sidebar.SuspendLayout();
            panel4.SuspendLayout();
            panelSell.SuspendLayout();
            panelBuy.SuspendLayout();
            panelService.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInventory.SuspendLayout();
            menuContainer.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel7
            // 
            panel7.BackColor = Color.Lavender;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(Sidebarbtn);
            panel7.Controls.Add(Loginlabel);
            panel7.Controls.Add(Minimize_btn);
            panel7.Controls.Add(Exitbutton);
            panel7.Dock = DockStyle.Top;
            panel7.ForeColor = SystemColors.ActiveCaptionText;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1200, 30);
            panel7.TabIndex = 10;
            // 
            // Sidebarbtn
            // 
            Sidebarbtn.BackgroundImageLayout = ImageLayout.Stretch;
            Sidebarbtn.Cursor = Cursors.Hand;
            Sidebarbtn.Image = (Image)resources.GetObject("Sidebarbtn.Image");
            Sidebarbtn.Location = new Point(3, 0);
            Sidebarbtn.Name = "Sidebarbtn";
            Sidebarbtn.Size = new Size(60, 30);
            Sidebarbtn.SizeMode = PictureBoxSizeMode.CenterImage;
            Sidebarbtn.TabIndex = 0;
            Sidebarbtn.TabStop = false;
            Sidebarbtn.Click += Sidebarbtn_Click;
            // 
            // Loginlabel
            // 
            Loginlabel.BackColor = Color.Transparent;
            Loginlabel.Font = new Font("Fz Poppins SemBd", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Loginlabel.Location = new Point(78, 0);
            Loginlabel.Name = "Loginlabel";
            Loginlabel.Size = new Size(701, 28);
            Loginlabel.TabIndex = 6;
            Loginlabel.Text = "Quản lý cửa hàng đá quý | Admin";
            Loginlabel.TextAlign = ContentAlignment.MiddleLeft;
            Loginlabel.UseCompatibleTextRendering = true;
            // 
            // Minimize_btn
            // 
            Minimize_btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Minimize_btn.BackColor = Color.FromArgb(173, 188, 223);
            Minimize_btn.FlatAppearance.BorderColor = Color.Lavender;
            Minimize_btn.FlatAppearance.BorderSize = 0;
            Minimize_btn.FlatStyle = FlatStyle.Flat;
            Minimize_btn.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Minimize_btn.ForeColor = SystemColors.ButtonHighlight;
            Minimize_btn.Image = (Image)resources.GetObject("Minimize_btn.Image");
            Minimize_btn.Location = new Point(1127, 0);
            Minimize_btn.Name = "Minimize_btn";
            Minimize_btn.Size = new Size(35, 30);
            Minimize_btn.TabIndex = 7;
            Minimize_btn.TabStop = false;
            Minimize_btn.UseVisualStyleBackColor = false;
            Minimize_btn.Click += Minimize_btn_Click;
            // 
            // Exitbutton
            // 
            Exitbutton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Exitbutton.BackColor = Color.Firebrick;
            Exitbutton.FlatAppearance.BorderColor = Color.Lavender;
            Exitbutton.FlatAppearance.BorderSize = 0;
            Exitbutton.FlatStyle = FlatStyle.Flat;
            Exitbutton.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exitbutton.ForeColor = SystemColors.ButtonHighlight;
            Exitbutton.Image = (Image)resources.GetObject("Exitbutton.Image");
            Exitbutton.Location = new Point(1163, 0);
            Exitbutton.Name = "Exitbutton";
            Exitbutton.Size = new Size(35, 30);
            Exitbutton.TabIndex = 6;
            Exitbutton.TabStop = false;
            Exitbutton.UseVisualStyleBackColor = false;
            Exitbutton.Click += Exitbutton_Click;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(96, 0, 140);
            sidebar.Controls.Add(panel4);
            sidebar.Controls.Add(panelSell);
            sidebar.Controls.Add(panelBuy);
            sidebar.Controls.Add(panelService);
            sidebar.Controls.Add(panelSearch);
            sidebar.Controls.Add(panelInventory);
            sidebar.Controls.Add(menuContainer);
            sidebar.Controls.Add(panel2);
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new Point(0, 30);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 40, 0, 0);
            sidebar.Size = new Size(76, 770);
            sidebar.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.Controls.Add(Dashboard_btn);
            panel4.Location = new Point(0, 40);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(282, 70);
            panel4.TabIndex = 18;
            // 
            // Dashboard_btn
            // 
            Dashboard_btn.BackColor = Color.FromArgb(96, 0, 140);
            Dashboard_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Dashboard_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Dashboard_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Dashboard_btn.ForeColor = Color.White;
            Dashboard_btn.Image = (Image)resources.GetObject("Dashboard_btn.Image");
            Dashboard_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Dashboard_btn.Location = new Point(-12, -20);
            Dashboard_btn.Name = "Dashboard_btn";
            Dashboard_btn.Padding = new Padding(22, 0, 0, 0);
            Dashboard_btn.Size = new Size(320, 109);
            Dashboard_btn.TabIndex = 1;
            Dashboard_btn.Text = "              Dashboard";
            Dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
            Dashboard_btn.UseVisualStyleBackColor = false;
            Dashboard_btn.Click += Dashboard_btn_Click;
            // 
            // panelSell
            // 
            panelSell.Controls.Add(Sell_btn);
            panelSell.Location = new Point(0, 110);
            panelSell.Margin = new Padding(0);
            panelSell.Name = "panelSell";
            panelSell.Size = new Size(282, 70);
            panelSell.TabIndex = 15;
            // 
            // Sell_btn
            // 
            Sell_btn.BackColor = Color.FromArgb(96, 0, 140);
            Sell_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Sell_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Sell_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Sell_btn.ForeColor = Color.White;
            Sell_btn.Image = (Image)resources.GetObject("Sell_btn.Image");
            Sell_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Sell_btn.Location = new Point(-12, -20);
            Sell_btn.Name = "Sell_btn";
            Sell_btn.Padding = new Padding(22, 0, 0, 0);
            Sell_btn.Size = new Size(320, 109);
            Sell_btn.TabIndex = 1;
            Sell_btn.Text = "              Phiếu bán hàng";
            Sell_btn.TextAlign = ContentAlignment.MiddleLeft;
            Sell_btn.UseVisualStyleBackColor = false;
            Sell_btn.Click += Sell_btn_Click;
            // 
            // panelBuy
            // 
            panelBuy.Controls.Add(Buy_btn);
            panelBuy.Location = new Point(0, 180);
            panelBuy.Margin = new Padding(0);
            panelBuy.Name = "panelBuy";
            panelBuy.Size = new Size(282, 70);
            panelBuy.TabIndex = 16;
            // 
            // Buy_btn
            // 
            Buy_btn.BackColor = Color.FromArgb(96, 0, 140);
            Buy_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Buy_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Buy_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Buy_btn.ForeColor = Color.White;
            Buy_btn.Image = (Image)resources.GetObject("Buy_btn.Image");
            Buy_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Buy_btn.Location = new Point(-12, -20);
            Buy_btn.Name = "Buy_btn";
            Buy_btn.Padding = new Padding(22, 0, 0, 0);
            Buy_btn.Size = new Size(320, 109);
            Buy_btn.TabIndex = 1;
            Buy_btn.Text = "              Phiếu mua hàng";
            Buy_btn.TextAlign = ContentAlignment.MiddleLeft;
            Buy_btn.UseVisualStyleBackColor = false;
            Buy_btn.Click += Buy_btn_Click;
            // 
            // panelService
            // 
            panelService.Controls.Add(Service_btn);
            panelService.Location = new Point(0, 250);
            panelService.Margin = new Padding(0);
            panelService.Name = "panelService";
            panelService.Size = new Size(282, 70);
            panelService.TabIndex = 16;
            // 
            // Service_btn
            // 
            Service_btn.BackColor = Color.FromArgb(96, 0, 140);
            Service_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Service_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Service_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Service_btn.ForeColor = Color.White;
            Service_btn.Image = (Image)resources.GetObject("Service_btn.Image");
            Service_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Service_btn.Location = new Point(-12, -20);
            Service_btn.Name = "Service_btn";
            Service_btn.Padding = new Padding(22, 0, 0, 0);
            Service_btn.Size = new Size(320, 109);
            Service_btn.TabIndex = 1;
            Service_btn.Text = "              Phiếu dịch vụ";
            Service_btn.TextAlign = ContentAlignment.MiddleLeft;
            Service_btn.UseVisualStyleBackColor = false;
            Service_btn.Click += Service_btn_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(Search_btn);
            panelSearch.Location = new Point(0, 320);
            panelSearch.Margin = new Padding(0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(282, 70);
            panelSearch.TabIndex = 17;
            // 
            // Search_btn
            // 
            Search_btn.BackColor = Color.FromArgb(96, 0, 140);
            Search_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Search_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Search_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Search_btn.ForeColor = Color.White;
            Search_btn.Image = (Image)resources.GetObject("Search_btn.Image");
            Search_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Search_btn.Location = new Point(-12, -20);
            Search_btn.Name = "Search_btn";
            Search_btn.Padding = new Padding(22, 0, 0, 0);
            Search_btn.Size = new Size(320, 109);
            Search_btn.TabIndex = 1;
            Search_btn.Text = "              Tra cứu dịch vụ";
            Search_btn.TextAlign = ContentAlignment.MiddleLeft;
            Search_btn.UseVisualStyleBackColor = false;
            Search_btn.Click += Search_btn_Click;
            // 
            // panelInventory
            // 
            panelInventory.Controls.Add(Inven_btn);
            panelInventory.Location = new Point(0, 390);
            panelInventory.Margin = new Padding(0);
            panelInventory.Name = "panelInventory";
            panelInventory.Size = new Size(282, 70);
            panelInventory.TabIndex = 17;
            // 
            // Inven_btn
            // 
            Inven_btn.BackColor = Color.FromArgb(96, 0, 140);
            Inven_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Inven_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Inven_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Inven_btn.ForeColor = Color.White;
            Inven_btn.Image = (Image)resources.GetObject("Inven_btn.Image");
            Inven_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Inven_btn.Location = new Point(-12, -20);
            Inven_btn.Name = "Inven_btn";
            Inven_btn.Padding = new Padding(22, 0, 0, 0);
            Inven_btn.Size = new Size(320, 109);
            Inven_btn.TabIndex = 1;
            Inven_btn.Text = "              Lịch sử tồn kho";
            Inven_btn.TextAlign = ContentAlignment.MiddleLeft;
            Inven_btn.UseVisualStyleBackColor = false;
            Inven_btn.Click += Inven_btn_Click;
            // 
            // menuContainer
            // 
            menuContainer.BackColor = Color.FromArgb(96, 0, 140);
            menuContainer.Controls.Add(panel3);
            menuContainer.Controls.Add(panel1);
            menuContainer.Controls.Add(panel5);
            menuContainer.Location = new Point(0, 460);
            menuContainer.Margin = new Padding(0);
            menuContainer.Name = "menuContainer";
            menuContainer.Size = new Size(282, 70);
            menuContainer.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(Settingbtn);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 70);
            panel3.TabIndex = 16;
            // 
            // Settingbtn
            // 
            Settingbtn.BackColor = Color.FromArgb(96, 0, 140);
            Settingbtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 0, 190);
            Settingbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(140, 0, 190);
            Settingbtn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Settingbtn.ForeColor = Color.White;
            Settingbtn.Image = (Image)resources.GetObject("Settingbtn.Image");
            Settingbtn.ImageAlign = ContentAlignment.MiddleLeft;
            Settingbtn.Location = new Point(-15, -20);
            Settingbtn.Margin = new Padding(0);
            Settingbtn.Name = "Settingbtn";
            Settingbtn.Padding = new Padding(22, 0, 0, 0);
            Settingbtn.Size = new Size(320, 109);
            Settingbtn.TabIndex = 0;
            Settingbtn.Text = "               Cài đặt";
            Settingbtn.TextAlign = ContentAlignment.MiddleLeft;
            Settingbtn.UseVisualStyleBackColor = false;
            Settingbtn.Click += Settingbtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Info_btn);
            panel1.Location = new Point(3, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 70);
            panel1.TabIndex = 16;
            // 
            // Info_btn
            // 
            Info_btn.BackColor = Color.FromArgb(96, 0, 140);
            Info_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Info_btn.ForeColor = Color.White;
            Info_btn.Image = (Image)resources.GetObject("Info_btn.Image");
            Info_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Info_btn.Location = new Point(-15, -14);
            Info_btn.Margin = new Padding(0);
            Info_btn.Name = "Info_btn";
            Info_btn.Padding = new Padding(22, 0, 0, 0);
            Info_btn.Size = new Size(320, 88);
            Info_btn.TabIndex = 1;
            Info_btn.Text = "               Thông tin tài khoản";
            Info_btn.TextAlign = ContentAlignment.MiddleLeft;
            Info_btn.UseVisualStyleBackColor = false;
            Info_btn.Click += Info_btn_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(Admin_btn);
            panel5.Location = new Point(3, 155);
            panel5.Name = "panel5";
            panel5.Size = new Size(297, 70);
            panel5.TabIndex = 15;
            // 
            // Admin_btn
            // 
            Admin_btn.BackColor = Color.FromArgb(96, 0, 140);
            Admin_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Admin_btn.ForeColor = Color.White;
            Admin_btn.Image = (Image)resources.GetObject("Admin_btn.Image");
            Admin_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Admin_btn.Location = new Point(-14, -17);
            Admin_btn.Margin = new Padding(0);
            Admin_btn.Name = "Admin_btn";
            Admin_btn.Padding = new Padding(22, 0, 0, 0);
            Admin_btn.Size = new Size(320, 90);
            Admin_btn.TabIndex = 1;
            Admin_btn.Text = "               Quản lý dữ liệu";
            Admin_btn.TextAlign = ContentAlignment.MiddleLeft;
            Admin_btn.UseVisualStyleBackColor = false;
            Admin_btn.Click += Admin_btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(Logout_btn);
            panel2.Location = new Point(0, 530);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(284, 70);
            panel2.TabIndex = 17;
            // 
            // Logout_btn
            // 
            Logout_btn.BackColor = Color.FromArgb(130, 0, 190);
            Logout_btn.Font = new Font("Fz Poppins", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Logout_btn.ForeColor = Color.White;
            Logout_btn.Image = (Image)resources.GetObject("Logout_btn.Image");
            Logout_btn.ImageAlign = ContentAlignment.MiddleLeft;
            Logout_btn.Location = new Point(-12, -20);
            Logout_btn.Name = "Logout_btn";
            Logout_btn.Padding = new Padding(22, 0, 0, 0);
            Logout_btn.Size = new Size(320, 109);
            Logout_btn.TabIndex = 1;
            Logout_btn.Text = "              Đăng xuất";
            Logout_btn.TextAlign = ContentAlignment.MiddleLeft;
            Logout_btn.UseVisualStyleBackColor = false;
            Logout_btn.Click += Logout_btn_Click;
            // 
            // MenuTransition
            // 
            MenuTransition.Interval = 10;
            MenuTransition.Tick += MenuTransition_Tick;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // fManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1200, 800);
            Controls.Add(sidebar);
            Controls.Add(panel7);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Margin = new Padding(2);
            Name = "fManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý kinh doanh vàng bạc đá quý";
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Sidebarbtn).EndInit();
            sidebar.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panelSell.ResumeLayout(false);
            panelBuy.ResumeLayout(false);
            panelService.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelInventory.ResumeLayout(false);
            menuContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel7;
        private Button Minimize_btn;
        private Button Exitbutton;
        private Label Loginlabel;
        private FlowLayoutPanel sidebar;
        private PictureBox Sidebarbtn;
        private Panel panelSell;
        private Button Sell_btn;
        private FlowLayoutPanel menuContainer;
        private Panel panel3;
        private Button Settingbtn;
        private Panel panel5;
        private Button Admin_btn;
        private Panel panelBuy;
        private Button Buy_btn;
        private Panel panelService;
        private Button Service_btn;
        private Panel panelSearch;
        private Button Search_btn;
        private Panel panelInventory;
        private Button Inven_btn;
        private Panel panel1;
        private Button Info_btn;
        private System.Windows.Forms.Timer MenuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel panel2;
        private Button Logout_btn;
        private Panel panel4;
        private Button Dashboard_btn;
    }
}