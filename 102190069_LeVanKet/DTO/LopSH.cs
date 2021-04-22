using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190069_LeVanKet.DTO
{
    class LopSH
    {
        public int ID_Lop { get; set; }
        public string NameLop { get; set; }
        public override string ToString()
        {
            return NameLop;
        }
    }
}
