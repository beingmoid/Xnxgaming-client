using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XnxGaming.Models
{
    public class SessionAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Url.ToString();
            HttpContext.Current.Session["ReturnUrl"] = url;

            if (HttpContext.Current.Session["token"] == null)
            {
                filterContext.Result = new RedirectResult("~\\Account\\Login"); //ActionName
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}