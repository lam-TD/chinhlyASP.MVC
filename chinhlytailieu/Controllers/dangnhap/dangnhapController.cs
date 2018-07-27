using System.Web.Mvc;
using chinhlytailieu.Models.users;
using System.Web;
using System.Data;

namespace chinhlytailieu.Controllers.dangnhap
{
    [AllowAnonymous]
    public class dangnhapController : Controller
    {
        // GET: dangnhap
        public ActionResult login()
        {
            return View();
        }

        public ActionResult dangky()
        {
            return View();
        }

        //dang nhap->xac dinh nhom user->nhom->nhom chuc nang
        public JsonResult dangnhap(nguoidung u)
        {
            string result = "-1";
            string[] name_para = { "@username", "@password" };
            string password = dataAsset.data.encryption(u.Password);
            object[] value_para = new object[]{ u.Username, password };
            DataTable dt = dataAsset.data.outputdataTable("dn_login", name_para, value_para);
            if (dt.Rows.Count > 0)
            {
                bool flag = bool.Parse(dt.Rows[0]["KHOA"].ToString());
                if (!bool.Parse(dt.Rows[0]["KHOA"].ToString()))
                {
                    Session["username"] = u.Username;
                    result = "1";
                }
                else { Session["username"] = u.Username; result = "0"; }
                
            }
            else { result = "-1"; }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public int dangxuat()
        {
            Session.Clear();
            return 1;
        }

        public JsonResult nhomchucnang()
        {
            return Json("dasd", JsonRequestBehavior.AllowGet);
        }
    }
}