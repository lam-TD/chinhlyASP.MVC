using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.khaithactructuyen
{
    public class khaithactailieuController : Controller
    {
        // GET: khaithactailieu

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

        public ActionResult timkiemhoso()
        {
            return View();
        }

        public ActionResult timkiemvanban()
        {
            return View();
        }

        public ActionResult timkiemhosonangcao()
        {
            return View();
        }

        public ActionResult timkiemvanbannangcao()
        {
            return View();
        }

        public ActionResult taoyeucaukhaithac()
        {
            return View();
        }

        public ActionResult quanlyyeucau()
        {
            return View();
        }

        public ActionResult tailieuduocxemtructuyen()
        {
            return View();
        }

        public ActionResult lichsutimkiem()
        {
            return View();
        }
    }
}