using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        Models.TestDBEntities db = new Models.TestDBEntities();

        // GET: Admin/Product
        public ActionResult Index()
        {
            List<Models.book> data = db.books.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.publicsher_id = new SelectList(db.publicshers.ToList(), "id", "name_publicsher");
            ViewBag.author_id = new SelectList(db.authors.ToList(), "id", "name_author");
            ViewBag.category_id = new SelectList(db.categories.ToList(), "id", "category_name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.book obj)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var fImage = Request.Files["fImage"];
                    if(fImage != null && fImage.ContentLength > 0)
                    {
                        string fName = fImage.FileName;
                        string foder = Server.MapPath("~/Assets/Uploads/"+fName);
                        fImage.SaveAs(foder);
                        obj.image = "~/Assets/Uploads/" + fName;
                    }
                    db.books.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            ViewBag.publicsher_id = new SelectList(db.publicshers.ToList(), "id", "name_publicsher");
            ViewBag.author_id = new SelectList(db.authors.ToList(), "id", "name_author");
            ViewBag.category_id = new SelectList(db.categories.ToList(), "id", "category_name");
            return View(obj);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.book existingBook = db.books.Find(id);

            if (existingBook == null)
            {
                return HttpNotFound();
            }

            ViewBag.publicsher_id = new SelectList(db.publicshers.ToList(), "id", "name_publicsher");
            ViewBag.author_id = new SelectList(db.authors.ToList(), "id", "name_author");
            ViewBag.category_id = new SelectList(db.categories.ToList(), "id", "category_name");

            return View(existingBook);
        }

        [HttpPost]
        public ActionResult Edit(Models.book obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fImage = Request.Files["fImage"];
                    if (fImage != null && fImage.ContentLength > 0)
                    {
                        obj.IsImageChanged = true;
                        string fName = fImage.FileName;
                        string folder = Server.MapPath("~/Assets/Uploads/" + fName);
                        fImage.SaveAs(folder);
                        obj.image = "~/Assets/Uploads/" + fName;
                    }

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    // Handle exceptions
                }
            }

            ViewBag.publicsher_id = new SelectList(db.publicshers.ToList(), "id", "name_publicsher");
            ViewBag.author_id = new SelectList(db.authors.ToList(), "id", "name_author");
            ViewBag.category_id = new SelectList(db.categories.ToList(), "id", "category_name");
            return View(obj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.book bookToDelete = db.books.Find(id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }

            return View(bookToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.book bookToDelete = db.books.Find(id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }

            db.books.Remove(bookToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}