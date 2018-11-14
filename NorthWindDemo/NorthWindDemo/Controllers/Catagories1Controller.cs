using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthWindDemo.Models;
using NorthWindDemo.Models.Repository;
using NorthWindDemo.Models.DAO;

namespace NorthWindDemo.Controllers
{
    public class Catagories1Controller : Controller
    {
        private readonly ICatagory_BLO _BO = null;
    //    public Catagories1Controller()
    //    : this(new Catagory_DAO(new NorthwindEntities1()))
    //{
    //    }
        public Catagories1Controller(ICatagory_BLO BO)
        {
            _BO = BO;
        }

        // GET: Catagories1
        public ActionResult Index()
        {
            return View(_BO.GetAll());
        }

        // GET: Catagories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = _BO.GetDetail(id).FirstOrDefault();
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // GET: Catagories1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagories1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _BO.Create(catagory);
                return RedirectToAction("Index");
            }

            return View(catagory);
        }

        // GET: Catagories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = _BO.GetDetail(id).FirstOrDefault();
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _BO.Edit(catagory);
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        // GET: Catagories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = _BO.GetDetail(id).FirstOrDefault();
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        // POST: Catagories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _BO.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
