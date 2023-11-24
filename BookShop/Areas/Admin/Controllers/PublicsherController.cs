using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class PublicsherController : Controller
    {
        Models.TestDBEntities db = new Models.TestDBEntities();
        // GET: Admin/Publicsher
        public ActionResult Index()
        {
            List<Models.publicsher> data = db.publicshers.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.publicsher obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    db.publicshers.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }

            return View(obj);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.publicsher existingpublicsher = db.publicshers.Find(id);

            if (existingpublicsher == null)
            {
                return HttpNotFound();
            }

            return View(existingpublicsher);
        }

        [HttpPost]
        public ActionResult Edit(Models.publicsher obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    // Handle exceptions
                }
            }


            return View(obj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.publicsher publicsherToDelete = db.publicshers.Find(id);

            if (publicsherToDelete == null)
            {
                return HttpNotFound();
            }

            return View(publicsherToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.publicsher publicsherToDelete = db.publicshers.Find(id);

            if (publicsherToDelete == null)
            {
                return HttpNotFound();
            }

            db.publicshers.Remove(publicsherToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}