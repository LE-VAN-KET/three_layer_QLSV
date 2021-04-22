using _102190069_LeVanKet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190069_LeVanKet.DAL
{
    class DAL_QLSV
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
            private set { }
        }

        private List<SV> QueryListSV(string query)
        {
            List<SV> students = new List<SV>();
            DataTable dt = DBHelper.Instance.GetRecord(query);
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new SV()
                {
                    MSSV = dr["MSSV"].ToString(),
                    NameSV = dr["NameSV"].ToString(),
                    Gender = (bool)dr["Gender"],
                    NS = (DateTime)dr["NS"],
                    ID_Lop = (int)dr["ID_Lop"]
                });
            }
            return students;
        }

        public List<SV> GetAllSV()
        {
            string query = "select * from SV";
            return QueryListSV(query);
        }

        public List<LopSH>  GetAllLopSH()
        {
            List<LopSH> listLSH = new List<LopSH>();
            string query = "select * from LopSH";
            DataTable dt = DBHelper.Instance.GetRecord(query);
            foreach (DataRow dr in dt.Rows)
            {
                listLSH.Add(new LopSH()
                {
                    ID_Lop = (int)dr["ID_Lop"],
                    NameLop = dr["NameLop"].ToString()
                });
            }
            return listLSH;
        }

        public List<SV> GetListSVByID_Lop(int ID_Lop)
        {
            string query = $"select * from SV where ID_Lop = {ID_Lop}";
            return QueryListSV(query);
        }

        public void AddSV(SV sv)
        {
            string query = $"Insert into SV(MSSV, NameSV, NS, Gender, ID_Lop)" +
                $"Values ('{sv.MSSV}','{sv.NameSV}','{sv.NS.ToString("yyyy-MM-dd")}', '{sv.Gender}','{sv.ID_Lop}')";
            DBHelper.Instance.ExcuteDB(query);
        }

        public void EditSV(SV sv)
        {
            string query = $"UPDATE SV SET NameSV = '{sv.NameSV}', Gender = '{sv.Gender}'," +
                $"NS = '{sv.NS.ToString("yyyy-MM-dd")}', ID_Lop = '{sv.ID_Lop}' WHERE MSSV = '{sv.MSSV}'";
            DBHelper.Instance.ExcuteDB(query);
        }

        public void DeleteSV(string mssv)
        {
            string query = $"delete from SV where MSSV = '{mssv}'";
            DBHelper.Instance.ExcuteDB(query);
        }
    }
}
