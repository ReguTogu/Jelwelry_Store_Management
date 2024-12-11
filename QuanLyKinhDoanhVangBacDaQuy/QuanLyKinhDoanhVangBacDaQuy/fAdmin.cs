using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyKinhDoanhVangBacDaQuy.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            LoadAccountList(true);
            LoadServiceList(true);
            LoadProductList(true);
            LoadProductTypeList(true);
            LoadProviderList(true);
            LoadCustomerList(true);
        }

        void LoadAccountList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_Nhan_Vien"; // Lấy toàn bộ danh sách
                dtgvStaff.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_Nhan_Vien @MaNhanVien"; // Lấy theo ID
                dtgvStaff.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvStaff.Columns["ID"].Width = 50;
                dtgvStaff.Columns["Tên"].Width = 170;
                dtgvStaff.Columns["Tài khoản"].Width = 150;
                dtgvStaff.Columns["Mật Khẩu"].Width = 150;
                dtgvStaff.Columns["Chức vụ"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadServiceList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_Loai_Dich_Vu"; // Lấy toàn bộ danh sách
                dtgvService1.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_Loai_Dich_Vu @MaDichVu"; // Lấy theo ID
                dtgvService1.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvService1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvService1.Columns["ID"].Width = 50;
                dtgvService1.Columns["Tên loại dịch vụ"].Width = 370;
                dtgvService1.Columns["Đơn giá"].Width = 210;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadProductList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_San_Pham"; // Lấy toàn bộ danh sách
                dtgvProduct1.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_San_Pham @MaSanPham"; // Lấy theo ID
                dtgvProduct1.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvProduct1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvProduct1.Columns["ID"].Width = 50;
                dtgvProduct1.Columns["Tên sản phẩm"].Width = 250;
                dtgvProduct1.Columns["Mã loại"].Width = 100;
                dtgvProduct1.Columns["Số lượng"].Width = 130;
                dtgvProduct1.Columns["Đơn giá"].Width = 150;
                dtgvProduct1.Columns["Tình trạng"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProductType_Into_Product();
        }

        void LoadProductTypeList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_Loai_San_Pham"; // Lấy toàn bộ danh sách
                dtgvProdType.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_Loai_San_Pham @MaLoaiSP"; // Lấy theo ID
                dtgvProdType.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvProdType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvProdType.Columns["ID"].Width = 50;
                dtgvProdType.Columns["Tên loại sản phẩm"].Width = 300;
                dtgvProdType.Columns["Đơn vị tính"].Width = 150;
                dtgvProdType.Columns["Lợi nhuận"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDonViTinh();
        }
        private void LoadDonViTinh()
        {
            string query = "SELECT DISTINCT DonViTinh FROM LOAISANPHAM";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbProdType_DonVi.Items.Clear(); // Xóa các item cũ
            foreach (DataRow row in data.Rows)
            {
                cbProdType_DonVi.Items.Add(row["DonViTinh"].ToString());
            }
        }
        void LoadProviderList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_Nha_Cung_Cap"; // Lấy toàn bộ danh sách
                dtgvProvider.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_Nha_Cung_Cap @MaNhaCungCap"; // Lấy theo ID
                dtgvProvider.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvProvider.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvProvider.Columns["ID"].Width = 50;
                dtgvProvider.Columns["Tên nhà cung cấp"].Width = 200;
                dtgvProvider.Columns["Số điện thoại"].Width = 160;
                dtgvProvider.Columns["Địa chỉ nhà cung cấp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadCustomerList(bool loadAll = true)
        {
            string query;
            if (loadAll)
            {
                query = "EXEC Danh_Sach_Khach_Hang"; // Lấy toàn bộ danh sách
                dtgvCustomer.DataSource = DataProvider.Instance.ExecuteQuery(query);
            }
            else
            {
                query = "EXEC Danh_Sach_Khach_Hang @MaKhachHang"; // Lấy theo ID
                dtgvCustomer.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { 3 }); // Ví dụ ID = 3
            }

            dtgvProvider.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Đặt kích thước cho từng cột
            try
            {
                dtgvCustomer.Columns["ID"].Width = 50;
                dtgvCustomer.Columns["Họ tên khách hàng"].Width = 370;
                dtgvCustomer.Columns["Số điện thoại"].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cấu hình DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra chuỗi chỉ chứa số và độ dài từ 10-11 ký tự
            return Regex.IsMatch(phoneNumber, @"^\d{10,11}$");
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private int getID; // ID Nhân viên
        private int getID_Provider; // ID nhà cung cấp
        private int getID_ProdType; //ID Loai sp
        private int getID_Product; //ID sp
        private int getID_Service; //ID dich vu
        private int getID_Customer;
        //Thêm Nhân Viên
        private void btnAddStaff_1_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txbStaff_Name.Text.Trim();
            string taiKhoan = txbStaff_Username.Text.Trim();
            string matKhau = txbStaff_Password.Text.Trim();
            string chucVu = cbStaff_Role.Text.Trim();

            if (string.IsNullOrEmpty(tenNhanVien) || string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(chucVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertQuery = "EXEC Them_NhanVien @TenNhanVien, @TaiKhoan, @MatKhau, @ChucVu";
            string checkQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan";

            Dictionary<string, object> insertParameters = new Dictionary<string, object>()
            {
                { "@TenNhanVien", tenNhanVien },
                { "@TaiKhoan", taiKhoan },
                { "@MatKhau", matKhau },
                { "@ChucVu", chucVu }
            };
            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TaiKhoan", taiKhoan }
            };

            int result = AccountDAO.Instance.Register(insertQuery, checkQuery, insertParameters, checkParameters);

            if (result == 1)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccountList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xóa Nhân Viên
        private void btnDeleteStaff_1_Click(object sender, EventArgs e)
        {
            if (getID > 0)
            {
                string query = "EXEC Xoa_Nhan_Vien @MaNhanVien";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@MaNhanVien", getID}
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountList(true); // Load lại danh sách sau khi xóa
                    getID = 0;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Reset Nhân Viên
        private void btnResetStaff_1_Click(object sender, EventArgs e)
        {
            LoadAccountList(true);
            txbStaff_Name.Clear();
            txbStaff_Username.Clear();
            txbStaff_Password.Clear();
            cbStaff_Role.SelectedIndex = -1;
            getID = 0;
        }

        //Thêm Nhà Cung Cấp
        private void btnAddProvider_1_Click(object sender, EventArgs e)
        {
            string tenNhaCungCap = txbProvider_Name.Text.Trim();
            string soDienThoai = txbProvider_Phone.Text.Trim();
            string diaChi = txbProvider_Address.Text.Trim();

            if (string.IsNullOrEmpty(tenNhaCungCap) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ chứa 10-11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string insertQuery = "EXEC Them_NhaCungCap @TenNhaCungCap, @SoDienThoai, @DiaChi";

            string checkQuery = "SELECT COUNT(*) FROM NHACUNGCAP WHERE TenNhaCungCap = @TenNhaCungCap";

            Dictionary<string, object> insertParameters = new Dictionary<string, object>()
            {
                { "@TenNhaCungCap", tenNhaCungCap },
                { "@SoDienThoai", soDienThoai },
                { "@DiaChi", diaChi }
            };

            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TenNhaCungCap", tenNhaCungCap }
            };
            int result = AccountDAO.Instance.Register(insertQuery, checkQuery, insertParameters, checkParameters);

            if (result == 1)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProviderList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa nhân viên
        private void btnEditStaff_1_Click(object sender, EventArgs e)
        {
            if (getID > 0)
            {
                string tenNhanVien = txbStaff_Name.Text.Trim();
                string taiKhoan = txbStaff_Username.Text.Trim();
                string matKhau = txbStaff_Password.Text.Trim();
                string chucVu = cbStaff_Role.Text.Trim();

                if (string.IsNullOrEmpty(tenNhanVien) || string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(chucVu))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertQuery = "EXEC Sua_Nhan_Vien @MaNhanVien, @TenNhanVien, @TaiKhoan, @MatKhau, @ChucVu";
                string checkQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE TaiKhoan = @TaiKhoan AND MaNhanVien != @MaNhanVien";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@MaNhanVien", getID},
                    { "@TenNhanVien", tenNhanVien },
                    { "@TaiKhoan", taiKhoan },
                    { "@MatKhau", matKhau },
                    { "@ChucVu", chucVu }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
                {
                    {"@MaNhanVien", getID},
                    { "@TaiKhoan", taiKhoan }
                };
                int result = AccountDAO.Instance.Edit(insertQuery, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountList(true); // Load lại danh sách sau khi sửa
                    getID = 0;
                }
                else if (result == -1)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dtgvProvider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvProvider.Rows[e.RowIndex];

                string tenNCC = row.Cells["Tên nhà cung cấp"].Value.ToString() ?? "";
                string SDT = row.Cells["Số điện thoại"].Value?.ToString() ?? "";
                string diaChi = row.Cells["Địa chỉ nhà cung cấp"].Value?.ToString() ?? "";

                getID_Provider = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                txbProvider_Name.Text = tenNCC;
                txbProvider_Phone.Text = SDT;
                txbProvider_Address.Text = diaChi;
            }
        }

        private void dtgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvStaff.Rows[e.RowIndex];

                string tenNV = row.Cells["Tên"].Value.ToString() ?? "";
                string username = row.Cells["Tài khoản"].Value?.ToString() ?? "";
                string password = row.Cells["Mật khẩu"].Value?.ToString() ?? "";
                string chucVu = row.Cells["Chức vụ"].Value?.ToString() ?? "";

                getID = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                //getID = (int)row.Cells[0].Value;

                txbStaff_Name.Text = tenNV;
                txbStaff_Username.Text = username;
                txbStaff_Password.Text = password;
                cbStaff_Role.Text = chucVu;
            }
        }

        private void btnResetProvider_1_Click(object sender, EventArgs e)
        {
            LoadProviderList(true);
            txbProvider_Name.Clear();
            txbProvider_Phone.Clear();
            txbProvider_Address.Clear();
            getID_Provider = 0;
        }

        private void btnDeleteProvider_1_Click(object sender, EventArgs e)
        {
            if (getID_Provider > 0)
            {
                string query = "EXEC Xoa_Nha_Cung_Cap @MaNhaCungCap";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@MaNhaCungCap", getID_Provider}
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProviderList(true); // Load lại danh sách sau khi xóa
                    //reset ID
                    getID_Provider = 0;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditProvider_1_Click(object sender, EventArgs e)
        {
            if (getID_Provider > 0)
            {
                string tenNhaCungCap = txbProvider_Name.Text.Trim();
                string soDienThoai = txbProvider_Phone.Text.Trim();
                string diaChi = txbProvider_Address.Text.Trim();

                if (string.IsNullOrEmpty(tenNhaCungCap) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsValidPhoneNumber(soDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ chứa 10-11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "EXEC Sua_Nha_Cung_Cap @MaNhaCungCap, @TenNhaCungCap, @SoDienThoai, @DiaChi";
                string checkQuery = "SELECT COUNT(*) FROM NHACUNGCAP WHERE TenNhaCungCap = @TenNhaCungCap AND MaNhaCungCap != @MaNhaCungCap";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@MaNhaCungCap", getID_Provider},
                    { "@TenNhaCungCap", tenNhaCungCap },
                    { "@SoDienThoai", soDienThoai },
                    { "@DiaChi", diaChi }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
                {
                    {"@MaNhaCungCap", getID_Provider},
                    {"@TenNhaCungCap", tenNhaCungCap}
                };

                int result = AccountDAO.Instance.Edit(query, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProviderList(true); // Load lại danh sách sau khi sửa
                    getID_Provider = 0;
                }
                else if (result == -1)
                {
                    MessageBox.Show("Nhà cung cấp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dtgvProdType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvProdType.Rows[e.RowIndex];

                string tenLoaiSanPham = row.Cells["Tên loại sản phẩm"].Value.ToString() ?? "";
                string donViTinh = row.Cells["Đơn vị tính"].Value?.ToString() ?? "";
                string loiNhuan = row.Cells["Lợi nhuận"].Value?.ToString() ?? "";

                getID_ProdType = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                txbProdType_Name.Text = tenLoaiSanPham;
                cbProdType_DonVi.Text = donViTinh;
                txbProdType_LN.Text = loiNhuan;
            }
        }

        private void btn_AddProdType_Click(object sender, EventArgs e)
        {
            string tenLoaiSanPham = txbProdType_Name.Text.Trim();
            string donViTinh = cbProdType_DonVi.Text.Trim();
            string loiNhuan = txbProdType_LN.Text.Trim();
            int loiNhuanInt;


            if (string.IsNullOrEmpty(tenLoaiSanPham) || string.IsNullOrEmpty(donViTinh) || string.IsNullOrEmpty(loiNhuan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(loiNhuan, out loiNhuanInt) || loiNhuanInt < 0)
            {
                MessageBox.Show("Vui lòng nhập lợi nhuận là một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertQuery = "EXEC Them_LoaiSanPham @TenLoaiSanPham, @DonViTinh, @LoiNhuan";

            string checkQuery = "SELECT COUNT(*) FROM LOAISANPHAM WHERE TenLoaiSanPham = @TenLoaiSanPham";

            Dictionary<string, object> insertParameters = new Dictionary<string, object>()
            {
                { "@TenLoaiSanPham", tenLoaiSanPham },
                { "@DonViTinh", donViTinh },
                { "@LoiNhuan", loiNhuanInt }
            };

            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TenLoaiSanPham", tenLoaiSanPham }
            };
            int result = AccountDAO.Instance.Register(insertQuery, checkQuery, insertParameters, checkParameters);
            if (result == 1)
            {
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductTypeList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Loại sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadProductType_Into_Product();
        }

        private void btn_DelProdType_Click(object sender, EventArgs e)
        {
            if (getID_ProdType > 0)
            {
                string query = "EXEC Xoa_LoaiSanPham @MaLoaiSP";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"@MaLoaiSP", getID_ProdType}
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductTypeList(true); // Load lại danh sách sau khi xóa
                    //reset ID
                    getID_ProdType = 0;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadProductType_Into_Product();
        }

        private void btn_EditProdType_Click(object sender, EventArgs e)
        {
            if (getID_ProdType > 0)
            {
                string tenLoaiSanPham = txbProdType_Name.Text.Trim();
                string donViTinh = cbProdType_DonVi.Text.Trim();
                string loiNhuan = txbProdType_LN.Text.Trim();
                int loiNhuanInt;

                if (string.IsNullOrEmpty(tenLoaiSanPham) || string.IsNullOrEmpty(donViTinh) || string.IsNullOrEmpty(loiNhuan))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(loiNhuan, out loiNhuanInt) || loiNhuanInt < 0)
                {
                    MessageBox.Show("Vui lòng nhập lợi nhuận là một số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string query = "EXEC Sua_LoaiSanPham @MaLoaiSP, @TenLoaiSanPham, @DonViTinh, @LoiNhuan";
                string checkQuery = "SELECT COUNT(*) FROM LOAISANPHAM WHERE TenLoaiSanPham = @TenLoaiSanPham AND MaLoaiSP != @MaLoaiSP";

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@MaLoaiSP", getID_ProdType },
                    { "@TenLoaiSanPham", tenLoaiSanPham },
                    { "@DonViTinh", donViTinh },
                    { "@LoiNhuan", loiNhuanInt }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
                {
                    { "@MaLoaiSP", getID_ProdType },
                    { "@TenLoaiSanPham", tenLoaiSanPham }
                };

                int result = AccountDAO.Instance.Edit(query, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductTypeList(true); // Load lại danh sách sau khi sửa
                    getID_ProdType = 0; //reset ID
                }
                else if (result == -1)
                {
                    MessageBox.Show("Loại sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Loại sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Loại sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadProductType_Into_Product();
        }

        private void btn_ResetProdType_Click(object sender, EventArgs e)
        {
            LoadProductTypeList(true);
            txbProdType_Name.Clear();
            cbProdType_DonVi.Text = string.Empty;
            txbProdType_LN.Clear();
            getID_ProdType = 0;
        }


        private void dtgvService1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvService1.Rows[e.RowIndex];

                string tenLoaiDichVu = row.Cells["Tên loại dịch vụ"].Value.ToString() ?? "";
                string donGia = row.Cells["Đơn giá"].Value?.ToString() ?? "";

                getID_Service = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                txbService_Name.Text = tenLoaiDichVu;
                txbService_Price.Text = donGia;
            }
        }

        private void btn_AddService_Click(object sender, EventArgs e)
        {
            string tenLoaiDichVu = txbService_Name.Text.Trim();
            string donGiaText = txbService_Price.Text.Trim();

            if (string.IsNullOrEmpty(tenLoaiDichVu) || string.IsNullOrEmpty(donGiaText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(donGiaText, out float donGia) || donGia < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "EXEC Them_LoaiDichVu @TenLoaiDichVu, @DonGia";
            string checkQuery = "SELECT COUNT(*) FROM LOAIDICHVU WHERE TenLoaiDichVu = @TenLoaiDichVu";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TenLoaiDichVu", tenLoaiDichVu },
                { "@DonGia", donGia }
            };

            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TenLoaiDichVu", tenLoaiDichVu }
            };

            int result = AccountDAO.Instance.Register(query, checkQuery, parameters, checkParameters);
            if (result == 1)
            {
                MessageBox.Show("Thêm loại dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Loại dịch vụ đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DelService_Click(object sender, EventArgs e)
        {
            if (getID_Service > 0)
            {
                string query = "EXEC Xoa_LoaiDichVu @MaDichVu";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaDichVu", getID_Service }
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa loại dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServiceList(true); // Load lại danh sách sau khi xóa
                    //reset ID
                    getID_ProdType = 0;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_ResetService_Click(object sender, EventArgs e)
        {
            LoadServiceList(true);
            txbService_Name.Clear();
            txbService_Price.Clear();
            getID_Service = 0;
        }

        private void btn_EditService_Click(object sender, EventArgs e)
        {
            if (getID_Service > 0)
            {
                string tenLoaiDichVu = txbService_Name.Text.Trim();
                string donGiaText = txbService_Price.Text.Trim();

                if (string.IsNullOrEmpty(tenLoaiDichVu) || string.IsNullOrEmpty(donGiaText))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(donGiaText, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Vui lòng nhập đơn giá là số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "EXEC Sua_LoaiDichVu @MaDichVu, @TenLoaiDichVu, @DonGia";
                string checkQuery = "SELECT COUNT(*) FROM LOAIDICHVU WHERE TenLoaiDichVu = @TenLoaiDichVu AND MaDichVu != @MaDichVu";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaDichVu", getID_Service },
                    { "@TenLoaiDichVu", tenLoaiDichVu },
                    { "@DonGia", donGia }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
                {
                    { "@MaDichVu", getID_Service },
                    { "@TenLoaiDichVu", tenLoaiDichVu }
                };

                int result = AccountDAO.Instance.Edit(query, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServiceList(true);
                    getID_Service = 0;
                }
                else if (result == -1)
                {
                    MessageBox.Show("Tên loại dịch vụ đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại dịch vụ để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvCustomer.Rows[e.RowIndex];

                string tenKhachHang = row.Cells["Họ tên khách hàng"].Value.ToString() ?? "";
                string soDienThoai = row.Cells["Số điện thoại"].Value?.ToString() ?? "";

                getID_Customer = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                txbCustomer_Name.Text = tenKhachHang;
                txbCustomer_Phone.Text = soDienThoai;
            }
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            string soDienThoai = txbCustomer_Phone.Text.Trim();
            string tenKhachHang = txbCustomer_Name.Text.Trim();

            if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(tenKhachHang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ chứa 10-11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "EXEC Them_KhachHang @SoDienThoai, @TenKhachHang";
            string checkQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE SoDienThoai = @SoDienThoai";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@SoDienThoai", soDienThoai },
                { "@TenKhachHang", tenKhachHang }
            };

            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@SoDienThoai", soDienThoai }
            };

            int result = AccountDAO.Instance.Register(query, checkQuery, parameters, checkParameters);

            if (result == 1)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DelCustomer_Click(object sender, EventArgs e)
        {
            if (getID_Customer > 0)
            {
                string query = "EXEC Xoa_KhachHang @MaKhachHang";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaKhachHang", getID_Customer }
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerList(true); // Load lại danh sách sau khi xóa
                    getID_Customer = 0; // Reset ID
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_EditCustomer_Click(object sender, EventArgs e)
        {
            if (getID_Customer > 0)
            {
                string soDienThoai = txbCustomer_Phone.Text.Trim();
                string tenKhachHang = txbCustomer_Name.Text.Trim();

                if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(tenKhachHang))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsValidPhoneNumber(soDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ chứa 10-11 chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "EXEC Sua_KhachHang @MaKhachHang, @SoDienThoai, @TenKhachHang";
                string checkQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE SoDienThoai = @SoDienThoai AND MaKhachHang != @MaKhachHang";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaKhachHang", getID_Customer },
                    { "@SoDienThoai", soDienThoai },
                    { "@TenKhachHang", tenKhachHang }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>()
                {
                    { "@SoDienThoai", soDienThoai },
                    { "@MaKhachHang", getID_Customer }
                };

                int result = AccountDAO.Instance.Edit(query, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerList(true);
                    getID_Customer = 0; // Reset ID
                }
                else if (result == -1)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_ResetCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList(true);
            txbCustomer_Name.Clear();
            txbCustomer_Phone.Clear();
            getID_Customer = 0;
        }



        private void LoadProductType_Into_Product()
        {
            string query = "SELECT MaLoaiSP, TenLoaiSanPham FROM LOAISANPHAM";
            DataTable categories = DataProvider.Instance.ExecuteQuery(query);

            cbProduct_Type.DataSource = categories;
            cbProduct_Type.DisplayMember = "TenLoaiSanPham"; // Hiển thị tên loại
            cbProduct_Type.ValueMember = "MaLoaiSP"; // Giá trị thật (MaLoaiSP)
        }

        private void dtgvProduct1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvProduct1.Rows[e.RowIndex];

                string tenSanPham = row.Cells["Tên sản phẩm"].Value.ToString() ?? "";
                int maLoai = Convert.ToInt32(row.Cells["Mã loại"].Value);
                int soLuong = 0;
                if (row.Cells["Số lượng"].Value != null && int.TryParse(row.Cells["Số lượng"].Value.ToString(), out int soLuongValue))
                {
                    soLuong = soLuongValue;
                }
                float donGia = 0;
                if (row.Cells["Đơn giá"].Value != null && float.TryParse(row.Cells["Đơn giá"].Value.ToString(), out float donGiaValue))
                {
                    donGia = donGiaValue;
                }
                string donGiaText = row.Cells["Đơn giá"].Value?.ToString() ?? "";
                bool tinhTrang = Convert.ToBoolean(row.Cells["Tình trạng"].Value);

                getID_Product = row.Cells[0].Value != null ? (int)row.Cells[0].Value : 0;

                txbProduct_Name.Text = tenSanPham;
                cbProduct_Type.SelectedValue = maLoai;
                nmProduct_SL.Value = soLuong;
                txbProduct_Price.Text = donGia.ToString();
                checkbProduct_Status.Checked = tinhTrang;
            }
        }

        private void btn_AddProd_Click(object sender, EventArgs e)
        {
            string tenSanPham = txbProduct_Name.Text.Trim();
            int maLoai = Convert.ToInt32(cbProduct_Type.SelectedValue); // Lấy MaLoai từ ComboBox
            //int soLuong = (int)nmProduct_SL.Value; // Lấy giá trị từ NumericUpDown
            //string donGiaText = txbProduct_Price.Text.Trim();
            bool tinhTrang = checkbProduct_Status.Checked;

            if (string.IsNullOrEmpty(tenSanPham))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "EXEC Them_SanPham @TenSanPham, @MaLoai, @TinhTrang";
            string checkQuery = "SELECT COUNT(*) FROM SANPHAM WHERE TenSanPham = @TenSanPham";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TenSanPham", tenSanPham },
                { "@MaLoai", maLoai },
                //{ "@SoLuong", soLuong },
                { "@TinhTrang", tinhTrang ? 1 : 0 }
            };

            Dictionary<string, object> checkParameters = new Dictionary<string, object>()
            {
                { "@TenSanPham", tenSanPham }
            };
            int result = AccountDAO.Instance.Register(query, checkQuery, parameters, checkParameters);

            if (result == 1)
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductList(true); // Load lại danh sách sau khi thêm
            }
            else if (result == -1)
            {
                MessageBox.Show("Sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DelProd_Click(object sender, EventArgs e)
        {
            if (getID_Product > 0)
            {
                string query = "EXEC Xoa_SanPham @MaSanPham";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaSanPham", getID_Product }
                };

                int result = AccountDAO.Instance.Delete(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductList(true); // Load lại danh sách
                    getID_Product = 0; // Reset ID
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_EditProd_Click(object sender, EventArgs e)
        {
            if (getID_Product > 0)
            {
                string tenSanPham = txbProduct_Name.Text.Trim();
                int maLoai = Convert.ToInt32(cbProduct_Type.SelectedValue);
                //int soLuong = (int)nmProduct_SL.Value;
                //string donGiaText = txbProduct_Price.Text.Trim();
                bool tinhTrang = checkbProduct_Status.Checked;

                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "EXEC Sua_SanPham @MaSanPham, @TenSanPham, @MaLoai, @TinhTrang";
                string checkQuery = "SELECT COUNT(*) FROM SANPHAM WHERE TenSanPham = @TenSanPham AND MaSanPham != @MaSanPham";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaSanPham", getID_Product },
                    { "@TenSanPham", tenSanPham },
                    { "@MaLoai", maLoai },
                    { "@TinhTrang", tinhTrang ? 1 : 0 }
                };

                Dictionary<string, object> checkParameters = new Dictionary<string, object>
                {
                    { "@TenSanPham", tenSanPham },
                    { "@MaSanPham", getID_Product }
                };

                int result = AccountDAO.Instance.Edit(query, parameters, checkQuery, checkParameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductList(true); // Load lại danh sách
                    getID_Product = 0; // Reset ID
                }
                else if (result == -1)
                {
                    MessageBox.Show("Tên sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_ResetProd_Click(object sender, EventArgs e)
        {
            LoadProductList(true);
            txbProduct_Name.Clear();
            nmProduct_SL.Value = 0; // Reset số lượng
            txbProduct_Price.Clear();
            cbProduct_Type.SelectedIndex = 0; // Đặt về giá trị đầu tiên
            checkbProduct_Status.Checked = false; // Reset tình trạng
            getID_Product = 0; // Reset ID
        }

        private void btnSearchProd_Click(object sender, EventArgs e)
        {

        }
    }
}

