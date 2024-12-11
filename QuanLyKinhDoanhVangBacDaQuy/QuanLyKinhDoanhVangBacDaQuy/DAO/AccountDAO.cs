using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace QuanLyKinhDoanhVangBacDaQuy.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @TaiKhoan , @MatKhau";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        public int Register(string insertQuery, string checkQuery, Dictionary<string, object> insertParameters, Dictionary<string, object> checkParameters)
        {
            int result = DataProvider.Instance.InsertDataNew(insertQuery, insertParameters, checkQuery, checkParameters);
            return result;
        }

        public int Edit(string insertQuery, Dictionary<string, object> insertParameters, string checkQuery = null, Dictionary<string, object> checkParameters = null)
        {
            int result;
            // Nếu điều kiện trùng checkQuery hoặc checkParameters là null, sửa như bình thường
            if (string.IsNullOrEmpty(checkQuery) || checkParameters == null)
            {
                result = DataProvider.Instance.ExecuteNonQuery(insertQuery, insertParameters);
                return result;
            }
            // Kiểm tra điều kiện trùng
            int checkResult = DataProvider.Instance.ExecuteScalar(checkQuery, checkParameters);
            if (checkResult > 0)
            {
                return -1; // Dữ liệu đã tồn tại
            }

            result = DataProvider.Instance.ExecuteNonQuery(insertQuery, insertParameters);
            return result;
        }

        public int Delete(string query, Dictionary<string,object> parameters)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result;
        }
    }
}
