using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers
{
    public class CustomNeedTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomNeedTypes
        public ActionResult Index()
        {
            var customNeedTypes = db.CustomNeedTypes/*.Include(c => c.Organization)*/;
            return View(customNeedTypes.ToList());
        }

        // GET: CustomNeedTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomNeedType customNeedType = db.CustomNeedTypes.Find(id);
            if (customNeedType == null)
            {
                return HttpNotFound();
            }
            return View(customNeedType);
        }

        // GET: CustomNeedTypes/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name");
            return View();
        }

        // POST: CustomNeedTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomNeedTypeId,Description,OrganizationId")] CustomNeedType customNeedType)
        {
            if (ModelState.IsValid)
            {
                customNeedType.CustomNeedTypeId = Guid.NewGuid();
                db.CustomNeedTypes.Add(customNeedType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", customNeedType.OrganizationId);
            return View(customNeedType);
        }

        // GET: CustomNeedTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomNeedType customNeedType = db.CustomNeedTypes.Find(id);
            if (customNeedType == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", customNeedType.OrganizationId);
            return View(customNeedType);
        }

        // POST: CustomNeedTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomNeedTypeId,Description,OrganizationId")] CustomNeedType customNeedType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customNeedType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", customNeedType.OrganizationId);
            return View(customNeedType);
        }

        // GET: CustomNeedTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomNeedType customNeedType = db.CustomNeedTypes.Find(id);
            if (customNeedType == null)
            {
                return HttpNotFound();
            }
            return View(customNeedType);
        }

        // POST: CustomNeedTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomNeedType customNeedType = db.CustomNeedTypes.Find(id);
            db.CustomNeedTypes.Remove(customNeedType);
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
