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

namespace QuanLyKinhDoanhVangBacDaQuy
{
    public partial class FormListServiceReceipt : Form
    {
        public FormListServiceReceipt()
        {
            InitializeComponent();
            LoadListServiceReceipt();
        }
        void LoadListServiceReceipt()
        {
            string query = "EXEC Show_Phieu_Dich_Vu";

            DataProvider provider = DataProvider.Instance;

            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa ngang
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;                 // Không ngắt dòng
            }


        }

        private void btn_resetSearch_Click(object sender, EventArgs e)
        {
            LoadListServiceReceipt();
        }
    }
}
