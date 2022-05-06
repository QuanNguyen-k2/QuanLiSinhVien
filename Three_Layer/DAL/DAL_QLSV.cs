using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Three_Layer.DTO;
namespace Three_Layer.DAL
{
    public class DAL_QLSV
    {
        private static DAL_QLSV _Instance;
        public static DAL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLSV();
                }
                return _Instance;
            }
            set { }
        }
        public DAL_QLSV()
        {
            
        }
        public  List<SV> GetALLSV()
        {
            List<SV> data = new List<SV>();
            string query = "select * from SinhVien";
            foreach (DataRow i in DataHelper.Instance.GetRecordsSV(query).Rows)
            {
                data.Add(GetSVByDataRow(i));
            }
            return data;
        }
        public SV GetSVByDataRow(DataRow i)
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                NameSV = i["NameSV"].ToString(),
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString()),
                Gender = Convert.ToBoolean(i["GioiTinh"]),
                NgaySinh = Convert.ToDateTime(i["NgaySinh"].ToString()),
                DTB = Convert.ToDouble(i["DTB"].ToString()),
                Anh = Convert.ToBoolean(i["Anh"]),
                HocBa = Convert.ToBoolean(i["HocBa"]),
                Cmnd = Convert.ToBoolean(i["CMND"])


            };
        }
        
        public List<LopSH> GetAllLopSh()
        {
            List<LopSH> data = new List<LopSH>();
            string query = "select * from LopSH";
            foreach (DataRow i in DataHelper.Instance.GetRecordsSV(query).Rows)
            {
                data.Add(new LopSH
                {
                    ID = Convert.ToInt32(i["ID"].ToString()),
                    NameLop = i["NameLop"].ToString()
                });
            }

            return data;
        }

        public void Add(SV s)
        {
            string query = "insert into SinhVien (MSSV, NameSV, ID_Lop, GioiTinh, NgaySinh, DTB, Anh, HocBa, CMND) values ( '" + s.MSSV + "','" +
                    s.NameSV + "','" + s.ID_Lop + "'," +
                    Convert.ToInt32(s.Gender) + ", '" +
                    s.NgaySinh.ToString("yyyy-MM-dd") + "', " +
                    s.DTB + ", " +
                    Convert.ToInt32(s.Anh) + ", " +
                    Convert.ToInt32(s.HocBa) + ", " +
                    Convert.ToInt32(s.Cmnd) + ")";

            DataHelper.Instance.ExecuteDB(query);
        }
        public void Update(SV s)
        {

            string query = "update SinhVien set Name = '" + s.NameSV +
                    "', ID_Lop = '" + s.ID_Lop +
                    "', Gender = " + Convert.ToInt32(s.Gender) +
                    ", NS = '" + s.NgaySinh.ToString() +
                    "', DTB = " + s.DTB +
                    ", Anh = " + Convert.ToInt32(s.Anh) +
                    ", HB = " + Convert.ToInt32(s.HocBa) +
                    ", CMND = " + Convert.ToInt32(s.Cmnd) +
                    " where MSSV = '" + s.MSSV + "'";
            DataHelper.Instance.ExecuteDB(query);
        }
        public void Delete(string s)
        {
            string query = "delete from SinhVien where MSSV ='" + s + "'";
            DataHelper.Instance.ExecuteDB(query);
        }
    }
}
