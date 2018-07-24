using chinhlytailieu.Helper;
using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.cosodulieu
{
    public class cosodulieuController : Controller
    {
        // GET: cosodulieu
        [AllowAnonymous]
        public ActionResult index(int? id)
        {
            List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            
            return View(list);
        }

        [AllowAnonymous]
        public PartialViewResult chucnang(int id)
        {
            List<chucnang> cm = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
            ViewBag.Count = cm.Count();
            return PartialView("chucnang", cm);
        }

        [AllowAnonymous]
        public ActionResult phanheQLtailieubienmuc()
        {
            return View();
        }

        
        public ActionResult danhsachmucluc()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(),"danhsachmucluc"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
            //return View();
        }

        public ActionResult danhsachhoso()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "danhsachhoso"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        public ActionResult themhosomoi()
        {
            return View();
        }

        public ActionResult danhsachhop()
        {
            return View();
        }

        public ActionResult xephosovaohop()
        {
            return View();
        }

        public ActionResult congbohosorawebsite()
        {
            return View();
        }

        public ActionResult danhsachvanban()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(),"danhsachvanban"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
            //return View();
        }

        public ActionResult danhsachvanbanthem()
        {
            return View();
        }

        public ActionResult importhoso()
        {
            return View();
        }

        public ActionResult importvanban()
        {
            return View();
        }

        public ActionResult test()
        {
            return View();
        }

    }
}