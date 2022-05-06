using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Three_Layer.DTO;
using Three_Layer.DAL;
using System.Data;

namespace Three_Layer.BLL
{
    public class BLL_QLSV
    {
        public static BLL_QLSV Instance
        {
            get {
                if(_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance; }
            set { }
        }
       
        private static BLL_QLSV _Instance;
        
        public List<CBB_Items> GetCBB()
        {
            List<CBB_Items> data = new List<CBB_Items>();
            foreach(var item in DAL_QLSV.Instance.GetAllLopSh())
            {
                data.Add(new CBB_Items
                {
                    Value = item.ID,
                    Text = item.NameLop
                });
            }

            return data;
        }

        public SV GetSVByMSSV(string MSSV)
        {
            SV s = new SV();
            foreach (SV i in DAL_QLSV.Instance.GetALLSV())
            {
                if (i.MSSV == MSSV)
                {
                    s = i;
                }
            }
            return s;
        }

        public List<SV> GetSVByIDLop(int ID_LopSH)
        {
            List<SV> data = new List<SV>();

            if (ID_LopSH == 0)
            {
                data = DAL_QLSV.Instance.GetALLSV();
            }
            else
            {
                foreach (SV s in DAL_QLSV.Instance.GetALLSV())
                {
                    if (s.ID_Lop == ID_LopSH)
                    {
                        data.Add(s);
                    }
                }
            }

            return data;
        }
        public List<SV_View> GetSVViewByIDLop(int ID_Lop)
        {
            List<SV_View> data = new List<SV_View>();
            foreach( var i in GetSVByIDLop(ID_Lop))
            {
                string NameLop = "";
                foreach(var j in DAL_QLSV.Instance.GetAllLopSh())
                {
                    if (i.ID_Lop == j.ID)
                    {
                        NameLop = j.NameLop;
                    }
                }
                data.Add(new SV_View
                {
                    MSSV = i.MSSV,
                    LopSH = NameLop,
                    NameSV = i.NameSV,
                    DTB = i.DTB,
                });
            }
            return data;
        }
        public bool IsAlive(string MSSV)
        {
            foreach (SV i in DAL_QLSV.Instance.GetALLSV())
            {
                if (i.MSSV == MSSV)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddUpdateSV(SV s)
        {
            if (IsAlive(s.MSSV))
            {
                DAL_QLSV.Instance.Update(s);
            }
            else
            {
                DAL_QLSV.Instance.Add(s);
            }
        }
        public void DeleteSV(string MSSV)
        {
            DAL_QLSV.Instance.Delete(MSSV);
        }

        public delegate bool Mydel(Object o1, Object o2);

        public List<SV> Sort (string mySearch,Mydel m)
        {
            DataTable dt = new DataTable();
            List<SV> temp = new List<SV>(DAL_QLSV.Instance.GetALLSV());
            
            for (int i = 0; i < DAL_QLSV.Instance.GetALLSV().Count - 1; i++)
            {
                for (int j = i + 1; j < DAL_QLSV.Instance.GetALLSV().Count; j++)
                {
                    if (m(temp[i], temp[j]))
                    {
                        SV t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }
            return temp;
        }
        public List<SV> Search(string keyword,int ID_LopSH)
        {
            List<SV> data = new List<SV>();
            foreach (SV i in BLL_QLSV.Instance.GetSVByIDLop(ID_LopSH))
            {

                if (i.NameSV.Contains(keyword) || i.MSSV.Contains(keyword))
                {
                    data.Add(i);
                }

            }
            return data;
        }

    }
}
