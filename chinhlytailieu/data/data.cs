using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace chinhlytailieu.data
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

        public static string encryption(String str)  
        {
            //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //byte[] encrypt;
            //UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data
            //encrypt = md5.ComputeHash(encode.GetBytes(password));
            //StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data
            //for (int i = 0; i < encrypt.Length; i++)
            //{
            //    encryptdata.Append(encrypt[i].ToString());
            //}
            //return encryptdata.ToString();

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString());
            }

            return strBuilder.ToString();
        }  
    }
}