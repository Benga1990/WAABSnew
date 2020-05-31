using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WAABSnew.DataAccessLayer;
using WAABSnew.Models;

namespace WAABSnew.Controllers
{
    public class SellerModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: SellerModels
        public ActionResult Index()
        {
            return View(db.SellerModels.ToList());
        }

        // GET: SellerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerModel sellerModel = db.SellerModels.Find(id);
            if (sellerModel == null)
            {
                return HttpNotFound();
            }
            return View(sellerModel);
        }

        // GET: SellerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,JoinDate,InProcess")] SellerModel sellerModel)
        {
            if (ModelState.IsValid)
            {
                db.SellerModels.Add(sellerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellerModel);
        }

        // GET: SellerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerModel sellerModel = db.SellerModels.Find(id);
            if (sellerModel == null)
            {
                return HttpNotFound();
            }
            return View(sellerModel);
        }

        // POST: SellerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,JoinDate,InProcess")] SellerModel sellerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellerModel);
        }

        // GET: SellerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerModel sellerModel = db.SellerModels.Find(id);
            if (sellerModel == null)
            {
                return HttpNotFound();
            }
            return View(sellerModel);
        }

        // POST: SellerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellerModel sellerModel = db.SellerModels.Find(id);
            db.SellerModels.Remove(sellerModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
