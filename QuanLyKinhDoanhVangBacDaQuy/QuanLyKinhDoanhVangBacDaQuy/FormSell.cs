using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKinhDoanhVangBacDaQuy.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormSell : Form
    {
        private string ProductId;
        private int receiptId;
        private DataTable dataTable;
        private DataTable dt;
        private int number;
        private float price;
        private float totalMoney;
        private string CustomerId;
        private string CustomerId_Old;
        public FormSell()
        {
            InitializeComponent();
            InitializeProductId();
            InitializeCustomerId();
            InitializeStaffId();
            InitializeReceiptTable();
            InitializeReceiptId();
            LoadProductList();

        }

        private void FormSell_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductId = comboBox1.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Ban_Hang @MaSanPham";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { ProductId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox1.Text = dataRows[0]["Tên sản phẩm"].ToString();
            textBox2.Text = dataRows[0]["Đơn vị tính"].ToString();
            textBox3.Text = dataRows[0]["Đơn giá"].ToString();
            textBox7.Text = dataRows[0]["Tên loại sản phẩm"].ToString();
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CustomerId = comboBox2.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Ban_Hang_Khach_Hang @MaKhachHang";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { CustomerId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox5.Text = dataRows[0]["Tên khách hàng"].ToString();
            textBox6.Text = dataRows[0]["Số điện thoại"].ToString();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            string  StaffId = comboBox3.SelectedItem.ToString();

            string query = "EXEC Thanh_Toan_Phieu_Ban_Hang_Nhan_Vien @MaNhanVien";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { StaffId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox10.Text = dataRows[0]["Tên nhân viên"].ToString();


            
        }
        private void InitializeProductId()
        {
            string query = "SELECT * FROM SANPHAM";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { });
            int i = 0;
            int[] Pid = new int[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {
                Pid[i++] = Convert.ToInt32(row["MaSanPham"]);

            }
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox1.Items.Add(Pid[i].ToString());
            }
        }
        private void InitializeCustomerId()
        {
            string query = "SELECT * FROM KHACHHANG";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { });
            int i = 0;
            int[] Pid = new int[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {
                Pid[i++] = Convert.ToInt32(row["MaKhachHang"]);

            }
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox2.Items.Add(Pid[i].ToString());
            }
        }
        private void InitializeStaffId()
        {
            string query = "SELECT * FROM NHANVIEN";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { });
            int i = 0;
            int[] Pid = new int[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {
                Pid[i++] = Convert.ToInt32(row["MaNhanVien"]);

            }
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox3.Items.Add(Pid[i].ToString());
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            number = (int)numericUpDown1.Value;
        }
        private void LoadProductList()
        {
            string query = "SELECT MaSanPham as [Mã sản phẩm],TenSanPham as [Tên sản phẩm],MaLoai as [Mã loại],\r\n\t   SoLuong as [Số lượng],DonGia as [Đơn giá],TinhTrang as [Tình trạng]\r\nFROM SANPHAM";
            DataProvider provider = DataProvider.Instance;
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa ngang
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;                 // Không ngắt dòng
            }
        }
        private void InitializeReceiptTable()
        {
            dt = new DataTable();
            dt.Columns.Add("STT", typeof(string));
            dt.Columns.Add("Mã sản phẩm", typeof(int));
            dt.Columns.Add("Sản phẩm", typeof(string));
            dt.Columns.Add("Loại sản phẩm", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Đơn vị tính", typeof(string));
            dt.Columns.Add("Đơn giá", typeof(float));
            dt.Columns.Add("Thành tiền", typeof(float));
        }
        private void InitializeReceiptId()
        {
            string query = "SELECT DISTINCT MaPhieuBan FROM PHIEUBANHANG";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            receiptId = result.Rows.Count + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerId = comboBox2.Text;
            if (textBox3.Text != null && textBox3.Text != "")
            {
                price = float.Parse(textBox3.Text);
            }
            else
            {
                price = 0;
            }
            totalMoney = 0;

            if (dt.Rows.Count == 0)
            {
                CustomerId_Old = comboBox2.Text;
            }

            DataRow[] ketQua = dt.Select($"[Sản phẩm] = '{textBox1.Text}'");

            if (ketQua.Length > 0)
            {


                MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn,xin vui lòng chọn sản phẩm khác! Nếu bạn muốn thay đổi sản phẩm này " +
                    " bạn có thể xóa sản phẩm này đi và thêm lại ", "Thông báo");


            }
            else if (number == 0)
            {
                MessageBox.Show("Hãy nhập vào số lượng hợp lệ !", "Thông báo");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm, vui lòng chọn mã sản phẩm để thêm vào phiếu !", "Thông báo");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng,vui lòng chọn khách hàng để thêm vào phiếu !", "Thông báo");
            }
            else if (CustomerId != CustomerId_Old)
            {
                MessageBox.Show("Bạn đang thay đổi khách hàng cho một hóa đơn.Mỗi hóa đơn chỉ có thể có một khách hàng.Bạn hiện đang nhập hóa đơn cho khách hàng có mã là " + CustomerId_Old +
                    " .Hãy tạo lại hóa đơn hoặc tạo hóa đơn mới nếu muốn thay đổi khách hàng !", "Thông báo");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên, vui lòng chọn mã nhân viên để thêm vào phiếu !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã thêm vào hóa đơn !", "Thông báo");
                Debug.WriteLine($"Added to Receipt table");
                dt.Rows.Add((dt.Rows.Count + 1).ToString(), int.Parse(comboBox1.Text), textBox1.Text, textBox7.Text, number, textBox2.Text, float.Parse(textBox3.Text), price * number);
                dataGridView2.DataSource = dt;
            }


            foreach (DataRow row in dt.Rows)
            {
                totalMoney += float.Parse(row["Thành tiền"].ToString());
            }

            DateTime day = DateTime.Now;

            textBox8.Text = (receiptId).ToString();
            textBox9.Text = day.ToString("dd/MM/yyyy");
            textBox4.Text = (totalMoney).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["Mã sản phẩm"].ToString() == comboBox1.Text)
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["STT"] = i;
            }
            totalMoney = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalMoney += float.Parse(row["Thành tiền"].ToString());
            }
            textBox4.Text = (totalMoney).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalMoney = 0;
            textBox4.Text = (totalMoney).ToString();
            dt.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count != 0)
            {
                DateTime date = DateTime.Now;
                foreach (DataRow row in dt.Rows)
                {
                    DataTable dataTable = new DataTable();
                    string query = "INSERT INTO PHIEUBANHANG (MaPhieuBan, MaKhachHang,MaNhanVien, MaSanPham,SoLuong,NgayBan) " +
                                   "VALUES(" + receiptId + "," + comboBox2.Text + "," + comboBox3.Text + ", " + row["Mã sản phẩm"] + ", " + row["Số lượng"] + ", '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' );";
                    dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { });
                }
                totalMoney = 0;
                textBox4.Text = (totalMoney).ToString();
                dt.Clear();
                InitializeReceiptId();
                textBox8.Text = (receiptId).ToString();
                LoadProductList();
                MessageBox.Show("Thanh toán thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hãy thêm sản phẩm vào phiếu để thực hiện thanh toán !", "Thông báo");
            }
        }


    }
}
