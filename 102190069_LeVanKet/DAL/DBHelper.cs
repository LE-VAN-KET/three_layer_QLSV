using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190069_LeVanKet.DAL
{
    class DBHelper
    {
        private SqlConnection con;
        static string connectionString = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
        public static DBHelper _Instance;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper(connectionString);
                }
                return _Instance;
            }
            private set { }
        }
        public DBHelper(string connectionString)
        {
            this.con = new SqlConnection(connectionString);

        }

        /// <summary>
        /// query data
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetRecord(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        /// <summary>
        /// excuteUpdate
        /// </summary>
        /// <param name="query"></param>
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
