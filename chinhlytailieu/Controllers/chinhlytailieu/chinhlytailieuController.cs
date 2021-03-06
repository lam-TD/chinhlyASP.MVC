﻿using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chinhlytailieu.Models.chinhly;
using System.IO;
using ExcelDataReader;
using System.Reflection;

namespace chinhlytailieu.Controllers.chinhlytailieu
{
    public class chinhlytailieuController : Controller
    {
        // GET: chinhlytailieu
        public static int idhoso = 0;
        public ActionResult index(int? id)
        {
            //List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            //return View(list);
            if (Session["username"] != null)
            {
                List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
                return View(list);
            }
            else
            {
                Response.Redirect("/dangnhap/login");
                return View("chucnang");
            }
        }

        public PartialViewResult chucnang(int id)
        {
            if (Session["username"] != null)
            {
                List<chucnang> cm = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
                ViewBag.Count = cm.Count();
                return PartialView("chucnang", cm);
            }
            else
            {
                Response.Redirect("/dangnhap/login");
                return PartialView("chucnang");
            }
            
        }

        public ActionResult phanheQLthuthapTL(int? id)
        {
            
            return View();
        }

        public ActionResult lapkehoachchinhly()
        {
            return View();
        }

        public ActionResult taomucluc()
        {
            return View();
        }

        public ActionResult nhaphoso()
        {
            return View();
        }

        public ActionResult nhaphosothem(int? hosoid)
        {
            return View();
        }

        public ActionResult nhapvanban()
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

        public ActionResult taohop()
        {
            return View();
        }

        public ActionResult xephosovaohop()
        {
            return View();
        }

        public ActionResult kiemtrahosochinhly()
        {
            return View();
        }

        public ActionResult giaotailieuvaokho()
        {
            return View();
        }

        public ActionResult danhsachphong()
        {
            return View();
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

        public ActionResult thongke()
        {
            return View();
        }

        //================ phan he thu thap ======================
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

            string[] thongke = { thongkehoso, thongkevanban, thongkemucluc };
            return Json(thongke, JsonRequestBehavior.AllowGet);
        }

        //================ lap ke hoach chinh ly =================
        public string lapkehoachchinhly_load()
        {
            return dataAsset.data.outputdata("chinhly_lkhcl_load");
        }

        public string loadcoquan()
        {
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            string lam = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lam += "<option value=''>"+ dt.Rows[i]["TENCOQUAN"].ToString() + "</option>";
                if (dt.Rows[i]["MACOQUAN"].ToString() != null)
                {
                    lam+= get_conCoquan(dt.Rows[i]["MACOQUAN"].ToString(), 1);
                }
                
            }
            return lam;
        }
        public string get_conCoquan(string macoquan, int level)
        {
            string[] namepara = { "@cqquanly" };
            object[] valuepara = { macoquan };
            string lam = null;
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan_Con",namepara,valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string noi = "─";
                for (int j = 0; j < level; j++)
                {
                    noi += noi;
                }
                lam += "<option value=''>├"+ noi + dt.Rows[i]["TENCOQUAN"].ToString() + "</option>";
                get_conCoquan(dt.Rows[i]["MACOQUAN"].ToString(),2);
            }
            return lam;
        }

        public string nhapmucluc_loaddanhsach(int id)
        {
            if (id > 0)
            {
                string[] namepara = { "@idphong" };
                object[] valuepara = { id };
                return dataAsset.data.outputdata("mucluc_load", namepara, valuepara);
            }
            else { return "-1"; }
            
        }

        public string nhapmucluc_loadphong()
        {
            return dataAsset.data.outputdata("mucluc_loadPhong");
        }

        public JsonResult lapkehoach_them(lapkehoachchinhly k)
        {
            int result = -1;
            string ghichu = "";
            if (k.Ghichu != null)
            {
                ghichu = k.Ghichu;
            }
            string[] namepara1 = { "@NAM", "@MUCDICH", "@PHONGID", "@TENPHONG", "@GIAIDOAN", "@GHICHU", "@TRANGTHAI", "@THAMDINH" };
            object[] valuepara1 = { k.Nam, k.Mucdich, k.Phongid, "tenphong", k.Giaidoan, ghichu, k.Trangthai, k.Thamdinh };
            if (dataAsset.data.inputdata("kehoachchinhly_them", namepara1, valuepara1))
            { result = 1; }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult lapkehoach_sua(lapkehoachchinhly k, int phongid)
        {
            int result = -1;
            string ghichu = "";
            if (k.Ghichu != null)
            {
                ghichu = k.Ghichu;
            }
            string[] namepara = { "@ID", "@NAM", "@MUCDICH", "@PHONGID", "@TENPHONG", "@GIAIDOAN", "@GHICHU", "@TRANGTHAI", "@THAMDINH" };
            object[] valuepara = { k.Id, k.Nam, k.Mucdich, phongid, "tenphong", k.Giaidoan, ghichu, k.Trangthai, k.Thamdinh };
            if (dataAsset.data.inputdata("kehoachchinhly_sua", namepara, valuepara))
            { result = 1; }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult lapkehoach_xoa(int kehoachid)
        {
            int result = -1;
            string[] namepara = { "@ID" };
            object[] valuepara = { kehoachid };
            if (dataAsset.data.inputdata("kehoachchinhly_xoa", namepara, valuepara))
            { result = 1; }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult mucluc_themsua(int? type, mucluc ml)
        {
            string result = string.Empty;
            string mota = "", ghichu = "";
            if (ml.Ghichu != null)
            {
                ghichu = ml.Ghichu;
            }
            if (ml.Mota != null)
            {
                mota = ml.Mota;
            }
            switch (type)
            {
                case 1:
                    string[] namepara1 = { "@PHONGID", "@MAMUCLUC", "@TENMUCLUC", "@MOTA", "@GHICHU" };
                    object[] valuepara1 = { ml.Phongid, ml.Mamucluc, ml.Tenmucluc, mota, ghichu };
                    if (nhapmucluc_checkmamucluc(ml.Mamucluc, ml.Phongid) == 1) result = "0";
                    else
                    {
                        if (dataAsset.data.inputdata("mucluc_them", namepara1, valuepara1))
                        { result = "1"; }
                        else { result = "-1"; }
                    }
                    
                    break;
                case 2:
                    string[] namepara2 = { "@ID", "@PHONGID", "@TENMUCLUC", "@MOTA", "@GHICHU" };
                    object[] valuepara2 = { ml.Id, ml.Phongid, ml.Tenmucluc, mota, ghichu };
                    if (dataAsset.data.inputdata("mucluc_sua", namepara2, valuepara2)) { result = "1"; }
                    else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult muclucsua(mucluc ml)
        {
            string result = string.Empty;
            string[] namepara2 = { "@PHONGID", "@MAMUCLUC", "@TENMUCLUC", "@MOTA", "@GHICHU" };
            object[] valuepara2 = { ml.Phongid, ml.Mamucluc, ml.Tenmucluc, ml.Mota, ml.Ghichu };
            if (dataAsset.data.inputdata("mucluc_sua", namepara2, valuepara2)) { result = "1"; }
            else { result = "-1"; }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public int nhapmucluc_checkmamucluc(string mamucluc, int phongid)
        {
            int result;
            string[] namepara = { "@MAMUCLUC", "@PHONGID" };
            object[] valuepara = { mamucluc, phongid };
            DataTable dt = dataAsset.data.outputdataTable("mucluc_checkma", namepara, valuepara);
            if (dt.Rows.Count > 0)
            { result = 1; }
            else { result = -1; }
            return result;
        }

        public JsonResult mucluc_xoa(int? idmucluc)
        {
            int result;
            string[] namepara = { "@MULUCID" };
            object[] valuepara = { idmucluc };
            DataTable dt = dataAsset.data.outputdataTable("checkMucluc_hoso", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 0;
            }
            else
            {
                if (dataAsset.data.inputdata("mucluc_xoa", namepara, valuepara))
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //==================== NHAP HO SO CHINH LY ====================
        public string hoso_load(int phongid, int pageIndex, int pageSize)
        {
            string[] namepara = { "@phongid", "@pageIndex", "@pageSize" };
            object[] valuepara = { phongid, pageIndex, pageSize };
            return dataAsset.data.outputdata("hoso_load_phongid", namepara, valuepara);
        }

        public string hoso_load_phong_mucluc(int phongid,int muclucid, int pageIndex, int pageSize)
        {
            string[] namepara = { "@phongid", "@muclucid", "@pageIndex", "@pageSize" };
            object[] valuepara = { phongid, muclucid,pageIndex, pageSize };
            return dataAsset.data.outputdata("hoso_load_phongid_muclucid", namepara, valuepara);
        }

        public void hoso_set_session(int phongid)
        {
            Session["phongid"] = phongid;
        }

        public string hoso_get_session()
        {
            if (Session["phongid"] == null) return "0";
            return Session["phongid"].ToString();
        }

        public int hoso_them(hoso h, int hopid = 0)
        {
            int result = -1;
            string ghichu = "", chugiai = "", tinhtrang = "", ngonngu = "";
            if (h.Ghichu != null){ ghichu = h.Ghichu; }
            if (h.Chugiai != null) { chugiai = h.Chugiai; }
            if (h.Tinhtrang != null) { tinhtrang = h.Tinhtrang; }
            if (h.Ngonngu != null) { ngonngu = h.Ngonngu; }
            if (hop_checksoluong(hopid,1) >= 1 && hopid > 0)
            {
                string[] namepara = { "@PHONGID", "@MUCLUC", "@MAHOP", "@LOAITL", "@MAHOSO", "@TENHOSO", "@NAMLAP", "@CHUGIAI", "@THOIGIANS", "@THOIGIANE", "@NGONNGU", "@SLTO", "@HCSD", "@TINHTRANG", "@GHICHU", "@BIENMUC" };
                object[] valuepara = { h.Phongid, h.Mucluc, h.Mahop, h.Loaitl, h.Mahoso, h.Tenhoso, h.Namlap, chugiai, h.Thoigians, h.Thoigiane, ngonngu, h.Slto, h.Hcsd, tinhtrang, ghichu, h.Bienmuc };
                if (dataAsset.data.inputdata("hoso_them", namepara, valuepara))
                {
                    hoso_capnhatsoluonghoso(hopid, h.Mahop, h.Mucluc, h.Phongid);
                    result = 1;
                }
                else { result = -1; }
            }
            else if(h.Mahop == null){
                if (hoso_check_idhoso(h.Mahoso, h.Phongid, h.Mucluc) == 1) return -2;
                string[] namepara = { "@PHONGID", "@MUCLUC", "@MAHOP", "@LOAITL", "@MAHOSO", "@TENHOSO", "@NAMLAP", "@CHUGIAI", "@THOIGIANS", "@THOIGIANE", "@NGONNGU", "@SLTO", "@HCSD", "@TINHTRANG", "@GHICHU", "@BIENMUC" };
                object[] valuepara = { h.Phongid, h.Mucluc, "", h.Loaitl, h.Mahoso, h.Tenhoso, h.Namlap, chugiai, h.Thoigians, h.Thoigiane, ngonngu, h.Slto, h.Hcsd, tinhtrang, ghichu, h.Bienmuc };
                if (dataAsset.data.inputdata("hoso_them", namepara, valuepara))
                {
                    result = 1;
                }
                else { result = -1; }
            }
            else { result = 0; }
            
            return result;
        }

        
        public JsonResult hoso_sua(hoso h, string[] mangmahop, string[] hopcapnhat)
        {
            // mangmahop - $scope.hopmaCha, $scope.hopidCha, $scope.muclucidCha, mahop, hopid
            // hopcapnhat - mang chua phongid, muclucid

            int result = -1;
            int phongid = int.Parse(hopcapnhat[0]);
            int muclucid = int.Parse(hopcapnhat[1]);
            
            // hop moi
            string mahop = mangmahop[3].ToString();
            int hopid = 0;
            if (mangmahop[4] != "" && mangmahop[4] != null){hopid = int.Parse(mangmahop[4]);}

            // hop cu
            string mahopcu = "";
            if (mangmahop[0] != "" && mangmahop[0] != null) mahopcu = mangmahop[0].ToString();
            int muclucidcu = int.Parse(mangmahop[2]);

            // mahopcu == "" && mahop != "" && mahopcu != mahop - thay doi hop
            // mahopcu != mahop && mahopcu != "" - 
            if (mahopcu != mahop && mahopcu != "")
            {
                if (hop_checksoluong(hopid, 1) >= 1)
                {
                    string ghichu = "", chugiai = "", tinhtrang = "", ngonngu = "";
                    if (h.Ghichu != null) { ghichu = h.Ghichu; }
                    if (h.Chugiai != null) { chugiai = h.Chugiai; }
                    if (h.Tinhtrang != null) { tinhtrang = h.Tinhtrang; }
                    if (h.Ngonngu != null) { ngonngu = h.Ngonngu; }
                    string[] namepara = { "@ID", "@PHONGID", "@MUCLUC", "@MAHOP", "@LOAITL", "@MAHOSO", "@TENHOSO", "@NAMLAP", "@CHUGIAI", "@THOIGIANS", "@THOIGIANE", "@NGONNGU", "@SLTO", "@HCSD", "@TINHTRANG", "@GHICHU", "@BIENMUC" };
                    object[] valuepara = { h.Id, phongid, muclucid, mahop, h.Loaitl, h.Mahoso, h.Tenhoso, h.Namlap, chugiai, h.Thoigians, h.Thoigiane, ngonngu, h.Slto, h.Hcsd, tinhtrang, ghichu, h.Bienmuc };

                    if (dataAsset.data.inputdata("hoso_sua", namepara, valuepara))
                    {
                        if (mahopcu != "" && mahopcu != mahop)
                        {
                            hoso_capnhatsoluonghoso(1, mahopcu, muclucidcu, phongid); // cap nhat so luong hoso hop cu
                        }
                        hoso_capnhatsoluonghoso(1, mahop, muclucid, phongid); // cap nhat so luong hoso hop moi
                        result = 1;
                    }
                    else { result = -1; }
                }
                else { result = 0; }
            }
            else
            {
                string ghichu = "", chugiai = "", tinhtrang = "", ngonngu = "";
                if (h.Ghichu != null) { ghichu = h.Ghichu; }
                if (h.Chugiai != null) { chugiai = h.Chugiai; }
                if (h.Tinhtrang != null) { tinhtrang = h.Tinhtrang; }
                if (h.Ngonngu != null) { ngonngu = h.Ngonngu; }
                string[] namepara = { "@ID", "@PHONGID", "@MUCLUC", "@MAHOP", "@LOAITL", "@MAHOSO", "@TENHOSO", "@NAMLAP", "@CHUGIAI", "@THOIGIANS", "@THOIGIANE", "@NGONNGU", "@SLTO", "@HCSD", "@TINHTRANG", "@GHICHU", "@BIENMUC" };
                object[] valuepara = { h.Id, phongid, muclucid, mahop, h.Loaitl, h.Mahoso, h.Tenhoso, h.Namlap, chugiai, h.Thoigians, h.Thoigiane, ngonngu, h.Slto, h.Hcsd, tinhtrang, ghichu, h.Bienmuc };

                if (dataAsset.data.inputdata("hoso_sua", namepara, valuepara))
                {
                    //if (mahopcu != mahop)
                    //{
                    //    hoso_capnhatsoluonghoso(1, mahopcu, muclucidcu, phongid); // cap nhat so luong hoso hop cu
                    //    hoso_capnhatsoluonghoso(1, mahop, muclucid, phongid); // cap nhat so luong hoso hop moi
                    //}
                    result = 1;
                }
                else { result = -1; }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public int hoso_check_idhoso(string mahoso, int phongid, int muclucid)
        {
            string[] namepara = { "@MAHOSO", "@PHONGID", "@MUCLUCID" };
            object[] valuepara = { mahoso, phongid, muclucid };
            int result;
            DataTable dt = dataAsset.data.outputdataTable("hoso_check_idhoso", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1; 
            }
            else { return -1; }
            return result;
        }

        [HttpPost]
        public int hop_loaibohoso(hoso h)
        {
            string[] namepara = { "@HOSOID", "@PHONGID", "@MUCLUCID" };
            object[] valuepara = { h.Id, h.Phongid, h.Mucluc };
            if (dataAsset.data.inputdata("hop_loaibohoso", namepara, valuepara)) {
                if (h.Mahop != "" && h.Mahop != null)
                {
                    hoso_capnhatsoluonghoso(h.Id, h.Mahop, h.Mucluc, h.Phongid);
                }
                return 1;
            }
            return -1;
        }

        public int loadchitiethoso(int id)
        {
            Session["capnhathoso"] = id;
            idhoso = id;
            return 1;
        }

        public string hoso_loadchitiet(int id)
        {
            string[] namepara = { "@id" };
            object[] valuepara = { id };
            return dataAsset.data.outputdata("hoso_loadchitiet", namepara, valuepara);
        }

        public string hoso_loadHop(int muclucid)
        {
            string[] namepara = { "@muclucid" };
            object[] valuepara = { muclucid };
            return dataAsset.data.outputdata("hoso_loadHop", namepara, valuepara);
        }

        public string hop_loadhoptheoPhong(int phongid)
        {
            string[] namepara = { "@phongid" };
            object[] valuepara = { phongid };
            return dataAsset.data.outputdata("hop_loadhoptheoPhong", namepara, valuepara);
        }

        public JsonResult hop_them(hop h)
        {
            int result = -1;
            if (h != null && h.Mahop.Length > 0 && h.Muclucid > 0)
            {
                string[] namepara = { "@MAHOP", "@MUCLUCID", "@NGANID", "@SLMAX", "@SLHOSO" };
                object[] valuepara = { h.Mahop, h.Muclucid, "94", 10, 0 };
                if (dataAsset.data.inputdata("hop_them", namepara, valuepara))
                {
                    result = 1;
                }
                else { result = -1; }
            }
            else { result = -1; }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult hop_themnhieu(hop h, int slhop)
        {
            int result = 0;
            //string mahopcuoi = hop_idcuoi();
            //string[] mahop = mahopcuoi.Split('-');
            int socuoi = int.Parse(h.Mahop);
            for (int i = socuoi; i < (socuoi + slhop); i++)
            {
                h.Mahop = "HOP-" + i;
                hop_them(h);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public int hop_checkmahop(string mahop)
        {
            string[] namepara = { "@mahop" };
            object[] valuepara = { mahop.Trim() };
            int result;
            DataTable dt = dataAsset.data.outputdataTable("hop_checkmahop", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1;
            }
            else { result = -1; }
            return result;
        }

        public string hop_idcuoi()
        {
            string result="";
            DataTable dt = dataAsset.data.outputdataTable("hoso_idlast");
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["MAHOP"].ToString();
            }
            //else { result = "HOP-1"; }
            return result;
        }

        public JsonResult hop_xoa(hop h, int phongid)
        {
            int result = -1;
            string[] namepara = { "@ID" };
            object[] valuepara = { h.Id };
            if (hop_checkhoso(h, phongid) != 1)
            {
                if (dataAsset.data.inputdata("hop_xoa", namepara, valuepara))
                {
                    result = 1;
                }
                else { result = -1; }
            }
            else { result = 0; }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public int hop_checkhoso(hop h, int phongid)
        {
            int result;
            string[] namepara = { "@MAHOP", "@MUCLUC", "@PHONGID" };
            object[] valuepara = { h.Mahop, h.Muclucid, phongid };
            DataTable dt = dataAsset.data.outputdataTable("hop_checkhoso", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1;
            }
            else { result = -1; }
            return result;
        }

        public int hop_checksoluong(int hopid, int sl)
        {
            int result = 0;
            string[] namepara = { "@ID" };
            object[] valuepara = { hopid };
            DataTable dt = dataAsset.data.outputdataTable("hop_checksoluong", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                int max = int.Parse(dt.Rows[0]["SLMAX"].ToString());
                int slhop = int.Parse(dt.Rows[0]["SLHOSO"].ToString());
                result = max - slhop;
            }
            return result;
        }

        public JsonResult hop_capnhatsoluong(int hopid)
        {
            int result;
            string[] namepara = { "@ID" };
            object[] valuepara = { hopid };
            DataTable dt = dataAsset.data.outputdataTable("hop_loadtheoIDhop", namepara, valuepara);
            int sl_cu = int.Parse(dt.Rows[0]["SLHOSO"].ToString());
            string[] namepara2 = { "@ID","@SL" };
            object[] valuepara2 = { hopid, sl_cu + 1 };
            if (dataAsset.data.inputdata("hop_capnhatsoluong", namepara2, valuepara2))
            {
                result = 1;
            }
            else { result = -1; }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int hoso_checkVanBanXoa(int hosoid)
        {
            int result;
            string[] namepara = { "@HOSOID" };
            object[] valuepara = { hosoid };
            DataTable dt = dataAsset.data.outputdataTable("hoso_checkVanBanXoa",namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1;
            }
            else { result = -1; }
            return result;
        }

        [HttpPost]
        public JsonResult hoso_xoa(int hosoid, string mahop, int muclucid, int phongid)
        {
            int result = -1;
            if (hoso_checkVanBanXoa(hosoid) == 1)
            {
                result = 0;
            }
            else
            {
                string[] namepara = { "@HOSOID" };
                object[] valuepara = { hosoid };
                if (dataAsset.data.inputdata("hoso_xoa", namepara, valuepara))
                {
                    if (mahop != "")
                    {
                        hoso_capnhatsoluonghoso(hosoid, mahop, muclucid, phongid);
                    }
                    result = 1;
                }
                else { result = -1; }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
  

        //================== van ban =================
        public string hoso_loadtheoMucLuc(int muclucid)
        {
            string[] namepara = { "@MUCLUCID" };
            object[] valuepara = { muclucid };
            return dataAsset.data.outputdata("hoso_loadtheoMucLuc", namepara, valuepara);
        }

        public string vanban_loadtheohoso(int hosoid)
        {
            string[] namepara = { "@HOSOID" };
            object[] valuepara = { hosoid };
            return dataAsset.data.outputdata("vanban_loadtheohoso", namepara, valuepara);
        }

        public int vanban_them(vanban v, int hosoid)
        {
            //int result = -1;
            string tg;
            try
            {
                DateTime date = DateTime.Parse(v.Thoigian);
                tg = date.ToString("dd/MM/yyy");
            }
            catch (Exception)
            {
                tg = v.Thoigian;
            }
            string ghichu = "", ngonngu = "", tacgia = "", tenloai = "", kyhieu = "", buttich = "";
            if (v.Ghichu != null) { ghichu = v.Ghichu; }
            if (v.Ngonngu != null) { ngonngu = v.Ngonngu; }
            if (v.Tacgia != null) { tacgia = v.Tacgia; }
            if (v.Tenloai != null) { tenloai = v.Tenloai; }
            if (v.Kyhieu != null) { kyhieu = v.Kyhieu; }
            if (v.Buttich != null) { buttich = v.Buttich; }
            string[] namepara = { "@HOSOID", "@TOSO", "@SLTO", "@SUDUNG", "@SOKYHIEU", "@THOIGIAN", "@TACGIA", "@TENLOAI", "@TRICHYEU", "@KYHIEU", "@NGOCNGU", "@BUTTICH", "@GHICHU" };
            object[] valuepara = { hosoid, v.Toso, v.Slto, v.Sudung, v.Sokyhieu, tg, tacgia, tenloai, v.Trichyeu, kyhieu, ngonngu, buttich, ghichu };
            if (dataAsset.data.inputdata("vanban_them", namepara, valuepara))
            {
                return 1;
            }
            else { return -1; }
            //return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult vanban_sua(vanban v)
        {
            int result = -1;
            string ghichu = "", ngonngu = "", tacgia = "", tenloai = "", buttich = "";
            if (v.Ghichu != null) { ghichu = v.Ghichu; }
            if (v.Ngonngu != null) { ngonngu = v.Ngonngu; }
            if (v.Tacgia != null) { tacgia = v.Tacgia; }
            if (v.Tenloai != null) { tenloai = v.Tenloai; }
            if (v.Buttich != null) { buttich = v.Buttich; }
            string[] namepara = { "@ID","@HOSOID", "@TOSO", "@SLTO", "@SUDUNG", "@SOKYHIEU", "@THOIGIAN", "@TACGIA", "@TENLOAI", "@TRICHYEU", "@KYHIEU", "@NGOCNGU", "@BUTTICH", "@GHICHU" };
            object[] valuepara = { v.Id, v.Hosoid, v.Toso, v.Slto, v.Sudung, v.Sokyhieu, v.Thoigian, tacgia, tenloai, v.Trichyeu, "", ngonngu, buttich, ghichu };
            if (dataAsset.data.inputdata("vanban_sua", namepara, valuepara))
            {
                result = 1;
            }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int vanban_xoa(int vanbanid)
        {
            int result;
            string[] namepara = { "@VANBANID" };
            object[] valuepara = { vanbanid };
            if (dataAsset.data.inputdata("vanban_xoa", namepara, valuepara))
            {
                result = 1;
            }
            else { result = -1; }
            return result;
        }

        public string hoso_hschuavaohop(int phongid, int pageIndex, int pageSize)
        {
            string[] namepara = { "@PHONGID", "@pageSize", "@pageIndex" };
            object[] valuepara = { phongid, pageSize, pageIndex };
            return dataAsset.data.outputdata("hoso_hschuavaohop", namepara, valuepara);
        }
        public string hoso_demhosochuavaohop(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            return dataAsset.data.outputdata("hoso_demhosochuavaohop", namepara, valuepara);
        }

        public string hoso_loadtheohop(string mahop, int muclucid, int phongid)
        {
            string[] namepara = { "@MAHOP", "@MAMUCLUC", "@PHONGID" };
            object[] valuepara = { mahop, muclucid, phongid };
            return dataAsset.data.outputdata("hoso_loadtheohop", namepara, valuepara);
        }

        public int themhosovaohop(int[] h, string mahop, int muclucid, int hopid, int phongid)
        {
            int result = -1;
            if (h.Length > 0 && mahop != null)
            {
                for (int i = 0; i < h.Length; i++)
                {
                    string[] namepara = { "@HOSOID", "@MAHOP", "@MUCLUCID" };
                    object[] valuepara = { h[i], mahop, muclucid };
                    dataAsset.data.inputdata("hoso_themhosovaohop", namepara, valuepara);
                }
                hoso_capnhatsoluonghoso(hopid, mahop, muclucid, phongid);
                
                result = 1;
            }
            return result;
        }

        public JsonResult hoso_capnhatsoluonghoso(int hopid, string mahop, int muclucid, int phongid)
        {
            int result;
            if (hopid > 0 && mahop != "")
            {
                
                string[] namepara = { "@MAHOP", "@MUCLUCID", "@PHONGID" };
                object[] valuepara = { mahop, muclucid, phongid };
                DataTable dt = dataAsset.data.outputdataTable("hoso_loadtheohop", namepara, valuepara);

                int sl_cu = dt.Rows.Count;
                string[] namepara2 = { "@MAHOP", "@MUCLUCID", "@SLHOSO" };
                object[] valuepara2 = { mahop, muclucid, sl_cu };
                if (dataAsset.data.inputdata("hoso_capnhatsoluong2", namepara2, valuepara2))
                {
                    result = 1;
                }
                else { result = -1; }
            }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //========================= TIM KIEM =====================
        public string chinhly_timkiemhoso(string keyword)
        {
            Session["keyword"] = keyword.Trim();
            string[] namepara = { "@keyword" };
            object[] valuepara = { keyword.Trim() };
            return dataAsset.data.outputdata("chinhly_timkiemhoso", namepara, valuepara);
        }

        public string chinhly_timkiemhoso_phong_mucluc(int phongid, int muclucid, string keyword)
        {
            string[] namepara = { "@phongid", "@muclucid", "@keyword" };
            object[] valuepara = { phongid, muclucid, keyword.Trim() };
            return dataAsset.data.outputdata("hoso_timkiem_phong_mucluc", namepara, valuepara);
        }

        //public string chinhly_timkiemhoso_pagination(string keyword)
        //{
        //    string[] namepara = { "@keyword" };
        //    object[] valuepara = { keyword.Trim() };
        //    return dataAsset.data.outputdata("chinhly_timkiemhoso", namepara, valuepara);
        //}

        public string chinhly_timkiemhoso_pagination(int phongid, string keyword)
        {
            string[] namepara = { "@PHONGID", "@keyword" };
            object[] valuepara = { phongid, keyword.Trim() };
            return dataAsset.data.outputdata("hoso_timkiem_hosochuavaohop", namepara, valuepara);
        }

        public void session_keyword(string keyword) {
            Session["keyword"] = keyword.Trim();
        }
        public void session_keyword_vanban(string keyword)
        {
            Session["keyword_vanban"] = keyword.Trim();
        }
        public string get_sesion_keyword()
        {
            if (Session["keyword"] == null)
                return null;
            else
                return Session["keyword"].ToString();
        }

        public string get_sesion_keyword_vanban()
        {
            if (Session["keyword_vanban"] == null)
                return null;
            else
                return Session["keyword_vanban"].ToString();
        }

        public string chinhly_timkiemhosonangcao(int phongid, string loaitl, string mahoso, string tenhoso)
        {
            if (phongid > 0)
            {
                string[] namepara = { "@PHONGID", "@LOAITL", "@MAHOSO", "@TIEUDE" };
                object[] valuepara = { phongid, loaitl, mahoso, tenhoso };
                return dataAsset.data.outputdata("chinhly_timkiemhoso_nangcao", namepara, valuepara);
            }
            else { return "-1"; }
        }

        public string chinhly_timkiemvanban(string keyword)
        {
            Session["keyword_vanban"] = keyword.Trim();
            string[] namepara = { "@keyword" };
            object[] valuepara = { keyword.Trim() };
            return dataAsset.data.outputdata("chinhly_timkiemvanban", namepara, valuepara);
        }

        public string chinhly_timkiemvanbannangcao(int phongid, string loaitl, string sokyhieu, string trichyeu, string thoigian, string tacgia)
        {
            
            string[] namepara = { "@PHONGID", "@LOAITL", "@SOKYHIEU", "@TRICHYEU", "@TACGIA", "@THOIGIAN" };
            object[] valuepara = { phongid, loaitl, sokyhieu.Trim(), trichyeu.Trim(), tacgia.Trim(), thoigian.Trim() };
            return dataAsset.data.outputdata("chinhly_timkiemvanban_nangcao", namepara, valuepara);
        }

        //============================= PHONG TAI LIEU ==================================
        [HttpPost]
        public int chinhly_phong_them(phongtailieu p)
        {
            if (p.Maphong.Length < 0) return -1;
            if (chinhly_phong_checkmaphong(p.Maphong) == 1){ return 0; }
            string lichsu = ""; if (p.Lichsu != null) lichsu = p.Lichsu;
            string thoigian = ""; if (p.Thoigian != null) thoigian = p.Thoigian;
            string ghichu = ""; if (p.Ghichu != null) ghichu = p.Ghichu;
            string congcu = ""; if (p.Congcu != null) congcu = p.Congcu;
            string nhomtl = ""; if (p.Nhomtl != null) nhomtl = p.Nhomtl;
            string thoigiannhap = ""; if (p.Thoigiannhap != null) thoigiannhap = p.Thoigiannhap;
            string ngonngu = ""; if (p.Ngonngu != null) ngonngu = p.Ngonngu;
            //int bansao = 0; if (p.Bansao != null) bansao = p.Bansao;
            string[] namepara = { "@MACOQUAN", "@MAPHONG", "@TENPHONG", "@VITRIID", "@LICHSU", "@THOIGIAN", "@SLTAILIEU", "@SLTLOK", "@SLTLNO", "@GHICHU", "@CONGCU", "@NHOMTL", "@THOIGIANNHAP", "@NGONNGU", "@BANSAO" };
            object[] valuepara = { "Q2", p.Maphong, p.Tenphong, p.Vitriid, lichsu, thoigian, p.Sltailieu, p.Sltlok, p.Sltlok, ghichu, congcu, nhomtl, thoigiannhap, ngonngu, p.Bansao };
            if (dataAsset.data.inputdata("phong_them", namepara, valuepara))
            {
                return 1;
            }
            else { return -1; }
        }

        public int chinhly_phong_sua(phongtailieu p)
        {
            if (p.Maphong.Length < 0) return -1;
            
            string lichsu = ""; if (p.Lichsu != null) lichsu = p.Lichsu;
            string thoigian = ""; if (p.Thoigian != null) thoigian = p.Thoigian;
            string ghichu = ""; if (p.Ghichu != null) ghichu = p.Ghichu;
            string congcu = ""; if (p.Congcu != null) congcu = p.Congcu;
            string nhomtl = ""; if (p.Nhomtl != null) nhomtl = p.Nhomtl;
            string thoigiannhap = ""; if (p.Thoigiannhap != null) thoigiannhap = p.Thoigiannhap;
            string ngonngu = ""; if (p.Ngonngu != null) ngonngu = p.Ngonngu;
            
            string[] namepara = { "@ID", "@TENPHONG", "@VITRIID", "@LICHSU", "@THOIGIAN", "@SLTAILIEU", "@SLTLOK", "@SLTLNO", "@GHICHU", "@CONGCU", "@NHOMTL", "@THOIGIANNHAP", "@NGONNGU", "@BANSAO" };
            object[] valuepara = { p.Id, p.Tenphong, p.Vitriid, lichsu, thoigian, p.Sltailieu, p.Sltlok, p.Sltlok, ghichu, congcu, nhomtl, thoigiannhap, ngonngu, p.Bansao };
            if (dataAsset.data.inputdata("phong_sua", namepara, valuepara))
            {
                return 1;
            }
            else { return -1; }
        }

        public int chinhly_phong_checkmaphong(string maphong)
        {
            int result;
            string[] namepara = { "@MAPHONG" };
            object[] valuepara = { maphong };
            DataTable dt = dataAsset.data.outputdataTable("phong_checkmaphong", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1;
            }
            else { result = -1; }
            return result;
        }

        [HttpPost]
        public int chinhly_phong_xoa(int phongid)
        {
            if (chinhly_phong_checkmucluc(phongid) == 1) return 0;
            
            string[] namepara = { "@PHINGID" };
            object[] valuepara = { phongid };
            if (dataAsset.data.inputdata("phong_xoa", namepara, valuepara)) return 1;
            else return -1;
            
        }

        public int chinhly_phong_checkmucluc(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            DataTable dt = dataAsset.data.outputdataTable("phong_checkmucluc", namepara, valuepara);
            if (dt.Rows.Count > 0) return 1;
            else return -1;
        }

        public JsonResult read_excel(string type)
        {
            string datanew = "";
            List<vanban> lisvanban = new List<vanban>();
            List<hoso> lishoso = new List<hoso>();
            if (ModelState.IsValid)
            {
                string filePath = string.Empty;
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["file"];
                    //string type = this.Request.["type"].ToString();
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {

                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        string path = Server.MapPath("~/assets/upload/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        filePath = path + Path.GetFileName(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        file.SaveAs(filePath);
                        Stream stream = file.InputStream;
                        // We return the interface, so that  
                        IExcelDataReader reader = null;
                        if (file.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (file.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        else
                        {
                            ModelState.AddModelError("File", "This file format is not supported");
                            return Json("-2", JsonRequestBehavior.AllowGet);
                            //return RedirectToAction("ExcelUpload");
                        }

                        var conf = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true
                            }
                        };

                        //reader.IsFirstRowAsColumnNames = true;
                        DataSet result = reader.AsDataSet(conf);
                        reader.Close();
                        //delete the file from physical path after reading   
                        string filedetails = path + fileName;
                        FileInfo fileinfo = new FileInfo(filedetails);
                        if (fileinfo.Exists)
                        {
                            fileinfo.Delete();
                        }
                        DataTable dt = result.Tables[0];
                        if (type == "1")
                        {
                            lisvanban = get_list_vanban(dt);
                            TempData["listvanban"] = lisvanban;
                            return Json(lisvanban, JsonRequestBehavior.AllowGet);
                        }
                        else if(type == "2")
                        {
                            lishoso = get_list_hoso(dt);
                            TempData["listhoso"] = lishoso;
                            return Json(lishoso, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            return Json("-1", JsonRequestBehavior.AllowGet);
        }

        public JsonResult insert_excel_data(int phongid, string mamucluc)
        {
            int count = 0;
            List<vanban> v = (List<vanban>)TempData["listvanban"];
            foreach (vanban item in v)
            {
                string mahoso = v[0].Mahoso;
                string mahoso_new = "";
                if (item.Mahoso != "" && item.Mahoso != null)
                {
                    mahoso_new = item.Mahoso;
                    int hosoid = get_hosoid(phongid, mamucluc, mahoso_new);
                    if (vanban_them(item, hosoid) == 1) count++;
                }
                else
                {
                    int hosoid = get_hosoid(phongid, mamucluc, mahoso);
                    if (vanban_them(item, hosoid) == 1) count++;
                }
            }
            int[] ketqua = new int[2];
            ketqua[0] = count;
            ketqua[1] = v.Count;
            TempData["listvanban"] = null;
            return Json(ketqua, JsonRequestBehavior.AllowGet);
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    return Json("-1", JsonRequestBehavior.AllowGet);
            //}
        }

        public int check_file_exist(string filename)
        {
            string path = Server.MapPath("~/Images/") + filename;
            if(System.IO.File.Exists(path) == true)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public JsonResult insert_excel_hoso(int phongid, string mamucluc)
        {
            int count = 0;
            List<hoso> h = (List<hoso>)TempData["listhoso"];
            foreach (hoso item in h)
            {
                item.Phongid = phongid;
                item.Mucluc = int.Parse(mamucluc);
                if (hoso_them(item) == 1) count++;
            }
            int[] ketqua = new int[2];
            ketqua[0] = count;
            ketqua[1] = h.Count;
            TempData["listhoso"] = null;
            return Json(ketqua, JsonRequestBehavior.AllowGet);
        }

        public int get_hosoid(int phongid, string mamucluc, string mahoso)
        {
            string[] namepara = { "@PHONGID", "@MAMUCLUC", "@MAHOSO" };
            object[] valuepara = { phongid, mamucluc, mahoso };
            DataTable dt = dataAsset.data.outputdataTable("hoso_getid", namepara, valuepara);
            if (dt.Rows.Count > 0) return int.Parse(dt.Rows[0]["ID"].ToString());
            else return -1;
        }

        public List<vanban> get_list_vanban(DataTable dt)
        {
            List<vanban> lisvanban = new List<vanban>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vanban v = new vanban();
                v.Sokyhieu = dt.Rows[i]["SOKYHIEU"].ToString();
                v.Trichyeu = dt.Rows[i]["TRICHYEU"].ToString();
                v.Thoigian = dt.Rows[i]["THOIGIAN"].ToString();
                v.Mahoso = dt.Rows[i]["MAHOSO"].ToString();
                v.Toso = dt.Rows[i]["TOSO"].ToString();
                v.Tacgia = dt.Rows[i]["TACGIA"].ToString();
                //if (dt.Rows[i]["Số hồ sơ"].ToString() == null) v.Slto = 0;
                //else v.Slto = int.Parse(dt.Rows[i]["Số hồ sơ"].ToString());
                v.Ghichu = dt.Rows[i]["GHICHU"].ToString();
                lisvanban.Add(v);
            }
            return lisvanban;
        }

        public List<hoso> get_list_hoso(DataTable dt)
        {
            List<hoso> listhoso = new List<hoso>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hoso h = new hoso();
                int slto = 0, bienmuc = 1;
                h.Mahoso = dt.Rows[i]["MAHOSO"].ToString();
                h.Loaitl = dt.Rows[i]["LOAITL"].ToString();
                int.TryParse(dt.Rows[i]["BIENMUC"].ToString(), out bienmuc);
                h.Bienmuc = bienmuc;
                h.Tenhoso = dt.Rows[i]["TENHOSO"].ToString();
                h.Mahoso = dt.Rows[i]["MAHOSO"].ToString();
                
                int.TryParse(dt.Rows[i]["SLTO"].ToString(), out slto);
                h.Slto = slto;
                h.Ghichu = dt.Rows[i]["GHICHU"].ToString();
                h.Thoigians = dt.Rows[i]["THOIGIANS"].ToString();
                h.Thoigiane = dt.Rows[i]["THOIGIANE"].ToString();
                listhoso.Add(h);
            }
            return listhoso;
        }
        
    }
}