using _102190069_LeVanKet.DAL;
using _102190069_LeVanKet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190069_LeVanKet.BLL
{
    class BLL_QLSV
    {
        public delegate bool DelSort(object a, object b);
        private static BLL_QLSV _Instance;
        public static BLL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set { }
        }
        public List<SV> GetListSV(int ID_Lop, string textSeach)
        {
            List<SV> data = new List<SV>();
            List<SV> listSV;
            if (ID_Lop == 0)
            {
                if ("".Equals(textSeach))
                {
                    return DAL_QLSV.Instance.GetAllSV();
                }
                else
                {
                    listSV = DAL_QLSV.Instance.GetAllSV();
                }
            }
            else
            {
                listSV = DAL_QLSV.Instance.GetListSVByID_Lop(ID_Lop);
            }

            foreach (SV i in listSV)
            {
                if (i.NameSV.ToLower().Contains(textSeach.ToLower()))
                {
                    data.Add(i);
                }
            }
            return data;
        }
        public List<LopSH> GetAllLopSH()
        {
            return DAL_QLSV.Instance.GetAllLopSH();
        }
        public bool IsTrue(string mssv)
        {
            List<SV> list = DAL_QLSV.Instance.GetAllSV();
            foreach (SV s in list)
            {
                if (s.MSSV == mssv)
                {
                    return true;
                }
            }
            return false;
        }
        public void ExecuteDB(SV sv)
        {
            if (!IsTrue(sv.MSSV))
            {
                DAL_QLSV.Instance.AddSV(sv);
            }
            else
            {
                DAL_QLSV.Instance.EditSV(sv);
            }
        }
        public SV GetSVByMSSV(string mssv)
        {
            List<SV> list = DAL_QLSV.Instance.GetAllSV();
            foreach (SV s in list)
            {
                if (s.MSSV == mssv)
                {
                    return s;
                }
            }
            return null;
        }
        public LopSH GetLSHByID_Lop(int id_Lop)
        {
            List<LopSH> list = DAL_QLSV.Instance.GetAllLopSH();
            foreach (LopSH lsh in list)
            {
                if (lsh.ID_Lop == id_Lop)
                {
                    return lsh;
                }
            }
            return null;
        }
        public void DeleteSV(string mssv)
        {
            if (IsTrue(mssv))
            {
                DAL_QLSV.Instance.DeleteSV(mssv);
            }
        }
        public List<SVView> Sort(int ID_Lop, DelSort cmp)
        {
            List<SV> data = GetListSV(ID_Lop, "");
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (cmp(data[i], data[j]))
                    {
                        SV temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
            List<SVView> listSVView = GetListSVView(data);
            return listSVView;
        }

        public List<SVView> GetListSVView(List<SV> svs)
        {
            List<SVView> list = new List<SVView>();
            foreach(SV sv in svs)
            {
                list.Add(new SVView
                {
                    MSSV = sv.MSSV,
                    NameSV = sv.NameSV,
                    Gender = sv.Gender,
                    NS = sv.NS,
                    NameLop = GetLSHByID_Lop(sv.ID_Lop).NameLop
                });
            }
            return list;
        }
    }
}
