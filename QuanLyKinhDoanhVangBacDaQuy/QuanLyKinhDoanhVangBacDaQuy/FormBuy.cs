using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKinhDoanhVangBacDaQuy.DAO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormBuy : Form
    {
        private string ProductId;
        private int receiptId;
        private DataTable dataTable;
        private DataTable dt;
        private int number;
        private float price;
        private float totalMoney;
        private string ProviderId;
        private string ProviderId_Old;
        public FormBuy()
        {

            InitializeComponent();
            InitializeProductId();
            InitializeProviderId();
            InitializeReceiptTable();
            InitializeReceiptId();
            LoadProductList();
            LoadProviderList();
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductId = comboBox1.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Mua_Hang @MaSanPham";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { ProductId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox1.Text = dataRows[0]["Tên sản phẩm"].ToString();
            textBox2.Text = dataRows[0]["Đơn vị tính"].ToString();
            textBox10.Text = dataRows[0]["Loại sản phẩm"].ToString();


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
        private void InitializeProviderId()
        {
            string query = "SELECT * FROM NHACUNGCAP";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { });
            int i = 0;
            int[] Pid = new int[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {
                Pid[i++] = Convert.ToInt32(row["MaNhaCungCap"]);

            }
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                comboBox2.Items.Add(Pid[i].ToString());
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProviderId = comboBox2.Text;
            string query = "EXEC Thanh_Toan_Phieu_Mua_Hang_Nha_Cung_Cap @MaNhaCungCap";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { ProviderId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox5.Text = dataRows[0]["Tên nhà cung cấp"].ToString();
            textBox6.Text = dataRows[0]["Địa chỉ"].ToString();
            textBox7.Text = dataRows[0]["Số điện thoại"].ToString();


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            number = (int)numericUpDown1.Value;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và phím điều khiển như Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập vào chữ số !", "Thông báo");
            }

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {


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
        private void LoadProviderList()
        {
            string query = "SELECT MaNhaCungCap as [Mã nhà cung cấp],TenNhaCungCap as [Tên nhà cung cấp],\r\n\t   SoDienThoai as [Số điện thoại],DiaChi as [Địa chỉ]\r\nFROM NHACUNGCAP";
            DataProvider provider = DataProvider.Instance;
            dataGridView3.DataSource = provider.ExecuteQuery(query, new object[] { });

            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
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
            string query = "SELECT DISTINCT MaPhieuMua FROM PHIEUMUAHANG";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { });
            receiptId = result.Rows.Count + 1;
        }
        private void button1_Click(object sender, EventArgs e)

        {
            ProviderId = comboBox2.Text;
            if (textBox3.Text != null && textBox3.Text != "")
            {
                price = float.Parse(textBox3.Text);
            }
            else
            {
                price = 0;
            }
            totalMoney = 0;

            DataRow[] ketQua = dt.Select($"[Sản phẩm] = '{textBox1.Text}'");

            if (dt.Rows.Count == 0)
            {
                ProviderId_Old = comboBox2.Text;
            }
            if (ketQua.Length > 0)
            {


                MessageBox.Show("Hãy sản phẩm đã tồn tại trong hóa đơn, xin vui lòng chọn sản phẩm khác! Nếu bạn muốn thay đổi sản phẩm này " +
                    "bạn có thể xóa sản phẩm này đi và thêm lại.", "Thông báo");


            }
            else if (number == 0)
            {
                MessageBox.Show("Hãy nhập vào số lượng hợp lệ!", "Thông báo");
            }
            else if (price == 0)
            {
                MessageBox.Show("Hãy nhập vào đơn giá hợp lệ!", "Thông báo");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp,vui lòng chọn nhà cung cấp để thêm vào phiếu!", "Thông báo");
            }
            else if (ProviderId != ProviderId_Old)
            {
                MessageBox.Show("Bạn đang thay đổi nhà cung cấp cho một hóa đơn. Mỗi hóa đơn chỉ có thể có một nhà cung cấp. Bạn hiện đang nhập hóa đơn cho nhà cung cấp có mã là " + ProviderId_Old +
                    ". Hãy tạo lại hóa đơn hoặc tạo hóa đơn mới nếu muốn thay đổi nhà cung cấp!", "Thông báo");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm, vui lòng chọn mã sản phẩm để thêm vào phiếu!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã thêm vào hóa đơn !", "Thông báo");
                Debug.WriteLine($"Added to Receipt table");
                dt.Rows.Add((dt.Rows.Count + 1).ToString(), int.Parse(comboBox1.Text), textBox1.Text, textBox10.Text, number, textBox2.Text, float.Parse(textBox3.Text), price * number);
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
            LoadProductList();
            LoadProviderList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count != 0)
            {
                DateTime date = DateTime.Now;
                foreach (DataRow row in dt.Rows)
                {
                    DataTable dataTable = new DataTable();
                    string query = "INSERT INTO PHIEUMUAHANG (MaPhieuMua, MaNhaCungCap, MaSanPham, NgayMua, SoLuong, DonGia) " +
                                   "VALUES(" + receiptId + "," + comboBox2.Text + "," + row["Mã sản phẩm"] + ", '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "', " + row["Số lượng"] + "," + row["Đơn giá"] + ");";
                    dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { });
                }
                totalMoney = 0;
                textBox4.Text = (totalMoney).ToString();
                dt.Clear();
                InitializeReceiptId();
                textBox8.Text = (receiptId).ToString();
                MessageBox.Show("Đã thêm hóa đơn mua hàng thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Hãy thêm sản phẩm vào phiếu để thực hiện thanh toán!", "Thông báo");
            }
            LoadProductList();
            LoadProviderList();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
