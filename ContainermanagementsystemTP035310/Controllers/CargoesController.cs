using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContainermanagementsystemTP034963.Models;

namespace ContainermanagementsystemTP034963.Controllers
{
    public class CargoesController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Cargoes
        public ActionResult Index()
        {
            var cargoes = db.Cargoes.Include(c => c.Customer).Include(c => c.Warehouse);
            return View(cargoes.ToList());
        }

        // GET: Cargoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargoes/Create
        public ActionResult Create()
        {
            ViewBag.customerid = new SelectList(db.Customers, "Id", "name");
            ViewBag.warehouseid = new SelectList(db.Warehouses, "Id", "location");
            return View();
        }

        // POST: Cargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,volume,weight,customerid,warehouseid")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargoes.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerid = new SelectList(db.Customers, "Id", "name", cargo.customerid);
            ViewBag.warehouseid = new SelectList(db.Warehouses, "Id", "location", cargo.warehouseid);
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerid = new SelectList(db.Customers, "Id", "name", cargo.customerid);
            ViewBag.warehouseid = new SelectList(db.Warehouses, "Id", "location", cargo.warehouseid);
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,volume,weight,customerid,warehouseid")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerid = new SelectList(db.Customers, "Id", "name", cargo.customerid);
            ViewBag.warehouseid = new SelectList(db.Warehouses, "Id", "location", cargo.warehouseid);
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = db.Cargoes.Find(id);
            db.Cargoes.Remove(cargo);
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
