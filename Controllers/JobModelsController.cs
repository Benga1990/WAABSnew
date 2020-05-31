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
    public class JobModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: JobModels
        public ActionResult Index()
        {
            return View(db.JobModels.ToList());
        }

        // GET: JobModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobModel = db.JobModels.Find(id);
            if (jobModel == null)
            {
                return HttpNotFound();
            }
            return View(jobModel);
        }

        // GET: JobModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BuyerID,SellerID,BankID,EstateAgentID,SolicitorID")] JobModel jobModel)
        {
            if (ModelState.IsValid)
            {
                db.JobModels.Add(jobModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobModel);
        }

        // GET: JobModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobModel = db.JobModels.Find(id);
            if (jobModel == null)
            {
                return HttpNotFound();
            }
            return View(jobModel);
        }

        // POST: JobModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BuyerID,SellerID,BankID,EstateAgentID,SolicitorID")] JobModel jobModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobModel);
        }

        // GET: JobModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobModel jobModel = db.JobModels.Find(id);
            if (jobModel == null)
            {
                return HttpNotFound();
            }
            return View(jobModel);
        }

        // POST: JobModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobModel jobModel = db.JobModels.Find(id);
            db.JobModels.Remove(jobModel);
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
