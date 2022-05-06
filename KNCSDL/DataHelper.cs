using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KNCSDL
{
    public class DataHelper
    {
        private SqlConnection cnn;

        public DataHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query,cnn);
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
