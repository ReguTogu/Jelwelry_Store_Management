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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormInventory : Form
    {
        private string month;
        private string year;
        public FormInventory()
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

        private void FormInventory_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
        void LoadInventory()
        {

            string query = "EXEC Show_Lich_Su_Kho @Thang , @Nam";

            DataProvider provider = DataProvider.Instance;

            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { month, year });

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa ngang
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;                 // Không ngắt dòng
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = comboBox1.SelectedItem.ToString();
            if (comboBox2.Text != null && comboBox2.Text != "")
            {
                LoadInventory();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = comboBox2.SelectedItem.ToString();
            if (comboBox1.Text != null && comboBox1.Text != "")
            {
                LoadInventory();
            }
        }

        private void btn_resetInven_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }
    }
}
