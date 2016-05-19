using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class BaseController : Controller
    {
        public FabricsEntities db = new FabricsEntities();
        // GET: Base
        protected override void HandleUnknownAction(string actionName)
        {
            if(this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                //this.View(actionName).ExecuteResult(this.ControllerContext);
                try
                {
                    this.View(actionName).ExecuteResult(this.ControllerContext);
                }
                catch (InvalidOperationException ieox)
                {
                    /*ViewData["error"] = "Unknown Action: \"" +
                        Server.HtmlEncode(actionName) + "\"";
                    ViewData["exMessage"] = ieox.Message;
                    this.View("Error").ExecuteResult(this.ControllerContext);*/
                }
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }



        }
    }
}