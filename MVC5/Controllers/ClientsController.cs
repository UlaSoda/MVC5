using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class ClientsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();

        ClientRepository ClientRepo = RepositoryHelper.GetClientRepository(); //db.Client
        OccupationRepository occuRepo = RepositoryHelper.GetOccupationRepository();//db.Occ  

        // GET: Clients
        public ActionResult Index()
        {
            //var client = db.Client.Include(c => c.Occupation).Take(10);
            var client = ClientRepo.All();

            return View(client.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Client.Find(id);
            Client client = ClientRepo.Find(id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
           
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            //ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName");
            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName");

            return View();
        }

        // POST: Clients/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                //db.Client.Add(client);

                ClientRepo.Add(client);
                ClientRepo.UnitOfWork.Commit();
                /*
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                */
                return RedirectToAction("Index");
            }

            //ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Client.Find(id);
            Client client = ClientRepo.Find(id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);

            return View(client);
        }

        // POST: Clients/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(client).State = EntityState.Modified;
                //db.SaveChanges();
                ClientRepo.UnitOfWork.Context.Entry(client).State = EntityState.Modified;
                ClientRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(occuRepo.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Client.Find(id);
            Client client = ClientRepo.Find(id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Client client = db.Client.Find(id);
            Client client = ClientRepo.Find(id);
            /*
            var order = client.Order;
            foreach (var item in order)
            {
                var OrderLine = item.OrderLine;
                db.OrderLine.RemoveRange(OrderLine);
            }
            db.Order.RemoveRange(order);*/


            /*
            foreach (var ord in client.Order.ToList())
            {
                var ol = ord.OrderLine;
                db.OrderLine.RemoveRange(ol);
                //db.Order.Remove(ord);            
            }*/
            //db.Order.RemoveRange(client.Order);
            //db.Client.Remove(client);
            //db.SaveChanges();
            ClientRepo.Delete(client);
            ClientRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                ClientRepo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
