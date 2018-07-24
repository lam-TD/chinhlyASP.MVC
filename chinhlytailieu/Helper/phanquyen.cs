using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Helper
{
    public class phanquyen
    {
        public static bool checkUrlUser(string username,string link)
        {
            bool result = false;
            string links = "#!" + link;
            if (username == "admin"){ result = true; }
            else
            {
                try
                {
                    string[] namepara = { "@username", "@linkchucnang" };
                    object[] valuepara = { username, links };
                    DataTable dt = dataAsset.data.outputdataTable("checkUrlUser", namepara, valuepara);
                    if (dt.Rows.Count > 0)
                    {
                        result = true;
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

    }
}