using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers
{
    public class chucnangController : Controller
    {
        // GET: chucnang
        public JsonResult checkUrlUser(string url)
        {
            string result = string.Empty;
            if (Session["username"] == null)
            {
                result = "-1";
            }
            else
            {
                string path = url;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}