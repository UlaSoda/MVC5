using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /*
        [HttpPost]
        public ActionResult Simple1(string username, string password , string ConfirmPassword)
        {
            return Content(username + "/" + password + "/" + ConfirmPassword);

        }*/
        /*
        public ActionResult Simple2(FormCollection form)
        {
            return Content(form["username"] + "/" + form["password"]);
        }*/

        [HttpPost]
        public ActionResult Simple2(FormCollection form)
        {
            return Content(form["user"] + "/" + form["password"]);
        }
        public ActionResult Complex1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex1(SimpleViewModel item1)
        {
            return Content("Complex1 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword);
        }


        public ActionResult Complex2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex2(SimpleViewModel item1 , SimpleViewModel item2)
        {
            return Content("Complex1 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword 
                + "Complex2 : " + item2.UserName + "/" + item2.Password + "/" + item2.ConfirmPassword);
        }

        public ActionResult Complex2ex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex2ex(SimpleViewModel item1, SimpleViewModel item2)
        {
            return Content("Complex1 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword
                + "Complex2 : " + item2.UserName + "/" + item2.Password + "/" + item2.ConfirmPassword);
        }

        public ActionResult Complex3()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Complex3(
            [Bind(Prefix = "item")]
            SimpleViewModel item1)//對外宣稱為item  可已改名
        {
            return Content("Complex3 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword);
        }

        public ActionResult Complex4()
        {
            var data = from p in db.Client
                       select new SimpleViewModel
                       {
                            UserName = p.FirstName,
                            Password = p.LastName,
                            ConfirmPassword = p.MiddleName
                       };
            return View(data.Take(10)); 
        }
        [HttpPost]
        public ActionResult Complex4(IList<SimpleViewModel> item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Complex4 : ");
            for (int i = 0; i < item.Count; i++)
            {
                sb.Append(item[i].UserName + " / " + item[i].Password + "/" + item[i].ConfirmPassword);
                if (i < item.Count - 1)
                {
                    sb.Append("<br />");
                }
            }
            return Content(sb.ToString());


        }

    }
}