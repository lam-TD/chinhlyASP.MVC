using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.baoquan
{
    public class baoquanController : Controller
    {
        // GET: baoquan
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

        public ActionResult phanheQLkhovabaoquan()
        {
            return View();
        }

        //quanlykho
        public ActionResult quanlykho()
        {
            return View();
        }

        public ActionResult quanlyphongkho()
        {
            return View();
        }

        public ActionResult quanlygiake()
        {
            return View();
        }

        public ActionResult quanlynganke()
        {
            return View();
        }

        //quanlyvitri
        public ActionResult xephoplenke()
        {
            return View();
        }

        public ActionResult chuyenkhoke()
        {
            return View();
        }

        public ActionResult tracuutailieu()
        {
            return View();
        }

        //quanlynhapxuat
        public ActionResult xuathosochinhly()
        {
            return View();
        }

        public ActionResult nhanhosochinhly()
        {
            return View();
        }

        public ActionResult nhanhosothuthap()
        {
            return View();
        }

        public ActionResult xuathosochophongdoc()
        {
            return View();
        }

        public ActionResult nhanhosotuphongdoc()
        {
            return View();
        }

        //baocaothongke
        public ActionResult danhsachphong()
        {
            return View();
        }

        public ActionResult sodangkymucluchoso()
        {
            return View();
        }

        public ActionResult inmucluchoso()
        {
            return View();
        }

        public ActionResult inmuclucvanban()
        {
            return View();
        }

        public ActionResult sonhaphoso()
        {
            return View();
        }

        public ActionResult soxuathoso()
        {
            return View();
        }


        //quanlytailieu
        public ActionResult hoidongthamdinh()
        {
            return View();
        }

        public ActionResult lapphieutieuhuy()
        {
            return View();
        }

        public ActionResult lapphieutieuhuythem()
        {
            return View();
        }

        public ActionResult lapphieutieuhuyxem()
        {
            return View();
        }
        public ActionResult pheduyettieuhuy()
        {
            return View();
        }

        public ActionResult pheduyettieuhuyxem()
        {
            return View();
        }
    }
}