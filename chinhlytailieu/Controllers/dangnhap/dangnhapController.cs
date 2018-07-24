using System.Web.Mvc;
using chinhlytailieu.Models.users;
using System.Web;

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
            if (data.data.login("dn_login",name_para,value_para))
            {
                //sessionhelper.SetSession(new userSession() { Username = u.Username });
                Session["username"] = u.Username; 
                result = "1";
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