using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace chinhlytailieu.Helper
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            ////Check to see if we need to skip authentication
            //if (ctx.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
            //        || ctx.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            //    return;

            ////If it's not even authenticated redirect to a login action
            ////  ...remember, you need [AllowAnonymous] on Login action to prevent an endless redirect loop

            //if (!ctx.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    ctx.Result = new RedirectToRouteResult(
            //                     new RouteValueDictionary(new { controller = "dangnhap", action = "login" })
            //                 );
            //    return;
            //}
            //else
            //{
            //    //Get controller and action for custom, per action, validation
            //    var controllerName = ctx.ActionDescriptor.ControllerDescriptor.ControllerName;
            //    var actionName = ctx.ActionDescriptor.ActionName;
            //    string link = "!#" + actionName;
            //    var username = Session["username"].ToString();
            //    if (phanquyen.checkUrlUser(username, link))
            //    {
            //        ctx.Result = new RedirectToRouteResult(
            //                         new RouteValueDictionary(new { controller = controllerName, action = actionName })
            //        );
            //        return;
            //    }
            //    else
            //    {
            //        RedirectToAction("ERRO_502", "error");
            //    }
            //}

            base.OnActionExecuting(ctx);
            
            var controllerName = ctx.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = ctx.ActionDescriptor.ActionName;
            if (actionName != "index" && actionName != "chucnang")
            {
                string link = "!#" + actionName;
                var username = Session["username"].ToString();
                if (phanquyen.checkUrlUser(username, link))
                {
                    ctx.Result = new RedirectToRouteResult(
                                     new RouteValueDictionary(new { controller = controllerName, action = actionName })
                    );
                    return;
                }
                else
                {
                    ctx.Result = new RedirectToRouteResult(
                                     new RouteValueDictionary(new { controller = "error", action = "ERRO_502" })
                    );
                    return;
                }
            }
            
        }
    }
}