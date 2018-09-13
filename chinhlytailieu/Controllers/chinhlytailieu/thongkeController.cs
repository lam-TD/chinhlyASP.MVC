using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.chinhlytailieu
{
    public class thongkeController : Controller
    {
        // GET: thongke
        public string thong_ke_muc_luc_theo_phong(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_muc_luc_theo_phong", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public string thong_ke_ho_so_theo_phong(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_ho_so_theo_phong", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public string thong_ke_van_ban_theo_phong(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_phong", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public string thong_ke_ho_so_theo_phong_muc_luc(int phongid, int muclucid)
        {
            string[] namepara = { "@PHONGID", "@MUCLUCID" };
            object[] valuepara = { phongid, muclucid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_ho_so_theo_phong_muc_luc", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public string thong_ke_van_ban_theo_phong_muc_luc(int phongid, int muclucid)
        {
            string[] namepara = { "@PHONGID", "@MUCLUCID" };
            object[] valuepara = { phongid, muclucid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_phong_muc_luc", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public string hoso_loadtheoMucLuc(int muclucid)
        {
            string[] namepara = { "@MUCLUCID" };
            object[] valuepara = { muclucid };
            return dataAsset.data.outputdata("hoso_loadtheoMucLuc", namepara, valuepara);
        }
    }
}