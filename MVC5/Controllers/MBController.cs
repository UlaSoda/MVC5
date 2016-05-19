using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData.Model = db.Product.Find(10);

            ViewData["Product"] = db.Product.Find(121);

            ViewBag.Product2 = db.Product.Find(223);

            return View();
        }

        public ActionResult TempData1()//放在Index就可以?!!!!有空研究....
        {
            ViewData["Message1"] = "Hello World 1";
            TempData["Message2"] = "Hello World 2";
            Session["Message3"] = "Hello World 3";
            return RedirectToAction("TempDate2");
        }
        public ActionResult TempDate2()
        {
            ViewData["Message1"] = ViewData["Message1"];
            ViewData["Message2"] = TempData["Message2"];
            ViewData["Message3"] = Session["Message3"];

            return View();

        }

        public ActionResult Simple1()
        {
            return View();
        }
        public ActionResult Simple2()
        {
            return View("Simple1");
        }
        [HttpPost]
        /*public ActionResult Simple1(string username, string password , string ConfirmPassword)
        {
            return Content(username + "/" + password + "/" + ConfirmPassword);

        }*/
        public ActionResult Simple2(FormCollection form)///////////
        {
            return Content(form["username"] + "/" + form["password"]);
        }
    }
}