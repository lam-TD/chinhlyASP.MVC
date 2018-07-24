using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace chinhlytailieu.dataAsset
{
    public class loadallchucnang
    {
        
        public static List<module> module(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { username };
            List<module> list = new List<module>();
            DataTable dt = dataAsset.data.outputdataTable("user_module", namepara, valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new module
                {
                    Id = int.Parse(dt.Rows[i]["Id_Module"].ToString()),
                    Modulename = dt.Rows[i]["ModuleName"].ToString(),
                    Imagepath = dt.Rows[i]["Image_Module"].ToString(),
                    Numoder = int.Parse(dt.Rows[i]["NumOrder_Module"].ToString()),
                    Links = dt.Rows[i]["Links_Module"].ToString()
                });
            }
            return list;
        }

        public static List<nhomchucnang> nhomchucnang(string username, object idmodule)
        { //load nhom chuc nang theo id module
            DataTable dt = new DataTable();
            if (username == "admin")
            {
                string[] namepara = { "@idmodule" };
                object[] valuepara = { idmodule };
                dt = dataAsset.data.outputdataTable("user_nhomchucnang_all",namepara,valuepara);
            }
            else
            {
                string[] namepara = { "@username", "@idmodule" };
                object[] valuepara = { username, idmodule };
                dt = dataAsset.data.outputdataTable("user_nhomchucnang", namepara, valuepara);
            }

            List<nhomchucnang> list = new List<nhomchucnang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nhomchucnang m = new nhomchucnang();
                m.Id = int.Parse(dt.Rows[i]["Id_Nhomcn"].ToString());
                m.Tennhom = dt.Rows[i]["Ten_Nhomcn"].ToString();
                m.Icon = dt.Rows[i]["Icon"].ToString();
                if (dt.Rows[i]["THUTU"].ToString() == ""){ m.Thutu = 1; }
                else{ m.Thutu = int.Parse(dt.Rows[i]["THUTU"].ToString()); }
                list.Add(m);
            }
            return list;
        }

        public static List<chucnang> Loadchucnang(string username, int idnhomchucnang)
        { //load chuc nang theo id nhom chuc nang
            DataTable dt = new DataTable();
            if (username == "admin")
            {
                string[] namepara = { "@idnhomchucnang" };
                object[] valuepara = { idnhomchucnang };
                dt = dataAsset.data.outputdataTable("user_chucnang_all",namepara,valuepara);
            }
            else
            {
                string[] namepara = { "@username", "@idnhomchucnang" };
                object[] valuepara = { username, idnhomchucnang };
                dt = dataAsset.data.outputdataTable("user_chucnang", namepara, valuepara);
            }

            List<chucnang> list = new List<chucnang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chucnang cm = new chucnang();
                cm.Id = int.Parse(dt.Rows[i]["Id_ChucNang"].ToString());
                cm.Links = dt.Rows[i]["Links_ChuNang"].ToString();
                cm.Thutu = int.Parse(dt.Rows[i]["ThuTu_ChucNang"].ToString());
                cm.Tenchucnang = dt.Rows[i]["TENCHUCNANG"].ToString();
                list.Add(cm);
            }
            return list;
        }

        
    }
}