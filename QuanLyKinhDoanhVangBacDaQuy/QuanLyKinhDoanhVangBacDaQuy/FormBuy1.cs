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
        private int index;
        private bool button1Clicked = false;
        public FormBuy()
        {
            index = 1;

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
            textBox1.Text = dataRows[0]["TenSanPham"].ToString();
            textBox2.Text = dataRows[0]["DonViTinh"].ToString();
            textBox10.Text = dataRows[0]["TenLoaiSanPham"].ToString();


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
            string ProviderId = comboBox2.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Mua_Hang_Nha_Cung_Cap @MaNhaCungCap";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { ProviderId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox5.Text = dataRows[0]["TenNhaCungCap"].ToString();
            textBox6.Text = dataRows[0]["DiaChi"].ToString();
            textBox7.Text = dataRows[0]["SoDienThoai"].ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            number = (int)numericUpDown1.Value;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string price_text = textBox3.Text;
            if (price_text != "")
            {
                price = float.Parse(price_text);
            }
            else 
            {
                price = 0; 
            }

        }
        private void LoadProductList()
        {
            string query = "SELECT * FROM SANPHAM";
            DataProvider provider = DataProvider.Instance;
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { });

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Căn giữa ngang
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;                 // Không ngắt dòng
            }
        }
        private void LoadProviderList()
        {
            string query = "SELECT * FROM NHACUNGCAP";
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
            dt.Columns.Add("STT",typeof(string));
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
            float totalMoney = 0;
            DataRow[] ketQua = dt.Select($"[Sản phẩm] = '{textBox1.Text}'");
            foreach (DataRow row in ketQua)
            {
                Debug.WriteLine($"STT: {row["STT"]}, " +
                                $"Sản phẩm: {row["Sản phẩm"]}, " +
                                $"Loại sản phẩm: {row["Loại sản phẩm"]}, " +
                                $"Số lượng: {row["Số lượng"]}, " +
                                $"Đơn vị tính: {row["Đơn vị tính"]}, " +
                                $"Đơn giá: {row["Đơn giá"]}, " +
                                $"Thành tiền: {row["Thành tiền"]}");

            }
            if (price <= 0 || ketQua.Length > 0)
            {
                if (ketQua.Length > 0)
                {
                    MessageBox.Show("Hãy sản phẩm đã tồn tại trong hóa đơn,xin vui lòng chọn sản phẩm khác! Nếu bạn muốn thay đổi sản phẩm này " +
                        " bạn có thể xóa sản phẩm này đi và thêm lại ", "Thông báo");
                }
                if (price <= 0)
                {
                    MessageBox.Show("Hãy nhập lại đơn giá hợp lệ !", "Thông báo");
                }

            }
            else
            {
                MessageBox.Show("Added product to receipt!", "Thông báo");
                Debug.WriteLine($"Added to Receipt table");
                dt.Rows.Add((index++).ToString(), textBox1.Text, textBox10.Text,number, textBox2.Text, float.Parse(textBox3.Text),price * number);
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
            button1Clicked = false;
        }
    }
}
