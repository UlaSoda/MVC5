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
        public ActionResult Index()//未跨action，無轉址動作
        {
            //搜尋產品編號為10的產品
            //以強型別傳值
            ViewData.Model = db.Product.Find(10);
            //弱型別傳值 
            ViewData["Product"] = db.Product.Find(121);
            //使用動態型別，骨子裡用的是ViewData
            ViewBag.Product2 = db.Product.Find(223);

            return View();
        }

        public ActionResult TempData1()//實作TempData1→TempDate2 ，有轉址動作(跨action)
        {
            //只存在單一action
            ViewData["Message1"] = "Hello World 1";
            //可跨action
            //讀取一次後立即刪除，除非一直未被讀取，直到網站重啟
            TempData["Message2"] = "Hello World 2";
            //可跨action
            Session["Message3"] = "Hello World 3";

            return RedirectToAction("TempDate2");
        }
        public ActionResult TempDate2()
        {
            //因為轉址的關係，此訊息不存在
            ViewData["Message1"] = ViewData["Message1"];
            //第一次進來網站可看到訊息，f5訊息消失
            ViewData["Message2"] = TempData["Message2"];
            //訊息不消失
            ViewData["Message3"] = Session["Message3"];

            return View();

        }
        //*簡單模型繫結->2way->可在Action 裡驗證模型繫結結果
        //DefaultModelBinder : int,bool,string,datatime....

        //1.使用C# 基礎型別取得表單欄位資料(新增SimpleViewModel.cs)
        public ActionResult Simple1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Simple1(string username, string password, string confirmPassword)
        {
            //傳入的變數名稱等同欄位名稱(無論大小寫),模組繫結會自動判斷
            return Content(username + "/" + password + "/" + confirmPassword);
        }

        //2.使用FormCollection 取得表單所有欄位資料 - 使用NameValueCollection(key->value?!) 型別接入變數
        public ActionResult Simple2()
        {
            return View("Simple1");//直接利用Simple1的view
        }
        [HttpPost]
        public ActionResult Simple2(FormCollection form)
        {
            //傳入的變數名稱等同欄位名稱(無論大小寫),模組繫結會自動判斷
            return Content(form["username"] + "/" + form["password"]);
        }


        //*複雜模型繫結->使用任意.NET 型別->會在Action 前預先判斷模型繫結的驗證結果
        //DefaultModelBinder :  任何物件屬性都能繫結,可以繫結陣列物件

        //單一表單直接傳入，無須理會變數名稱->僅新增檢視(ex model.UserName)
        public ActionResult Complex1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex1(SimpleViewModel item1)
        {
            return Content("Complex1 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword);
        }

        //若同時送出多個表單同名欄位，需額外設定個欄位的name
        //以此例子來說，個欄位前面需前綴詞(prefix)item1/item2->複製complex1之檢視*2(ex item1.UserName)
        //讓模組繫結知道屬於哪一個表單的欄位
        public ActionResult Complex2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex2(SimpleViewModel item1 , SimpleViewModel item2)
        {
            return Content("Complex1 : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword + "<br/>"
                + "Complex2 : " + item2.UserName + "/" + item2.Password + "/" + item2.ConfirmPassword);
        }
        //複製simple1結果的html修改
        public ActionResult Complex2ex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complex2ex(SimpleViewModel item1, SimpleViewModel item2)
        {
            return Content("Complex1ex : " + item1.UserName + "/" + item1.Password + "/" + item1.ConfirmPassword + "<br/>"
                + "Complex2ex : " + item2.UserName + "/" + item2.Password + "/" + item2.ConfirmPassword);
        }
        //強迫前綴詞要item,即item.欄位名稱(ex item.UserName)
        public ActionResult Complex3()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Complex3(
            [Bind(Prefix = "item")]
            SimpleViewModel item123)//對外宣稱為item  可以改名
        {
            return Content("Complex3 : " + item123.UserName + "/" + item123.Password + "/" + item123.ConfirmPassword);
        }
        //從Client資料表內取得資料,並轉成SimpleViewModel類別，一併將該類別屬性填入資料
        public ActionResult Complex4()
        {
            var data = from p in db.Client
                       select new SimpleViewModel
                       {
                            UserName = p.FirstName,
                            Password = p.LastName,
                            ConfirmPassword = p.MiddleName
                       };
            return View(data.Take(3)); 
        }
        //因為IList<T>,強迫前綴詞要item,即item.欄位名稱
        [HttpPost]
        public ActionResult Complex4(IList<SimpleViewModel> item)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Complex4 : ");
            //if(item != null)
            //    sb.Append(item[0].UserName);
            
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