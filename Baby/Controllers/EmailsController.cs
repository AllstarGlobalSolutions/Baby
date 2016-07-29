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
    public class EmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emails
        public ActionResult Index()
        {
            var emails = db.Emails.Include(e => e.Advertiser).Include(e => e.Organization).Include(e => e.User);
            return View(emails.ToList());
        }

        // GET: Emails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: Emails/Create
        public ActionResult Create()
        {
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailId,Type,Address,AdvertiserId,OrganizationId,UserId")] Email email)
        {
            if (ModelState.IsValid)
            {
                email.EmailId = Guid.NewGuid();
                db.Emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", email.AdvertiserId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", email.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", email.UserId);
            return View(email);
        }

        // GET: Emails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", email.AdvertiserId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", email.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", email.UserId);
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailId,Type,Address,AdvertiserId,OrganizationId,UserId")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", email.AdvertiserId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", email.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", email.UserId);
            return View(email);
        }

        // GET: Emails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Email email = db.Emails.Find(id);
            db.Emails.Remove(email);
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
