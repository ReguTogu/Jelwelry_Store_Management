using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuanLyKinhDoanhVangBacDaQuy.DAO
{
    public class DataProvider
    {
        private static DataProvider instance = null; //Singleton
        private static object locker = new object(); //Giới hạn access cho người đang sử dụng
        //Tạo kết nối từ client tới server
        private string connectionSTR = "Data Source=.;Initial Catalog=QuanLyKinhDoanhVangBacDaQuy;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public static DataProvider Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new DataProvider();
                    return instance;
                }

            }
            private set { instance = value; }
        }

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            //Tạo bảng để truyền dữ liệu
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR)) //tự giải phóng dữ liệu khai báo
            {
                //Mở connection
                connection.Open();
                //Thực thi lệnh query trên connection
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string id in listPara)
                    {
                        if (id.Contains("@"))
                        {
                            command.Parameters.AddWithValue(id, parameter[i]);
                            i++;
                        }
                    }
                }
                //Lấy dữ liệu từ câu truy vấn
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        } //Hàm trả ra bảng kết quả

        //Hàm trả về số dòng được thực thi cho các công đoạn: insert, delete, update
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR)) //tự giải phóng dữ liệu khai báo
            {
                //Mở connection
                connection.Open();

                //Thực thi lệnh query trên connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }
        //Hàm nhập giá trị vào database
        public int InsertDataNew(
            string query, Dictionary<string, object> parameter,
            string checkQuery = null, Dictionary<string, object> checkParameters = null
            )
        {
            int done;
            using (SqlConnection connection = new SqlConnection(connectionSTR)) //tự giải phóng dữ liệu khai báo
            {
                connection.Open();
                //Thực thi lệnh query trên connection
                //Kiểm tra dữ liệu trùng lặp
                if (string.IsNullOrEmpty(checkQuery) == false && checkParameters != null)
                {
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        foreach (var param in checkParameters)
                        {
                            checkCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value); //Nếu null, trả về NULL bên SQL 
                        }
                        
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            return -1;
                        }
                    }
                }
                //Insert dữ liệu
                using (SqlCommand insertCmd = new SqlCommand(query, connection))
                {
                    foreach (var param in parameter)
                    {
                        insertCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    try 
                    {
                        insertCmd.ExecuteNonQuery(); //Trả về số dòng bị ảnh hưởng (insert, delete, update)
                        done = 1;
                    }
                    catch (SqlException ex)
                    {
                        done = 0;
                    }    
                }
                connection.Close();
            }
            return done;
        }
        //Hàm trả về số dòng thỏa mãn câu lệnh thực thi
        public int ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    object scalarResult = command.ExecuteScalar();
                    if (scalarResult != null)
                    {
                        result = Convert.ToInt32(scalarResult);
                    }
                }
            }
            return result;
        }
    }
}
