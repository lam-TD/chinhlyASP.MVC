using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.danhmuc
{
    public class danhmucController : Controller
    {
        // GET: danhmuc
        public ActionResult Index(int? id)
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

        //danhmuctailieu
        public ActionResult coquanluutru()
        {
            return View();
        }

        public ActionResult phongtailieu()
        {
            return View();
        }

        public ActionResult loaihinhtailieu()
        {
            return View();
        }

        //danhmucdinhsan
        public ActionResult tudien()
        {
            return View();
        }

        public ActionResult thoihanbaoquan()
        {
            return View();
        }
    }
}