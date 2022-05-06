using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Layer.DAL
{
    public class DataHelper
    {
        private static DataHelper _Instance;

        public static DataHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string sql = @"Data Source=QQUAN0147\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True";
                    _Instance = new DataHelper(sql);
                }
                return _Instance;
            }
            private set { }
        }

        private SqlConnection cnn;

        private DataHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExecuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetRecordsSV(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
    }
}

