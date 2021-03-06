﻿using System;
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
    public class BuyerModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: BuyerModels
        public ActionResult Index()
        {
            return View(db.BuyerModels.ToList());
        }

        // GET: BuyerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerModel buyerModel = db.BuyerModels.Find(id);
            if (buyerModel == null)
            {
                return HttpNotFound();
            }
            return View(buyerModel);
        }

        // GET: BuyerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyerModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,JoinDate,InProcess")] BuyerModel buyerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BuyerModels.Add(buyerModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(buyerModel);
        }

        // GET: BuyerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerModel buyerModel = db.BuyerModels.Find(id);
            if (buyerModel == null)
            {
                return HttpNotFound();
            }
            return View(buyerModel);
        }

        // POST: BuyerModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,JoinDate,InProcess")] BuyerModel buyerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyerModel);
        }

        // GET: BuyerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerModel buyerModel = db.BuyerModels.Find(id);
            if (buyerModel == null)
            {
                return HttpNotFound();
            }
            return View(buyerModel);
        }

        // POST: BuyerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyerModel buyerModel = db.BuyerModels.Find(id);
            db.BuyerModels.Remove(buyerModel);
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
