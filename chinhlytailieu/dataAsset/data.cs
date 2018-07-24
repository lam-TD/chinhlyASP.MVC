using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace chinhlytailieu.dataAsset
{
    public class data
    {
        static SqlCommand command;
        static SqlDataAdapter da;
        public static bool inputdata(string namestored, string[] name_para = null, object[] value_para = null)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                string query = "";
                if (value_para != null)
                {
                    string mangbien = String.Join(", ", name_para);
                    query = "EXEC" + " " + namestored + " " + mangbien;
                    command = new SqlCommand(query, con);
                    for (int i = 0; i < value_para.Length; i++)
                    {
                        command.Parameters.AddWithValue(name_para[i], value_para[i]);
                    }
                }
                else { command = new SqlCommand(query, con); }

                if (command.ExecuteNonQuery() == 1) { result = true; }
                else { result = false; }
                con.Close();
            }
            return result;
        }

        public static string outputdata(string namestored, string[] name_para = null, object[] value_para = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                string query = "";
                if (value_para != null)
                {
                    string mangbien = String.Join(", ", name_para);
                    query = "EXEC" + " " + namestored + " " + mangbien;
                    command = new SqlCommand(query, con);
                    for (int i = 0; i < value_para.Length; i++)
                    {
                        command.Parameters.AddWithValue(name_para[i], value_para[i]);
                    }
                }
                else
                {
                    query = "EXEC" + " " + namestored;
                    command = new SqlCommand(query, con);
                }

                da = new SqlDataAdapter(command);
                da.Fill(dt);
                con.Close();
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);
            }
        }

        public static DataTable outputdataTable(string namestored, string[] name_para = null, object[] value_para = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                string query = "";
                if (value_para != null)
                {
                    string mangbien = String.Join(", ", name_para);
                    query = "EXEC" + " " + namestored + " " + mangbien;
                    command = new SqlCommand(query, con);
                    for (int i = 0; i < value_para.Length; i++)
                    {
                        command.Parameters.AddWithValue(name_para[i], value_para[i]);
                    }
                }
                else {
                    query = "EXEC" + " " + namestored;
                    command = new SqlCommand(query, con);
                }

                da = new SqlDataAdapter(command);

                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

        public static object execuScala(string namestored, string[] name_para = null, object[] value_para = null)
        {
            object result = new object();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                string query = "";
                if (value_para != null)
                {
                    string mangbien = String.Join(", ", name_para);
                    query = "EXEC" + " " + namestored + " " + mangbien;
                    command = new SqlCommand(query, con);
                    for (int i = 0; i < value_para.Length; i++)
                    {
                        command.Parameters.AddWithValue(name_para[i], value_para[i]);
                    }
                }
                else
                {
                    query = "EXEC" + " " + namestored;
                    command = new SqlCommand(query, con);
                }

                //da = new SqlDataAdapter(command);
                result = command.ExecuteScalar();
                con.Close();
            }
            return result;
        }

        public static bool login(string namestored, string[] name_para = null, object[] value_para = null)
        {
            DataTable dt = new DataTable();
            bool result = false;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                string query = "";

                if (value_para != null)
                {
                    string mangbien = String.Join(", ", name_para);
                    query = "EXEC" + " " + namestored + " " + mangbien;
                    command = new SqlCommand(query, con);
                    for (int i = 0; i < value_para.Length; i++)
                    {
                        command.Parameters.AddWithValue(name_para[i], value_para[i]);
                    }
                }
                else { command = new SqlCommand(query, con); }

                da = new SqlDataAdapter(command);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else { result = false; }
                con.Close();
            }
            return result;
        }

        public static string encryption(String password)
        {
            //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //byte[] encrypt;
            //UTF8Encoding encode = new UTF8Encoding();
            ////encrypt the given password string into Encrypted data  
            //encrypt = md5.ComputeHash(encode.GetBytes(password));
            //StringBuilder encryptdata = new StringBuilder();
            ////Create a new string by using the encrypted data  
            //for (int i = 0; i < encrypt.Length; i++)
            //{
            //    encryptdata.Append(encrypt[i].ToString());
            //}
            //return encryptdata.ToString();

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }

            return sbHash.ToString();
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}