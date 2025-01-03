using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using QuanLyKinhDoanhVangBacDaQuy.DAO;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class RegisterForm : Form
    {
        private Form loginForm;

        public RegisterForm(Form parentForm)
        {
            InitializeComponent();
            loginForm = parentForm;
        }
        //Chuyển qua form Đăng nhập
        private void gotoLogin_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
        //Nhấn nút đăng ký, tạo tài khoản nhân viên mới
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string Username = regUsername.Text.Trim();
            string Password = regPassword.Text.Trim();
            string cPassword = regConfPassword.Text.Trim();
            string TenNV = TenNV_tb.Text.Trim();
            string chucVu = ChucVu_tb.Text.Trim();
            int checkDone;
            if (Username == "" || Password == "" || cPassword == "" || TenNV == "" || chucVu == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Password != cPassword)
            {
                MessageBox.Show("Mật khẩu không khớp", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string insertQuery = "INSERT INTO NHANVIEN (TenNhanVien, TaiKhoan, MatKhau, ChucVu)" +
                " VALUES (@TenNhanVien, @TaiKhoan, @MatKhau, @ChucVu)";
                string checkQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan";

                Dictionary<string, object> insertParameters = new Dictionary<string, object>()
            {
                { "@TenNhanVien", TenNV },
                { "@TaiKhoan", Username },
                { "@MatKhau", Password },
                { "@ChucVu", chucVu }
            };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TaiKhoan", Username }
            };
                checkDone = AccountDAO.Instance.Register(insertQuery, checkQuery, insertParameters, checkParameters);
                if (checkDone == 1)
                {
                    MessageBox.Show("Tạo tài khoản thành công!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginForm.Show();
                    this.Close();
                }
                else if (checkDone == -1)
                {
                    MessageBox.Show(Username + " đã tồn tại", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { }
            }
        }
        //Nhấn nút thoát chương trình
        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Nhấn nút thu nhỏ chương trình
        private void Minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Hiện mật khẩu
        private void Register_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            regPassword.UseSystemPasswordChar = false;
            regConfPassword.UseSystemPasswordChar = false;
            regPassword.PasswordChar = Register_ShowPass.Checked ? '\0' : '•';
            regConfPassword.PasswordChar = Register_ShowPass.Checked ? '\0' : '•';
        }
    }
}
