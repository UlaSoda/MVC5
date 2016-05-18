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
        public PartialViewResult Index()
        {
            //return View();
            return PartialView();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ContentResult ContentResult()
        {
            //return Content("<ROOT><TEXT>123</TEXT></ROOT>", "text/xml", System.Text.Encoding.UTF8);
            return (Content("<ROOT><TEXT>123</TEXT></ROOT>", "text/plain",System.Text.Encoding.UTF8));
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
        //URL檔案路徑 強迫下載並存成指定檔案名稱 需輸入url / filenaame
        //參數直接加在網址後面 url / filenaame有預設值
        public ActionResult File4(string url = "https://www.google.com.tw/images/srpr/logo11w.png", string fileName = "Google.png")
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            return File(data, "Image/png", fileName);
        }
        public ActionResult ForceDownloadFile()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            if(Request.Browser.Browser == "IE" && Convert.ToInt32(Request.Browser.MajorVersion) < 9)
            {
                return File(data, "image/png", Server.UrlPathEncode("谷哥.png"));

            }
            else
            {
                return File(data, "image/png", "谷哥.png");

            }
        }
        public ActionResult File5()
        {
            return File(Server.MapPath("~/Content/Yahoo.html"), "text/html");
        }
        public ActionResult File6()//跑純文字
        {
            return File(Server.MapPath("~/Content/Yahoo.html"), "text/plain");
        }
        public ActionResult Json1()
        {
            return Json(new
            {
                id = 1,
                name = "hung",
                Createdon = DateTime.Now,
                Richard = "bai"
            },JsonRequestBehavior.AllowGet);//預設不允許get
        }

        


    }
}