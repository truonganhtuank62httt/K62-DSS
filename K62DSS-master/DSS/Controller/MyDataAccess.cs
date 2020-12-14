using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DSS.Controller
{
    public class MyDataAccess
    {
        String sqlServerConnection = "Data Source=DESKTOP-2C2VRSM\\SQLEXPRESS;Initial Catalog=K62DSS;Integrated Security=True";

        /// <summary>
        /// Đọc dữ liệu trong CSDL qua câu truy vấn SELECT
        /// </summary>
        /// <param name="query">Câu truy vấn dữ liệu SELECT</param>
        /// <returns>Bảng dữ liệu dạng DataTable</returns>
        public DataTable Read(String query)
        {
            SqlConnection connection = new SqlConnection(sqlServerConnection);
            SqlCommand command = new SqlCommand(query, connection);
            DataTable tb = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                tb.Load(dataReader, LoadOption.OverwriteChanges);
                connection.Close();
                
                if (tb != null && tb.Rows.Count > 0)
                    return tb;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Hàm ghi dữ liệu, thực thi các câu lệnh: INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="query">Câu lệnh Insert hoặc Update hay Delete</param>
        /// <returns>Số bản ghi bị tác động</returns>
        public int Write(String query)
        {
            SqlConnection connection = new SqlConnection(sqlServerConnection);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch
            {
                return -1;
            }
        }
    }
}
