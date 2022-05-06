using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Layer.DTO
{
    public class SV
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public int ID_Lop { get; set; }
        public bool Gender { get; set; }
        public double DTB { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool Anh {  get; set; }
        public bool HocBa { get; set; }
        public bool Cmnd { get; set; }
        public static bool CompareMSSV(Object o1, Object o2)
        {
            return (int.Parse((((SV)o1).MSSV)) > int.Parse((((SV)o2).MSSV)));
        }
        public static bool CompareName(Object o1, Object o2)
        {
            return ((SV)o1).NameSV.CompareTo(((SV)o2).NameSV) > 0;
        }
        public static bool CompareDTB(Object o1, Object o2)
        {
            return ((SV)o1).DTB > (((SV)o2).DTB);
        }
    }
}
