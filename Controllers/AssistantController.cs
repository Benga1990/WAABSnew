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

namespace WAABSnew
{
    public class AssistantController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: Assistant
        public ActionResult Index()
        {
            return View(db.AssistantModels.ToList());
        }

        // GET: Assistant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssistantModel assistantModel = db.AssistantModels.Find(id);
            if (assistantModel == null)
            {
                return HttpNotFound();
            }
            return View(assistantModel);
        }

        // GET: Assistant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assistant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Confrimed,StageDetails,OtherUserConfirmed")] AssistantModel assistantModel)
        {
            if (ModelState.IsValid)
            {
                db.AssistantModels.Add(assistantModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assistantModel);
        }

        // GET: Assistant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssistantModel assistantModel = db.AssistantModels.Find(id);
            if (assistantModel == null)
            {
                return HttpNotFound();
            }
            return View(assistantModel);
        }

        // POST: Assistant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Confrimed,StageDetails,OtherUserConfirmed")] AssistantModel assistantModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assistantModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assistantModel);
        }

        // GET: Assistant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssistantModel assistantModel = db.AssistantModels.Find(id);
            if (assistantModel == null)
            {
                return HttpNotFound();
            }
            return View(assistantModel);
        }

        // POST: Assistant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssistantModel assistantModel = db.AssistantModels.Find(id);
            db.AssistantModels.Remove(assistantModel);
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
