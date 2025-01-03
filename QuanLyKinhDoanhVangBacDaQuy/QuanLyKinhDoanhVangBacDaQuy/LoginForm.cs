using QuanLyKinhDoanhVangBacDaQuy.DAO;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        //Nhấn nút đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (login(userName, passWord))
            {
                fManager f = new fManager(userName);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Gửi thông tin tài khoản mật khẩu đến hệ thống
        bool login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
        //Thông báo khi thoát chương trình (Form Login là form mặc định của hệ thống)
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        //Chuyển qua form Đăng ký
        private void gotoRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm(this);
            regForm.Show();
            this.Hide();
        }
        //Nút thu nhỏ chương trình
        private void Minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Nút tắt chương trình
        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Hiện mật khẩu
        private void Login_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = false;
            txbPassWord.PasswordChar = Login_ShowPass.Checked ? '\0' : '•';
        }
    }
}
