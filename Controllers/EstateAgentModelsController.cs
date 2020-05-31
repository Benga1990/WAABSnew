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
    public class EstateAgentModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: EstateAgentModels
        public ActionResult Index()
        {
            return View(db.EstateAgentModels.ToList());
        }

        // GET: EstateAgentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstateAgentModel estateAgentModel = db.EstateAgentModels.Find(id);
            if (estateAgentModel == null)
            {
                return HttpNotFound();
            }
            return View(estateAgentModel);
        }

        // GET: EstateAgentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstateAgentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] EstateAgentModel estateAgentModel)
        {
            if (ModelState.IsValid)
            {
                db.EstateAgentModels.Add(estateAgentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estateAgentModel);
        }

        // GET: EstateAgentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstateAgentModel estateAgentModel = db.EstateAgentModels.Find(id);
            if (estateAgentModel == null)
            {
                return HttpNotFound();
            }
            return View(estateAgentModel);
        }

        // POST: EstateAgentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] EstateAgentModel estateAgentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estateAgentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estateAgentModel);
        }

        // GET: EstateAgentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstateAgentModel estateAgentModel = db.EstateAgentModels.Find(id);
            if (estateAgentModel == null)
            {
                return HttpNotFound();
            }
            return View(estateAgentModel);
        }

        // POST: EstateAgentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstateAgentModel estateAgentModel = db.EstateAgentModels.Find(id);
            db.EstateAgentModels.Remove(estateAgentModel);
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
