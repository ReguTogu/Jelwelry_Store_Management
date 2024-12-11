using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKinhDoanhVangBacDaQuy.DAO;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class fAccountProfile : Form
    {
        private string userName;
        public fAccountProfile(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            LoadEmployeeInfo();
        }
        private void LoadEmployeeInfo()
        {
            string query = "EXEC ThongTinCaNhan_TK_Ten @TaiKhoan ";

            var employeeData = DataProvider.Instance.ExecuteQuery(query, new object[] { userName });

            if (employeeData.Rows.Count > 0)
            {
                txbDisplayName.Text = employeeData.Rows[0]["TenNhanVien"].ToString();
                txbUserName.Text = employeeData.Rows[0]["TaiKhoan"].ToString();
                txb_Job.Text = employeeData.Rows[0]["ChucVu"].ToString();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnExitUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string tenHienThi = txbDisplayName.Text.Trim();
            string matKhauHienTai = txbPassword.Text.Trim();
            string matKhauMoi = txbNewPass.Text.Trim();
            string nhapLaiMatKhauMoi = txbReEnterPass.Text.Trim();

            if (string.IsNullOrEmpty(tenHienThi) || string.IsNullOrEmpty(matKhauHienTai) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(nhapLaiMatKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != nhapLaiMatKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhauHienTai == matKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string checkQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
            Dictionary<string, object> checkParameters = new Dictionary<string, object>
            {
                { "@TaiKhoan", userName },
                { "@MatKhau", matKhauHienTai }
            };

            int isValidOldPassword = DataProvider.Instance.ExecuteScalar(checkQuery, checkParameters);

            if (isValidOldPassword == 0)
            {
                MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "EXEC Sua_ThongTinCaNhan @TaiKhoan, @TenHienThi, @MatKhauMoi";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TaiKhoan", userName },
                { "@TenHienThi", tenHienThi },
                { "@MatKhauMoi", matKhauMoi }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Profile_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txbPassword.UseSystemPasswordChar = false;
            txbNewPass.UseSystemPasswordChar = false;
            txbReEnterPass.UseSystemPasswordChar = false;
            txbPassword.PasswordChar = Profile_ShowPass.Checked ? '\0' : '•';
            txbNewPass.PasswordChar = Profile_ShowPass.Checked ? '\0' : '•';
            txbReEnterPass.PasswordChar = Profile_ShowPass.Checked ? '\0' : '•';
        }
    }
}
