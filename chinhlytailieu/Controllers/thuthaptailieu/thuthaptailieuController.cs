using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.thuthaptailieu
{
    public class thuthaptailieuController : Controller
    {
        // GET: thuthaptailieu
        [HttpGet]
        public ActionResult index(int? id)
        {

            List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            return View(list);
        }

        public PartialViewResult chucnang(int id)
        {
            List<chucnang> list = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
            ViewBag.Count = list.Count();
            return PartialView("chucnang",list);
        }

        public ActionResult phanheQLthuthaptailieu()
        {
            return View();
        }

        public ActionResult thuthaptailieu()
        {
            return View();
        }

        public ActionResult lapmucnopluu()
        {
            return View();
        }

        public ActionResult qllannopluu()
        {
            return View();
        }

        public ActionResult xuatmucnopluu()
        {
            return View();
        }

        public ActionResult nopluutructuyen()
        {
            return View();
        }

        public ActionResult nguonnopluu()
        {
            return View();
        }

        public ActionResult hoidongthamdinh()
        {
            return View();
        }

        public ActionResult hosonopluu()
        {
            return View();
        }

        public ActionResult hosoluuthem()
        {
            return View();
        }

        public ActionResult thamdinhhoso()
        {
            return View();
        }

        public ActionResult kiemtrahosothucte()
        {
            return View();
        }


        public ActionResult hieuchinhsuamucluchoso()
        {
            return View();
        }

        public ActionResult giaotailieuvaokho()
        {
            return View();
        }

        public ActionResult bienbannhanTLtunguonnopluu()
        {
            return View();
        }



        public ActionResult menu(int idmodule)
        {
            string[] namepara = { "@username", "@idmodule" };
            object[] valuepara = { Session["username"].ToString(), idmodule };
            DataTable dt = dataAsset.data.outputdataTable("user_nhomchucnang", namepara, valuepara);
            List<nhomchucnang> list = new List<nhomchucnang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new nhomchucnang
                {
                    Id = int.Parse(dt.Rows[i]["Id_Nhomcn"].ToString()),
                    Tennhom = dt.Rows[i]["Ten_Nhomcn"].ToString(),
                    Icon = dt.Rows[i]["Icon"].ToString(),
                    Thutu = int.Parse(dt.Rows[i]["THUTU"].ToString())
                });
            }
            return View(list);
        }

    }
}