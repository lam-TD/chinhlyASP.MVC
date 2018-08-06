using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chinhlytailieu.Models.chinhly;

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

        public ActionResult nhaphosothem()
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
                    if (dataAsset.data.inputdata("mucluc_them", namepara1, valuepara1))
                    { result = "1"; }
                    else { result = "-1"; }
                    break;
                case 2:
                    string[] namepara2 = { "@MAMUCLUC", "@PHONGID", "@TENMUCLUC", "@MOTA", "@GHICHU" };
                    object[] valuepara2 = { ml.Mamucluc, ml.Phongid, ml.Tenmucluc, mota, ghichu };
                    if (dataAsset.data.inputdata("mucluc_sua", namepara2, valuepara2)) { result = "1"; }
                    else { result = "-1"; }
                    break;
            }
            return Json(1, JsonRequestBehavior.AllowGet);
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

        public JsonResult nhapmucluc_checkmamucluc(int id)
        {
            int result;
            string[] namepara = { "@mamucluc" };
            object[] valuepara = { id };
            DataTable dt = dataAsset.data.outputdataTable("mucluc_checkma", namepara, valuepara);
            if (dt.Rows.Count > 0)
            { result = 1; }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
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
        public string hoso_load(int phongid)
        {
            string[] namepara = { "@phongid" };
            object[] valuepara = { phongid };
            return dataAsset.data.outputdata("hoso_load", namepara, valuepara);
        }

        public JsonResult hoso_them(hoso h, int hopid = 0)
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
                string[] namepara = { "@PHONGID", "@MUCLUC", "@MAHOP", "@LOAITL", "@MAHOSO", "@TENHOSO", "@NAMLAP", "@CHUGIAI", "@THOIGIANS", "@THOIGIANE", "@NGONNGU", "@SLTO", "@HCSD", "@TINHTRANG", "@GHICHU", "@BIENMUC" };
                object[] valuepara = { h.Phongid, h.Mucluc, "", h.Loaitl, h.Mahoso, h.Tenhoso, h.Namlap, chugiai, h.Thoigians, h.Thoigiane, ngonngu, h.Slto, h.Hcsd, tinhtrang, ghichu, h.Bienmuc };
                if (dataAsset.data.inputdata("hoso_them", namepara, valuepara))
                {
                    result = 1;
                }
                else { result = -1; }
            }
            else { result = 0; }
            
            return Json(result, JsonRequestBehavior.AllowGet);
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
            if (mangmahop[4] != ""){hopid = int.Parse(mangmahop[4]);}

            // hop cu
            string mahopcu = mangmahop[0].ToString();
            int muclucidcu = int.Parse(mangmahop[2]);


            if ((mahopcu != mahop && mahopcu != "") || (mahopcu == "" && mahop != "" && mahopcu != mahop))
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



        public int hoso_check_idhoso(int mahoso, int phongid)
        {
            string[] namepara = { "@mahoso", "@phongid" };
            object[] valuepara = { mahoso, phongid };
            int result;
            DataTable dt = dataAsset.data.outputdataTable("hoso_check_idhoso", namepara, valuepara);
            if (dt.Rows.Count > 0)
            {
                result = 1; 
            }
            else { return -1; }
            return result;
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
            string result;
            DataTable dt = dataAsset.data.outputdataTable("hoso_idlast");
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["MAHOP"].ToString();
            }
            else { result = "HOP-1"; }
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

        public JsonResult vanban_them(vanban v, int hosoid)
        {
            int result = -1;
            DateTime date = DateTime.Parse(v.Thoigian);
            string tg = date.ToString("dd-MM-yyy");
            string ghichu = "", ngonngu = "", tacgia = "";
            if (v.Ghichu != null) { ghichu = v.Ghichu; }
            if (v.Ngonngu != null) { ngonngu = v.Ngonngu; }
            if (v.Tacgia != null) { tacgia = v.Tacgia; }
            string[] namepara = { "@HOSOID", "@TOSO", "@SLTO", "@SUDUNG", "@SOKYHIEU", "@THOIGIAN", "@TACGIA", "@TENLOAI", "@TRICHYEU", "@KYHIEU", "@NGOCNGU", "@BUTTICH", "@GHICHU" };
            object[] valuepara = { hosoid, v.Toso, v.Slto, v.Sudung, v.Sokyhieu, tg, tacgia, v.Tenloai, v.Trichyeu, "", ngonngu, v.Buttich, ghichu };
            if (dataAsset.data.inputdata("vanban_them", namepara, valuepara))
            {
                result = 1;
            }
            else { result = -1; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult vanban_sua(vanban v)
        {
            int result = -1;
            string ghichu = "", ngonngu = "", tacgia = "";
            if (v.Ghichu != null) { ghichu = v.Ghichu; }
            if (v.Ngonngu != null) { ngonngu = v.Ngonngu; }
            if (v.Tacgia != null) { tacgia = v.Tacgia; }
            string[] namepara = { "@ID","@HOSOID", "@TOSO", "@SLTO", "@SUDUNG", "@SOKYHIEU", "@THOIGIAN", "@TACGIA", "@TENLOAI", "@TRICHYEU", "@KYHIEU", "@NGOCNGU", "@BUTTICH", "@GHICHU" };
            object[] valuepara = { v.Id, v.Hosoid, v.Toso, v.Slto, v.Sudung, v.Sokyhieu, v.Thoigian, tacgia, v.Tenloai, v.Trichyeu, "", ngonngu, v.Buttich, ghichu };
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

        public string hoso_hschuavaohop(int phongid)
        {
            string[] namepara = { "@PHONGID" };
            object[] valuepara = { phongid };
            return dataAsset.data.outputdata("hoso_hschuavaohop", namepara, valuepara);
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

        public void session_keyword(string keyword) {
            Session["keyword"] = keyword.Trim();
        }
        public string get_sesion_keyword()
        {
            if (Session["keyword"] == null)
                return null;
            else
                return Session["keyword"].ToString();
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
            Session["keyword"] = keyword.Trim();
            string[] namepara = { "@keyword" };
            object[] valuepara = { keyword.Trim() };
            return dataAsset.data.outputdata("chinhly_timkiemvanban", namepara, valuepara);
        }
    }
}