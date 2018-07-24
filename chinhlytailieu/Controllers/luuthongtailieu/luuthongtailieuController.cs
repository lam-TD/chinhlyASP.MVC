using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.luuthongtailieu
{
    public class luuthongtailieuController : Controller
    {
        // GET: luuthongtailieu
        public ActionResult index(int? id)
        {
            List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            return View(list);
        }

        public PartialViewResult chucnang(int id)
        {
            List<chucnang> cm = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
            ViewBag.Count = cm.Count();
            return PartialView("chucnang", cm);
        }

        public ActionResult phanheluuthongtailieu()
        {
            return View();
        }

        public ActionResult danhsachyeucau()
        {
            return View();
        }

        public ActionResult duyetyeucaudangkySDTL()
        {
            return View();
        }

        public ActionResult quanlytaikhoandocgia()
        {
            return View();
        }

        public ActionResult quanlyyeucaudanhsachyeucau()
        {
            return View();
        }

        public ActionResult duyetYCcungcaptainguyen()
        {
            return View();
        }

        public ActionResult cungcapbansao()
        {
            return View();
        }

        public ActionResult giaobansaochodocgia()
        {
            return View();
        }

        public ActionResult ghimuontailieu()
        {
            return View();
        }

        public ActionResult ghitratailieu()
        {
            return View();
        }

        public ActionResult sochungthuc()
        {
            return View();
        }

        public ActionResult sodangkysaochup()
        {
            return View();
        }

        public ActionResult sobangiaotailieuvoidocgia()
        {
            return View();
        }

        public ActionResult sodangkyyeucaudoc()
        {
            return View();
        }

        public ActionResult sodangkydocgia()
        {
            return View();
        }
    }
}