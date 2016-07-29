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
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Advertiser).Include(a => a.Country).Include(a => a.Organization).Include(a => a.User);
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Code");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,Type,Street1,Street2,District,City,StateOrProvince,PostalCode,CountryId,AdvertiserId,OrganizationId,UserId")] Address address)
        {
            if (ModelState.IsValid)
            {
                address.AddressId = Guid.NewGuid();
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", address.AdvertiserId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Code", address.CountryId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", address.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", address.UserId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", address.AdvertiserId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Code", address.CountryId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", address.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", address.UserId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,Type,Street1,Street2,District,City,StateOrProvince,PostalCode,CountryId,AdvertiserId,OrganizationId,UserId")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvertiserId = new SelectList(db.Advertisers, "AdvertiserId", "Name", address.AdvertiserId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Code", address.CountryId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "OrganizationId", "Name", address.OrganizationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Surname", address.UserId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
