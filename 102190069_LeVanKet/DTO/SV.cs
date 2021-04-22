using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190069_LeVanKet.DTO
{
    class SV
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public int ID_Lop { get; set; }

        public static bool Compare_NameDecending(object o1, object o2)
        {
            return (string.Compare(((SV)o1).NameSV, ((SV)o2).NameSV) < 0) ? true : false;
        }
        public static bool Compare_NameAscending(object o1, object o2)
        {
            return (string.Compare(((SV)o1).NameSV, ((SV)o2).NameSV) > 0) ? true : false;
        }

        public static bool Compare_NSDecending(object o1, object o2)
        {
            return (((SV)o1).NS < ((SV)o2).NS) ? true : false;
        }
        public static bool Compare_NSAscending(object o1, object o2)
        {
            return (((SV)o1).NS > ((SV)o2).NS) ? true : false;
        }
    }
}
