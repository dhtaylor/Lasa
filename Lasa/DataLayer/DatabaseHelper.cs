using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lasa.DataLayer
{
    public class DatabaseHelper
    {
        static string connstr = ConfigurationManager.ConnectionStrings["Lasa"].ConnectionString;

        public static object GetScalar(string sql, List<SqlParameter> pList)
        {
            object obj = null;

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (pList != null)
                    {
                        foreach (SqlParameter p in pList)
                            cmd.Parameters.Add(p);
                    }

                    obj = cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return obj;
        }

        public static DataTable GetDataSet(string sql, List<SqlParameter> pList)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (pList != null)
                    {
                        foreach (SqlParameter p in pList)
                            cmd.Parameters.Add(p);
                    }

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return dt;
        }

        public static int ModifyData(string sql, List<SqlParameter> pList)
        {
            int rowsModified = 0;

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (pList != null)
                    {
                        foreach (SqlParameter p in pList)
                            cmd.Parameters.Add(p);
                    }

                    rowsModified = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return rowsModified;

        }
    }
}