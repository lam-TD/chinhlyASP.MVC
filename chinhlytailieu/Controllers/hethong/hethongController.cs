using chinhlytailieu.Helper;
using chinhlytailieu.Models.admin;
using chinhlytailieu.Models.pro;
using chinhlytailieu.Models.users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.hethong
{
    public class hethongController : Controller
    {
        // GET: hethong
        public ActionResult Index(int? id)
        {
            //List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            //return View(list);
            if (Session["username"].ToString() != null)
            {
                List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
                return View(list);
            }
            else
            {
                Response.Redirect("../dangnhap/login");
                return View("chucnang");
            }
        }

        public PartialViewResult chucnang(int id)
        {
            if (Session["username"].ToString() != null)
            {
                List<chucnang> cm = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
                ViewBag.Count = cm.Count();
                return PartialView("chucnang", cm);
            }
            else
            {
                Response.Redirect("../dangnhap/login");
                return PartialView("chucnang");
            }
            
        }

        //quanlynguoidung
        public ActionResult quanlyphongban()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(),"quanlyphongban"))
            {
                List<coquan> cq = ht_qlphongban_LoadCoQuan();
                return View(cq);
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
            
        }

        public PartialViewResult phongcon(string id)
        {
            List<coquan> cq = ht_quanlyphong_loadcoquancon(id);
            ViewBag.Count = cq.Count();
            return PartialView("phongcon", cq);
        }

        public ActionResult quanlychucvu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlychucvu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlynguoidung()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlynguoidung"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlynhom()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlynhom"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //phanquyen
        public ActionResult phanquyentruycaptailieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyentruycaptailieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult phanquyenchucnang()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyenchucnang"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //thietlapquytrinh
        public ActionResult quanlyquytrinh()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlyquytrinh"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlyloaihinhkhaithac()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlyloaihinhkhaithac"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult phanquyenxulyquytrinh()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyenxulyquytrinh"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //cauhinhhethong
        public ActionResult cauhinhdangnhap()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhdangnhap"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult cauhinhkhac()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhkhac"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult cauhinhvitriluutru()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhvitriluutru"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        public ActionResult backupcosodulieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "backupcosodulieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //nhatky
        public ActionResult nhatkyhethong()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkyhethong"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult nhatkythaydoitailieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkythaydoitailieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult nhatkydocgia()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkydocgia"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }


//============ QUAN LY NGUOI DUNG ===========

        //====== QUAN LY PHONG BAN ======
        public List<coquan> ht_qlphongban_LoadCoQuan()
        {
            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CQQUANLY"].ToString() == "")
                {
                    coquan cquan = new coquan();
                    cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                    cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                    cq.Add(cquan);
                }
            }
            return cq;
        }

        public List<coquan> ht_quanlyphong_loadcoquancon(string cqquanly)
        {
            string[] namepara = { "@cqquanly" };
            object[] valuepara = { cqquanly };

            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_quanlyphong_loadcoquancon", namepara, valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                coquan cquan = new coquan();
                cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                cq.Add(cquan);
            }
            return cq;
        }

        public JsonResult ht_qlphongban_LoadCoQuanJson()
        {
            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CQQUANLY"].ToString() == "")
                {
                    coquan cquan = new coquan();
                    cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                    cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                    cq.Add(cquan);
                }
            }
            return Json(cq, JsonRequestBehavior.AllowGet);
        }

        public string ht_quanlyphong_loadBoPhanTheoCoQuan(string madonvi)
        {
            string[] namepara = { "@madonvi" };
            object[] valuepara = { madonvi };
            return dataAsset.data.outputdata("ht_quanlyphong_loadBoPhanTheoCoQuan", namepara, valuepara);
        }

        public JsonResult ht_qlphongban_them_sua(int type,bophan phong)
        {
            string[] namepara = { "@maphong", "@tenphong", "@dvquanly", "@madonvi" };
            if (phong.Dvquanly == null) { phong.Dvquanly = ""; }
            object[] valuepara = { phong.Maphong, phong.Tenphong, phong.Dvquanly, phong.Madonvi };
            
            string result = string.Empty;

            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlphongban_them", namepara, valuepara)) { result = "1"; } else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlphongban_sua", namepara, valuepara)) { result = "1"; } else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //====== QUAN LY CHUC VU ======
        public string DanhSachChucVu()
        {
            string result =  dataAsset.data.outputdata("ht_qlchucvu_load");
            return result;
        }

        [HttpPost]
        public JsonResult quanlychucvuThemSua(int type,chucvu cv)
        {
            string[] namepara = { "@machucvu", "@tenchucvu" };
            object[] valuepara = { cv.Machucvu, cv.Tenchucvu };
            string result = string.Empty;

            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlchucvu_them", namepara, valuepara)){ result = "1"; } else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlchucvu_sua", namepara, valuepara)){ result = "1"; } else { result = "-1"; }
                    break;
            } 
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int quanlychucvuXoa(string machucvu)
        {
            if (ht_qlchucvu_checknguoidung(machucvu.Trim()) == 1)
            {
                // xoa
                string[] namepara = { "@MACHUCVU" };
                object[] valuepara = { machucvu.Trim() };
                if (dataAsset.data.inputdata("ht_qlchucvu_Xoa", namepara, valuepara))
                {
                    return 1;
                }
                else { return -1; }
            }
            else
            {
                return 0;
            }
        }

        public int ht_qlchucvu_checknguoidung(string machucvu)
        {
            string[] namepara = { "@MACHUCVU" };
            object[] valuepara = { machucvu };
            DataTable dt = dataAsset.data.outputdataTable("ht_qlchucvu_checknguoidung",namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                return -1;
            }
            else { return 1; }
        }



        //====== QUAN LY NGUOI DUNG ======
        public string ht_qlnguoidung_qlnguoidung_load()
        {
            return dataAsset.data.outputdata("ht_qlnguoidung_qlnguoidung_load");
        }

        public string users_coquan_load()
        {
            return dataAsset.data.outputdata("users_coquan_load");
        }

        
        public string coquanLam(string id)
        {
            string[] namepara = { "@macoquan" };
            object[] valuepara = { id };
            return dataAsset.data.outputdata("users_bophan_idcoquan",namepara,valuepara);
        }

        public string LoadNguoiDungTheoBoPhan(string id)
        {
            string[] namepara = { "@mabophan" };
            object[] valuepara = { id };
            return dataAsset.data.outputdata("ht_quanlynguoidung_loadNguoiDungTheoBoPhan", namepara, valuepara);
        }

        //them nguoi dung moi
        public JsonResult themsuanguoidung(int type,nguoidung n)
        {
            string[] namepara = { "@ID", "@USERNAME","@PASSWORD", "@EMAIL", "@HOLOT", "@TEN", "@NGAYTAO", "@KHOA", "@CHUCVU", "@BOPHAN", "@UYQUYEN", "@NGAYUQ", "@KETTHUCUQ", "@HANCHE", "@FILEANH" };
            string ngaytao = DateTime.Now.ToShortDateString();
            bool khoa = true;
            string id = dataAsset.data.RandomString(10, true);
            string pass = dataAsset.data.encryption(n.Password);
            if (n.Khoa == null){ khoa = false; } else { khoa = n.Khoa; }
            if (n.Hanche == null) { khoa = false; } else { khoa = n.Hanche; }
            object[] valuepara = { id, n.Username, pass, n.Email, n.Holot, n.Ten, ngaytao, khoa, n.Chucvu, n.Bophan, "", "", "", n.Hanche, "" };
            string result = string.Empty;
            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_quanlynguoidung_Them", namepara, valuepara)) { result = "1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_quanlynguoidung_Sua", namepara, valuepara)) { result = "1"; }
                    break;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult checkUsername(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { username };
            DataTable dt = dataAsset.data.outputdataTable("checkUsername", namepara, valuepara);
            string result = string.Empty;
            if (dt.Rows.Count > 0)
            {
                result = "1";
            }
            else { result = "-1"; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ht_quanlynguoidung_DoiMK(string username, string pass)
        {
            string mk = dataAsset.data.encryption(pass);
            string[] namepara = { "@username", "@password" };
            object[] valuepara = { username, mk };
            if (dataAsset.data.inputdata("ht_quanlynguoidung_DoiMK", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("1", JsonRequestBehavior.AllowGet); }
        }

        public JsonResult ht_quanlynguoidung_Khoa(string username, int khoa)
        {
            string[] namepara = { "@username", "@khoa" };
            object[] valuepara = { username, khoa };
            if (dataAsset.data.inputdata("ht_quanlynguoidung_Khoa", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("1", JsonRequestBehavior.AllowGet); }
        }


        //====== QUAN LY NHOM NGUOI DUNG ======
        public string ht_qlnhomnguoidung_Load()
        {
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_Load");
        }

        public string ht_qlnhomnguoidung_LoadDSTaikhoan(string manhom)
        {
            string[] namepara = { "@manhom" };
            object[] valuepara = { manhom };
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_LoadDSTaikhoan", namepara, valuepara);
        }

        public JsonResult ht_qlnhomnguoidung_ThemSua(int type, nhom n)
        {
            string[] namepara = { "@MANHOM", "@TENNHOM" };
            object[] valuepara = { n.Manhom, n.Tennhom };
            string result = string.Empty;
            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Them", namepara, valuepara)) { result = "1"; }
                    else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Sua", namepara, valuepara)) { result = "1"; }
                    else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //check ma nhom ton tai
        public JsonResult ht_qlnhomnguoidung_CheckMaNhom(string manhom)
        {
            string[] namepara = { "@manhom" };
            object[] valuepara = { manhom };
            DataTable dt = dataAsset.data.outputdataTable("ht_qlnhomnguoidung_CheckMaNhom", namepara, valuepara);
            if (dt.Rows.Count > 0) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("-1", JsonRequestBehavior.AllowGet); }
        }

        public JsonResult ht_qlnhomnguoidung_themnguoidungvaonhom(string[] username, string manhom)
        {
            // check nguoi dung co thuoc nhom hay chua
            string result = "1";
            for (int i = 0; i < username.Length; i++)
            {
                string[] namepara = { "@username", "@manhom" };
                object[] valuepara = { username[i], manhom };
                DataTable dt = dataAsset.data.outputdataTable("ht_qlnhomnguoidung_Checknguoidungthuocnhom", namepara, valuepara);
                if (dt.Rows.Count == 0)
                {
                    string[] namepara2 = { "@manhom", "@username" };
                    object[] valuepara2 = { manhom, username[i] };
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_themnguoidungvaonhom", namepara2, valuepara2))
                        result = "1"; // them thanh cong
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string ht_qlnhomnguoidung_loadnguoidung_bophan_thuocnhomnguoidung(string maphong, string manhom)
        {
            string[] namepara = { "@maphong", "@manhom" };
            object[] valuepara = { maphong, manhom };
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_loadnguoidung_bophan_thuocnhomnguoidung", namepara, valuepara);
        }

    
        public JsonResult ht_qlnhomnguoidung_Loaibo(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { username };
            if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Loaibo", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("-1", JsonRequestBehavior.AllowGet); }
        }

        // ====== PHAN QUYEN ======

        // PHAN QUYEN TRUY CAP TAI LIEU
        public string ht_phanquyentruycap_loadquyentheonhom(string manhom)
        {
            string[] namepara = { "@MANHOM" };
            object[] valuepara = { manhom };
            return dataAsset.data.outputdata("ht_phanquyentruycap_loadquyentheonhom", namepara, valuepara);
        }


        // PHAN QUYEN CHUC NANG
        public string ht_phanquyen_loadPhanHe()
        {
            return dataAsset.data.outputdata("allModule");
        }

        public JsonResult ht_phanquyen_loadChucNang(string moduleID, int type, string manhom = null)
        {
            // type check 1-load het du lieu, 2-load, kiem tra nhom co quyen hay chua 
            List<chucnang> cn = new List<chucnang>();
            string[] namepara = { "@moduleid" };
            object[] valuepara = { moduleID };
            DataTable dt = dataAsset.data.outputdataTable("ht_phanquyen_loadNhomChucNang", namepara, valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int idnhom = int.Parse(dt.Rows[i]["ID"].ToString());
                DataTable dtcn = new DataTable();
                if (type == 1)
                {
                    string[] namepara2 = { "@idnhom"};
                    object[] valuepara2 = { idnhom };
                    dtcn = dataAsset.data.outputdataTable("ht_phanquyen_loadChucNangAll", namepara2, valuepara2);
                    
                }
                else
                {
                    string[] namepara2 = { "@idnhom", "@manhom" };
                    object[] valuepara2 = { idnhom, manhom };
                    dtcn = dataAsset.data.outputdataTable("ht_phanquyen_loadChucNang", namepara2, valuepara2);
                }

                for (int j = 0; j < dtcn.Rows.Count; j++)
                {
                    chucnang c = new chucnang();
                    c.Id = int.Parse(dtcn.Rows[j]["ID"].ToString());
                    c.Tenchucnang = dtcn.Rows[j]["TENCHUCNANG"].ToString();
                    cn.Add(c);
                }

            }
            return Json(cn, JsonRequestBehavior.AllowGet);
        }

        //ghi nhan chuc nang duoc cho phep
        public bool ht_phanquyen_checkChucNang(string manhom, int idchucnang)
        {
            string[] namepara = { "@manhom", "@chucnangid" };
            object[] valuepara = { manhom, idchucnang };
            DataTable dt = dataAsset.data.outputdataTable("ht_phanquyen_checkChucNang", namepara, valuepara);
            if (dt.Rows.Count > 0){ return true; }
            else { return false; }
        }

        public bool ht_phanquyen_XoaChucNang(string manhom, int idchucnang)
        {
            string[] namepara = { "@MANHOM", "@CHUCNANGID" };
            object[] valuepara = { manhom, idchucnang };
            if (dataAsset.data.inputdata("ht_phanquyen_XoaChucNang", namepara, valuepara)) { return true; }
            else { return false; }
        }
        public JsonResult ht_phanquyen_GhiNhanChucNang(nhom_chucnang[] nhomcn, string manhom)
        {
            
            string result = null;
            try
            {
                foreach (nhom_chucnang cn in nhomcn)
                {
                    if (ht_phanquyen_checkChucNang(manhom, cn.Chucnangid))
                    {
                        if (cn.Allaction == false)
                        {
                            if (!ht_phanquyen_XoaChucNang(manhom, cn.Chucnangid)){ result = "-1"; break; }
                        }
                        //else
                        //{
                        //    string[] namepara = { "@MANHOM", "@CHUCNANGID", "@ALLACTION" };
                        //    object[] valuepara = { manhom, cn.Chucnangid, cn.Allaction };
                        //    if (!dataAsset.data.inputdata("ht_phanquyen_GhiNhanChucNangUpdate", namepara, valuepara))
                        //    {
                        //        result = "-1";
                        //        break;
                        //    }
                        //}

                    }
                    else
                    {
                        if (cn.Allaction == true)
                        {
                            string[] namepara = { "@MANHOM", "@CHUCNANGID", "@ALLACTION", "@XEM", "@THEM", "@XOA", "@SUA" };
                            object[] valuepara = { manhom, cn.Chucnangid, cn.Allaction, 0, 0, 0, 0 };
                            if (!dataAsset.data.inputdata("ht_phanquyen_GhiNhanChucNang", namepara, valuepara))
                            {
                                result = "-1";
                                break;
                            }
                        }
                    }
                }
                result = "1";
            }
            catch{result = "-1";}
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string ht_qlphongban_LoadCoQuan2()
        {
            
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            string result = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CQQUANLY"].ToString() == "")
                {
                    result += "<option class='click_cq' ng-click='click_coquan()' " + " value='" + dt.Rows[i]["MACOQUAN"].ToString() + "'" + ">" + dt.Rows[i]["TENCOQUAN"].ToString() + "</option>";
                    string cqquanly = dt.Rows[i]["MACOQUAN"].ToString();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (cqquanly == dt.Rows[j]["CQQUANLY"].ToString())
                        {
                            result += "<option class='click_cq' ng-click='click_coquan()' " + " value='" + dt.Rows[j]["MACOQUAN"].ToString() + "'" + ">├──" + dt.Rows[j]["TENCOQUAN"].ToString() + "</option>";
                        }
                    }
                }
            }
            return result;
        }

        //hien thi co quan
        public string ht_phanquyen_loadPhongTheoCoquan(string macoquan)
        {
            string[] namepara = { "@macoquan" };
            object[] valuepara = { macoquan };
            return dataAsset.data.outputdata("ht_phanquyen_loadPhongTheoCoquan", namepara, valuepara);
        }


        //hien thi danh sach quyen truy cap khi chon PHONG
        public string ht_phanquyen_loadPhong(int maphong, string manhom)
        {
            string[] namepara = { "@idphong", "@manhom" };
            object[] valuepara = { maphong, manhom };
            return dataAsset.data.outputdata("ht_phanquyen_loadPhong", namepara, valuepara);
        }

        public string ht_phanquyen_loadphongnull(int maphong)
        {
            string[] namepara = { "@idphong"};
            object[] valuepara = { maphong };
            return dataAsset.data.outputdata("ht_phanquyen_loadphongnull", namepara, valuepara);
        }

        public bool ht_phanquyen_checkTontaiQuyenTruyCap(truycaptailieu tc)
        {
            string[] namepara = { "@MANHOM", "@PHONGID", "@MAMUCLUC"};
            object[] valuepara = { tc.Manhom, tc.Phongid, tc.Mamucluc };
            DataTable dt = dataAsset.data.outputdataTable("ht_phanquyen_checkTontaiQuyenTruyCap", namepara, valuepara);
            if (dt.Rows.Count > 0) { return true; }
            else { return false; }
        }

        [HttpPost]
        public JsonResult ht_phanquyen_GhiNhan(truycaptailieu tc, int[] xem, int[] sua, int[] them, string[] mamucluc)
        {
            int result = -1;
            if (xem.Length == sua.Length && sua.Length == mamucluc.Length)
            {
                string[] namepara = { "@MANHOM", "@PHONGID", "@MAMUCLUC", "@XEM", "@SUA", "@THEM" };
                for (int i = 0; i < xem.Length; i++)
                {
                    object[] valuepara = { tc.Manhom, tc.Phongid, mamucluc[i], xem[i], sua[i], them[i] };
                    if (ht_phanquyen_checkTontaiQuyenTruyCap(tc))
                    {
                        if (dataAsset.data.inputdata("ht_phanquyen_GhiNhanTruyCapTLUpDate", namepara, valuepara)) { result = 1; }
                        else { result = -1; }
                    }
                    else
                    {
                        if (dataAsset.data.inputdata("ht_phanquyen_GhiNhanTruyCapTL", namepara, valuepara)) { result = 1; }
                        else { result = -1; }
                    }

                }
            }
            else { result = -1; }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // ====== QUAN LY QUY TRINH ======
        // quan ly quy trinh
        public string thqt_LoadLoaiQT()
        {
            return dataAsset.data.outputdata("thqt_LoadLoaiQT");
        }

        // check ma loai quy trinh
        public bool thqt_CheckMaLoaiQT(string maloai)
        {
            string[] namepara = { "@maloai" };
            object[] valuepara = { maloai };
            DataTable dt = dataAsset.data.outputdataTable("thqt_CheckMaLoaiQT", namepara, valuepara);
            if (dt.Rows.Count > 0) { return true; }
            else { return false; }
        }

        // them - sua loai quy trinh
        public JsonResult thqt_ThemSuaLoaiQT(int type, loaiquytrinh qt)
        {
            string[] namepara = { "@MALOAI", "@TENLOAI", "@THUPHI", "@SONGAY" };
            object[] valuepara = { qt.Maloai, qt.Tenloai, qt.Thuphi, qt.Songay };
            string result = string.Empty;
            switch (type)
            {
                case 1:
                    if (thqt_CheckMaLoaiQT(qt.Maloai)){ result = "2"; }
                    else
                    {
                        if (dataAsset.data.inputdata("thqt_ThemLoaiQuyTrinh", namepara, valuepara))
                        { result = "1"; }
                        else { result = "-1"; }
                    }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("thqt_SuaLoaiQuyTrinh", namepara, valuepara)) { result = "1"; }
                    else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // kiem tra co the xoa loai quy trinh duoc hay khong
        public bool thqt_checkXoaLQT(string maloai) // true -> co the xoa; false -> ko xoa duoc
        {
            string[] namepara = { "@maloai" };
            object[] valuepara = { maloai };
            DataTable dt =  dataAsset.data.outputdataTable("thqt_checkXoaLQT", namepara, valuepara);
            if (dt.Rows.Count == 0)
            {
                DataTable dt2 = dataAsset.data.outputdataTable("thqt_checkXoaLQT2", namepara, valuepara);
                if (dt2.Rows.Count == 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        // xoa quy trinh
        public JsonResult thqt_XoaLoaiQuyTrinh(string maloai)
        {
            string result;
            if (thqt_checkXoaLQT(maloai))
            {
                string[] namepara = { "@maloai" };
                object[] valuepara = { maloai };
                if (dataAsset.data.inputdata("thqt_XoaLoaiQuyTrinh", namepara,valuepara))
                { result = "1"; }
                else
                { result = "-1"; }
            }
            else
            { result = "2"; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // load quy trinh theo loai quy trinh
        public string thqt_LoadQuyTrinh(string loaiqt)
        {
            string[] namepara = { "@loaiqt" };
            object[] valuepara = { loaiqt };
            return dataAsset.data.outputdata("thqt_LoadQuyTrinh", namepara, valuepara);
        }

        public DataTable datatable(string query)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlCommand command;
            SqlDataAdapter da;

            command = new SqlCommand(query, con);
            da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    row = new Dictionary<string, object>();
            //    foreach (DataColumn col in dt.Columns)
            //    {
            //        row.Add(col.ColumnName, dr[col]);
            //    }
            //    rows.Add(row);
            //}
            //return serializer.Serialize(rows);
            return dt;
        }

        public string chinhsua()
        {
            DataTable dt = datatable("SELECT * FROM arc.tbVanban");
            //return dt;
            string text = "";
            string soto = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                soto = dt.Rows[i]["TOSO"].ToString();
                int idvanban = int.Parse(dt.Rows[i]["ID"].ToString());
                string[] lam;
                lam = soto.Split('-');
                if (lam.Length > 1)
                {
                    string t1 = xulychuoi(lam[0]);
                    string t2 = xulychuoi(lam[1]);
                    string cuoi = t1 + "-" + t2;
                    capnhat_vanban(cuoi, idvanban);
                }
                else
                {
                    int n;
                    if (int.TryParse(soto.Trim(), out n) && n < 10)
                    {
                        text = "0" + n;
                        capnhat_vanban(text, idvanban);
                    }
                    else
                    {
                        capnhat_vanban(soto.Trim(), idvanban);
                    }
                    
                }
                
                //lam[1] = lam[1].Trim();
            }
            //return "1";
            return "OK DEP TRAI DAY";
        }

        public string xulychuoi(string text)
        {
            text = text.Trim();
            int n;
            if (int.TryParse(text, out n) && n < 10)
            {
                text = "0" + n;
            }
            else
            {
                switch (text.ToLower())
                {
                    case "jan":
                        text = "01";
                        break;
                    case "feb":
                        text = "02";
                        break;
                    case "mar":
                        text = "03";
                        break;
                    case "apr":
                        text = "04";
                        break;
                    case "may":
                        text = "05";
                        break;
                    case "jun":
                        text = "06";
                        break;
                    case "jul":
                        text = "07";
                        break;
                    case "aug":
                        text = "08";
                        break;
                    case "sep":
                        text = "09";
                        break;
                    case "oct":
                        text = "10";
                        break;
                    case "nov":
                        text = "11";
                        break;
                    case "dec":
                        text = "12";
                        break;

                }
            }
            return text;
        }


        public bool capnhat_vanban(string toso, int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            con.Open();
            string query = "UPDATE arc.tbVanban SET TOSO = '"+ toso +"' WHERE ID =" + id;
            SqlCommand command;
            command = new SqlCommand(query, con);
            if (command.ExecuteNonQuery() == 1) {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }
    }
}