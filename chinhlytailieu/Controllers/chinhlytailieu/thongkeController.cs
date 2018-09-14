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

        public JsonResult phanhe_load_thongke()
        {
            // thong ke ho so
            //string arrhoso = dataAsset.data.outputdata("phanhe_thuthaptl_thongke_hoso");
            DataTable dthoso = dataAsset.data.outputdataTable("phanhe_thuthaptl_thongke_hoso");
            string thongkehoso = dthoso.Rows[0]["TONGHOSO"].ToString();
            // thong ke vanban
            //string arrvanban = dataAsset.data.outputdata("phanhe_thuthaptl_thongke_vanban");
            DataTable dtvanban = dataAsset.data.outputdataTable("phanhe_thuthaptl_thongke_vanban");
            string thongkevanban = dtvanban.Rows[0]["TONGVANBAN"].ToString();

            DataTable dtmucluc = dataAsset.data.outputdataTable("thong_ke_all_luc_luc");
            string thongkemucluc = dtmucluc.Rows[0]["sum"].ToString();

            DataTable dthop = dataAsset.data.outputdataTable("thong_ke_all_hop");
            string thongkehop = dthop.Rows[0]["sum"].ToString();

            string[] thongke = { thongkehoso, thongkevanban, thongkemucluc, thongkehop };
            return Json(thongke, JsonRequestBehavior.AllowGet);
        }
        // GET: thongke
        public JsonResult thong_ke_all_theo_phong(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };

            DataTable dtml = dataAsset.data.outputdataTable("thong_ke_muc_luc_theo_phong", namepara, valuepara);
            string mucluc = dtml.Rows[0]["sum"].ToString();

            DataTable dths = dataAsset.data.outputdataTable("thong_ke_ho_so_theo_phong", namepara, valuepara);
            string hoso = dths.Rows[0]["sum"].ToString();

            DataTable dtvb = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_phong", namepara, valuepara);
            string vanban = dtvb.Rows[0]["sum"].ToString();

            DataTable dthop = dataAsset.data.outputdataTable("thong_ke_hop_theo_phong", namepara, valuepara);
            string hop = dthop.Rows[0]["sum"].ToString();

            string[] thongke = { mucluc, hoso, vanban, hop };

            return Json(thongke, JsonRequestBehavior.AllowGet);
        }
        
        public string thong_ke_van_ban_theo_phong(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            DataTable dt = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_phong", namepara, valuepara);
            return dt.Rows[0]["sum"].ToString();
        }

        public JsonResult thong_ke_all_theo_phong_muc_luc(int phongid, int muclucid)
        {
            string[] namepara = { "@PHONGID", "@MUCLUCID" };
            object[] valuepara = { phongid, muclucid };

            DataTable dthop = dataAsset.data.outputdataTable("thong_ke_hop_theo_muc_luc_phong", namepara, valuepara);
            string hop = dthop.Rows[0]["sum"].ToString();

            DataTable dthoso = dataAsset.data.outputdataTable("thong_ke_ho_so_theo_phong_muc_luc", namepara, valuepara);
            string hoso = dthoso.Rows[0]["sum"].ToString();

            DataTable dtvanban = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_phong_muc_luc", namepara, valuepara);
            string vanban = dtvanban.Rows[0]["sum"].ToString();

            string[] thongke = { hop, hoso, vanban };
            return Json(thongke, JsonRequestBehavior.AllowGet);
        }

        public JsonResult thong_ke_all_theo_phong_muc_luc_hop(int phongid, int muclucid, string mahop)
        {
            string[] namepara = { "@PHONGID", "@MUCLUCID", "@MAHOP" };
            object[] valuepara = { phongid, muclucid, mahop };

            DataTable dthoso = dataAsset.data.outputdataTable("thong_ke_ho_so_theo_hop_muc_luc_phong", namepara, valuepara);
            string hoso = dthoso.Rows[0]["sum"].ToString();

            DataTable dtvanban = dataAsset.data.outputdataTable("thong_ke_van_ban_theo_hop_muc_luc_phong", namepara, valuepara);
            string vanban = dtvanban.Rows[0]["sum"].ToString();

            string[] thongke = { hoso, vanban };
            return Json(thongke, JsonRequestBehavior.AllowGet);
        }

        public string hoso_loadtheoMucLuc(int muclucid)
        {
            string[] namepara = { "@MUCLUCID" };
            object[] valuepara = { muclucid };
            return dataAsset.data.outputdata("hoso_loadtheoMucLuc", namepara, valuepara);
        }
    }
}