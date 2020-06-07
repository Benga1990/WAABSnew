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
    public class SolicitorModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: SolicitorModels
        public ActionResult Index()
        {
            return View(db.SolicitorModels.ToList());
        }

        // GET: SolicitorModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitorModel solicitorModel = db.SolicitorModels.Find(id);
            if (solicitorModel == null)
            {
                return HttpNotFound();
            }
            return View(solicitorModel);
        }

        // GET: SolicitorModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] SolicitorModel solicitorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SolicitorModels.Add(solicitorModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(solicitorModel);
        }

        // GET: SolicitorModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitorModel solicitorModel = db.SolicitorModels.Find(id);
            if (solicitorModel == null)
            {
                return HttpNotFound();
            }
            return View(solicitorModel);
        }

        // POST: SolicitorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] SolicitorModel solicitorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitorModel);
        }

        // GET: SolicitorModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitorModel solicitorModel = db.SolicitorModels.Find(id);
            if (solicitorModel == null)
            {
                return HttpNotFound();
            }
            return View(solicitorModel);
        }

        // POST: SolicitorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitorModel solicitorModel = db.SolicitorModels.Find(id);
            db.SolicitorModels.Remove(solicitorModel);
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
