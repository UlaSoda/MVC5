using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class ViewsController : BaseController
    {
        // GET: Views
        public ActionResult Index()
        {
            //return View();
            return PartialView();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult ContentResult()
        {
            return Content("<ROOT><TEXT>123</TEXT></ROOT>", "text/xml", System.Text.Encoding.UTF8);
            //return (Content("<ROOT><TEXT>123</TEXT></ROOT>", "text/plain",System.Text.Encoding.UTF8));
        }
        public ActionResult File1()
        {
            //return File(Server.MapPath("~/App_Data/Google.png"), "image/png");
            return File(Server.MapPath("~/App_Data/Google.png"), "image/png");
        }
        public ActionResult File2()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            return File(data, "Image/png");
        }
        public ActionResult File3()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            return File(data, "Image/png", "Google.png");
        }
    }
}