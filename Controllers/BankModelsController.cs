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
    public class BankModelsController : Controller
    {
        private WAABSContext db = new WAABSContext();

        // GET: BankModels
        public ActionResult Index(string sortOrder)
        {
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                var users = from s in db.BankModels
                               select s;
                switch (sortOrder)
                {
                    case "name_desc":
                        users = users.OrderByDescending(s => s.LastName);
                        break;
                    case "Date":
                        users = users.OrderBy(s => s.JoinDate);
                        break;
                    case "date_desc":
                        users = users.OrderByDescending(s => s.JoinDate);
                        break;
                    default:
                        users = users.OrderBy(s => s.LastName);
                        break;
                }
                return View(db.BankModels.ToList());
        }

        // GET: BankModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankModel bankModel = db.BankModels.Find(id);
            if (bankModel == null)
            {
                return HttpNotFound();
            }
            return View(bankModel);
        }

        // GET: BankModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] BankModel bankModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BankModels.Add(bankModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(bankModel);
        }

        // GET: BankModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankModel bankModel = db.BankModels.Find(id);
            if (bankModel == null)
            {
                return HttpNotFound();
            }
            return View(bankModel);
        }

        // POST: BankModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,LastName,FirstName,JoinDate")] BankModel bankModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankModel);
        }

        // GET: BankModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankModel bankModel = db.BankModels.Find(id);
            if (bankModel == null)
            {
                return HttpNotFound();
            }
            return View(bankModel);
        }

        // POST: BankModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankModel bankModel = db.BankModels.Find(id);
            db.BankModels.Remove(bankModel);
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
