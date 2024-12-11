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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormDashboard : Form
    {
        private string month;
        private string year;
        private DataTable dataTable;
        public FormDashboard()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            DateTime date = DateTime.Now;
            for (int i = date.Year - 10; i <= date.Year + 10; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = comboBox1.SelectedItem.ToString();
            if (comboBox2.Text != null && comboBox2.Text != "")
            {
                LoadRevenue();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = comboBox2.SelectedItem.ToString();
            if (comboBox1.Text != null && comboBox1.Text != "")
            {
                LoadRevenue();
            }
        }

        void LoadRevenue()
        {

            string query = "EXEC Show_Revenue @Thang , @Nam";
            DataProvider provider = DataProvider.Instance;
            dataTable = provider.ExecuteQuery(query, new object[] { month, year });
            DataRow[] dataRows = dataTable.Rows.Cast<DataRow>().ToArray();
            label2.Text = dataRows[0]["TienVon"].ToString();
            label5.Text = dataRows[0]["DoanhThuSanPham"].ToString();
            label7.Text = dataRows[0]["DoanhThuDichVu"].ToString();
            label9.Text = dataRows[0]["DoanhThu"].ToString();
            label17.Text = dataRows[0]["LoiNhuan"].ToString();

        }
    }
}
