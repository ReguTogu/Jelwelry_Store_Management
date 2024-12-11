using System;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormService : Form
    {
        private string ServiceId;
        private int receiptId;
        private DataTable dataTable;
        private DataTable dt;
        private int number;
        private float price;
        private float totalMoney;
        private float pre_pay;
        private float left_money;
        private string CustomerId;
        private string CustomerId_Old;
        public FormService()
        {
            InitializeComponent();
            InitializeServiceId();
            InitializeCustomerId();
            InitializeStaffId();
            InitializeReceiptTable();
            InitializeReceiptId();
            LoadServiceList();
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceId = comboBox1.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Dich_Vu @MaDichVu";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { ServiceId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox1.Text = dataRows[0]["Tên loại dịch vụ"].ToString();
            textBox2.Text = dataRows[0]["Đơn giá"].ToString();
            textBox3.Text = dataRows[0]["Đơn giá"].ToString();
            number = (int)numericUpDown1.Value;
            price = float.Parse(textBox2.Text);
            totalMoney = number * price;
            textBox15.Text = totalMoney.ToString();
            if (textBox5.Text != null && textBox5.Text != "")
            {
                pre_pay = float.Parse(textBox5.Text);
                left_money = totalMoney - pre_pay;
                textBox6.Text = left_money.ToString();
            }
            else
            {
                pre_pay = 0;
                left_money = 0;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerId = comboBox2.SelectedItem.ToString();
            string query = "EXEC Thanh_Toan_Phieu_Ban_Hang_Khach_Hang @MaKhachHang";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { CustomerId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox12.Text = dataRows[0]["Tên khách hàng"].ToString();
            textBox7.Text = dataRows[0]["Số điện thoại"].ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string StaffId = comboBox3.SelectedItem.ToString();

            string query = "EXEC Thanh_Toan_Phieu_Ban_Hang_Nhan_Vien @MaNhanVien";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { StaffId });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            textBox13.Text = dataRows[0]["Tên nhân viên"].ToString();
        }

        private void InitializeServiceId()
        {
            string query = "SELECT * FROM LOAIDICHVU";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { });
            int i = 0;
            int[] Pid = new int[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {
                Pid[i++] = Convert.ToInt32(row["MaDichVu"]);

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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            number = (int)numericUpDown1.Value;
            totalMoney = 0;
            if (textBox2.Text != null && textBox2.Text != "")
            {
                price = float.Parse(textBox2.Text);
                totalMoney = number * price;
                textBox15.Text = totalMoney.ToString();
                if (textBox5.Text != null && textBox5.Text != "")
                {
                    pre_pay = float.Parse(textBox5.Text);
                    left_money = totalMoney - pre_pay;
                    textBox6.Text = left_money.ToString();
                }
                else
                {
                    pre_pay = 0;
                    left_money = 0;
                }
            }




        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập các ký tự số và phím điều khiển như Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập vào chữ số !", "Thông báo");
            }

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != null && textBox5.Text != "")
            {
                int valid_string = 1;
                foreach (char c in textBox5.Text)
                {
                    if (!Char.IsDigit(c)) // Nếu không phải là chữ số
                    {
                        valid_string = 0;
                        MessageBox.Show("Vui lòng chỉ nhập vào chữ số !", "Thông báo");
                        textBox5.Text = "";
                    }
                }
                if (valid_string == 1)
                {

                    if (textBox15.Text != null && textBox15.Text != "")
                    {
                        totalMoney = float.Parse(textBox15.Text);
                        if (textBox5.Text != null && textBox5.Text != "")
                        {
                            pre_pay = float.Parse(textBox5.Text);
                            left_money = totalMoney - pre_pay;
                            textBox6.Text = left_money.ToString();
                        }
                    }
                }
                
            }


        }
        private void LoadServiceList()
        {
            string query = "SELECT MaDichVu as [Mã dịch vụ],TenLoaiDichVu as [Tên loại dịch vụ],DonGia as [Đơn giá] FROM LOAIDICHVU";
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
            dt.Columns.Add("Mã dịch vụ", typeof(int));
            dt.Columns.Add("Tên loại dịch vụ", typeof(string));
            dt.Columns.Add("Đơn giá dịch vụ", typeof(float));
            dt.Columns.Add("Đơn giá được tính", typeof(float));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Thành tiền", typeof(float));
            dt.Columns.Add("Trả trước", typeof(float));
            dt.Columns.Add("Còn lại", typeof(float));
            dt.Columns.Add("Ngày giao", typeof(string));
            dt.Columns.Add("Tình trạng", typeof(string));


        }
        private void InitializeReceiptId()
        {
            string query = "SELECT DISTINCT MaPhieuDichVu FROM PHIEUDICHVU";
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

            if (textBox5.Text != null && textBox5.Text != "")
            {
                pre_pay = float.Parse(textBox5.Text);
            }
            else
            {
                pre_pay = 0;
            }
            totalMoney = 0;

            if (dt.Rows.Count == 0)
            {
                CustomerId_Old = comboBox2.Text;
            }

            DataRow[] ketQua = dt.Select($"[Tên loại dịch vụ] = '{textBox1.Text}'");

            if (ketQua.Length > 0)
            {


                MessageBox.Show("Dịch vụ đã tồn tại trong hóa đơn, xin vui lòng chọn dịch vụ khác! Nếu bạn muốn thay đổi dịch vụ này " +
                    "bạn có thể xóa dịch vụ này đi và thêm lại.", "Thông báo");


            }
            else if (number == 0)
            {
                MessageBox.Show("Hãy nhập vào số lượng hợp lệ !", "Thông báo");
            }
            else if (!(((price * number) / 2) <= pre_pay && pre_pay <= (price * number)))
            {
                MessageBox.Show("Số tiền trả trước phải ít nhất bằng một nửa thành tiền và không vượt quá thành tiền!", "Thông báo");
            }

            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã dịch vụ, vui lòng chọn mã dịch vụ để thêm vào phiếu!", "Thông báo");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng,vui lòng chọn khách hàng để thêm vào phiếu!", "Thông báo");
            }
            else if (CustomerId != CustomerId_Old)
            {
                MessageBox.Show("Bạn đang thay đổi khách hàng cho một hóa đơn. Mỗi hóa đơn chỉ có thể có một khách hàng. Bạn hiện đang nhập hóa đơn cho khách hàng có mã là " + CustomerId_Old +
                    ". Hãy tạo lại hóa đơn hoặc tạo hóa đơn mới nếu muốn thay đổi khách hàng!", "Thông báo");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên, vui lòng chọn mã nhân viên để thêm vào phiếu!", "Thông báo");
            }
            else if (comboBox4.Text == "" || (comboBox4.Text != "Đã giao" && comboBox4.Text != "Chưa giao"))
            {
                MessageBox.Show("Tình trạng chỉ có thể là 'Đã giao' hoặc 'Chưa giao'!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đã thêm vào hóa đơn!", "Thông báo");
                Debug.WriteLine($"Added to Receipt table");
                DateTime date = DateTime.Now;
                dt.Rows.Add((dt.Rows.Count + 1).ToString(), int.Parse(comboBox1.Text), textBox1.Text, float.Parse(textBox2.Text), float.Parse(textBox3.Text), number, price * number, pre_pay, left_money, date.ToString("yyyy-MM-dd "), comboBox4.Text.ToString());
                dataGridView2.DataSource = dt;
            }

            left_money = 0;
            pre_pay = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalMoney += float.Parse(row["Thành tiền"].ToString());
                pre_pay += float.Parse(row["Trả trước"].ToString());
                left_money += float.Parse(row["Còn lại"].ToString());
            }

            DateTime day = DateTime.Now;

            textBox8.Text = (receiptId).ToString();
            textBox9.Text = day.ToString("dd/MM/yyyy");
            textBox4.Text = (totalMoney).ToString();
            textBox10.Text = (pre_pay).ToString();
            textBox11.Text = (left_money).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["Mã dịch vụ"].ToString() == comboBox1.Text)
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

            pre_pay = 0;
            foreach (DataRow row in dt.Rows)
            {
                pre_pay += float.Parse(row["Trả trước"].ToString());
            }
            textBox10.Text = (pre_pay).ToString();

            left_money = 0;
            foreach (DataRow row in dt.Rows)
            {
                left_money += float.Parse(row["Còn lại"].ToString());
            }
            textBox11.Text = (left_money).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            textBox4.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
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
                    string query = "INSERT INTO PHIEUDICHVU (MaPhieuDichVu,MaKhachHang, MaNhanVien, MaDichVu, SoLuong,TraTruoc, TinhTrang, NgayBan) " +
                                   "VALUES(" + receiptId + "," + int.Parse(comboBox2.Text) + "," + int.Parse(comboBox3.Text) + ", " + row["Mã dịch vụ"] + "," + row["Số lượng"] + ","+ row["Trả trước"] +",N'"+ row["Tình trạng"].ToString() + "', '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                    dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { });
                }
                textBox4.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                dt.Clear();
                InitializeReceiptId();
                textBox8.Text = (receiptId).ToString();
            }
            else
            {
                MessageBox.Show("Hãy thêm dịch vụ vào phiếu để thực hiện thanh toán!", "Thông báo");
            }
        }


    }
}
