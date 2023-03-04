using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace project
{
    public class ConnectionClass
    {
        SqlConnection con;
        SqlCommand cmd;
        public ConnectionClass()
        {
            con = new SqlConnection(@"server=LAPTOP-GTTMJ43E\SQLEXPRESS;database=project;Integrated security=true");
        }
        public int Fun_exenonquery(String sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public String Fun_exescalar(String sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            String s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;

        }
        public SqlDataReader Fun_exeReader(String sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public DataSet Fun_exeAdapter(String sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;


        }
    }
}
    
