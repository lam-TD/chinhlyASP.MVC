using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chinhlytailieu.data;
using chinhlytailieu.dataAsset;
using System.Data;
using chinhlytailieu.Models;
using chinhlytailieu.Models.admin;
using chinhlytailieu.Models.users;

namespace chinhlytailieu.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public string userInfo(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { Session["username"].ToString() };
            return dataAsset.data.outputdata("dn_userInfo", namepara, valuepara);
        }

        public JsonResult PhanQuyen()
        {
            string[] namepara = { "@username" };
            object[] valuepara = { Session["username"].ToString() };
            DataTable dtChucNang = dataAsset.data.outputdataTable("dn_userInfo", namepara,valuepara);
            // get admin
            DataTable dtModule = dataAsset.data.outputdataTable("all_chucnang");
            
            List<Models.pq.pq> module = new List<Models.pq.pq>();
            for (int i = 0; i < dtChucNang.Rows.Count; i++)
            {
                string cn = dtChucNang.Rows[i]["CHUCNANGID"].ToString();
                string quyen = dtChucNang.Rows[i]["ALLACTION"].ToString();
                string them = dtChucNang.Rows[i]["THEM"].ToString();
                for (int j = 0; j < dtModule.Rows.Count; j++)
                {
                    string id_dd = dtModule.Rows[j]["Id_chucnang"].ToString();
                    if (cn == dtModule.Rows[j]["Id_chucnang"].ToString()) // neu dung ghi nhan
                    {
                        module.Add(new Models.pq.pq {
                            Id_Module         = dtModule.Rows[i]["Id_Module"].ToString(),
                            Name_Module       = dtModule.Rows[i]["ModuleName"].ToString(),
                            Num_OrderModule   = dtModule.Rows[i]["NumOrder_Module"].ToString(),
                            Link_Module       = dtModule.Rows[i]["Links_Module"].ToString(),
                            Id_NhomChucNang   = dtModule.Rows[i]["Id_nhomcn"].ToString(),
                            Name_NhomChucNang = dtModule.Rows[i]["Ten_Nhomcn"].ToString(),
                            Id_ChucNang       = dtModule.Rows[i]["Id_ChucNang"].ToString(),
                            Name_ChucNang     = dtModule.Rows[i]["TENCHUCNANG"].ToString(),
                            All_Action        = dtChucNang.Rows[i]["ALLACTION"].ToString(),
                            Xem               = dtChucNang.Rows[i]["xem"].ToString(),
                            Them              = dtChucNang.Rows[i]["Them"].ToString(),
                            Sua               = dtChucNang.Rows[i]["Sua"].ToString(),
                            Xoa               = dtChucNang.Rows[i]["Xoa"].ToString(),
                        });
                    }
                }
            }
            return Json(module, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getUserInfo()
        {
            string[] namepara = { "@username" };
            object[] valuepara = { Session["username"].ToString() };
            List<nguoidung> m = new List<nguoidung>();
            DataTable dt = dataAsset.data.outputdataTable("dn_userInfo", namepara, valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nguoidung u = new nguoidung();
                u.Id = dt.Rows[i]["ID"].ToString();
                u.Username = dt.Rows[i]["USERNAME"].ToString();
                u.Password = dt.Rows[i]["PASSWORD"].ToString();
                u.Email = dt.Rows[i]["EMAIL"].ToString();
                u.Holot = dt.Rows[i]["HOLOT"].ToString();
                u.Ten = dt.Rows[i]["TEN"].ToString();
                u.Ngaytao = dt.Rows[i]["NGAYTAO"].ToString();
                bool khoa = false;
                if(dt.Rows[i]["KHOA"].ToString() == "1") { khoa = true; } else { khoa = false; }
                u.Khoa = khoa;
                u.Chucvu = dt.Rows[i]["HOLOT"].ToString();
                u.Bophan = dt.Rows[i]["BOPHAN"].ToString();
                u.Uyquyen = dt.Rows[i]["UYQUYEN"].ToString();
                u.Ngayuyquyen = dt.Rows[i]["NGAYUQ"].ToString();
                u.Ketthucuyquyen = dt.Rows[i]["KETTHUCUQ"].ToString();
                bool hanche = false;
                if (dt.Rows[i]["KHOA"].ToString() == "1") { hanche = true; } else { hanche = false; }
                u.Hanche = hanche;
                u.Fileanh = dt.Rows[i]["FILEANH"].ToString();
                m.Add(u);
            }
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        public string module()
        {
            DataTable dt = dataAsset.data.outputdataTable("module_load");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //return dt.Rows[i]["ModuleName"].ToString();
                Console.Write(dt.Rows[i]["ModuleName"]);
            }
            return "sds";
        }

        public string user_module()
        {
            string[] namepara = { "@username" };
            object[] valuepara = { Session["username"].ToString() };
            return dataAsset.data.outputdata("user_module", namepara, valuepara);
        }

        public string user_nhomchucnang()
        {
            string[] namepara = { "@username" };
            object[] valuepara = { Session["username"].ToString() };
            return dataAsset.data.outputdata("user_nhomchucnang", namepara, valuepara);
        }

        public JsonResult user_module_list()
        {
            List<module> m = new List<module>();
            DataTable dt = new DataTable();
            if (Session["username"].ToString() == "admin")
            {
                dt = dataAsset.data.outputdataTable("user_module_all");
            }
            else
            {
                string[] namepara = { "@username" };
                object[] valuepara = { Session["username"].ToString() };
                dt = dataAsset.data.outputdataTable("user_module", namepara, valuepara);
            }
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m.Add(new module
                {
                    Id = int.Parse(dt.Rows[i]["Id_Module"].ToString()),
                    Modulename = dt.Rows[i]["ModuleName"].ToString(),
                    Imagepath = dt.Rows[i]["Image_Module"].ToString(),
                    Numoder = int.Parse(dt.Rows[i]["NumOrder_Module"].ToString()),
                    Links = dt.Rows[i]["Links_Module"].ToString()
                });
            }
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        // kiem tra nguoi dung co quyen truy cap link chuc nang
        public JsonResult checkUrlUser(string link)
        {
            string result = string.Empty;
            try
            {
                string[] namepara = { "@username", "@linkchucnang" };
                object[] valuepara = { Session["username"].ToString(), link };
                DataTable dt = dataAsset.data.outputdataTable("checkUrlUser", namepara, valuepara);
                if (dt.Rows.Count > 0)
                {
                    result = "1";  
                }
            }
            catch (Exception)
            {
                result = "-1";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}