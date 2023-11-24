using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        Models.TestDBEntities db = new Models.TestDBEntities();
        // GET: Admin/Author
        public ActionResult Index()
        {
            List<Models.author> data = db.authors.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.author obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fImage = Request.Files["fImage"];
                    if (fImage != null && fImage.ContentLength > 0)
                    {
                        string fName = fImage.FileName;
                        string foder = Server.MapPath("~/Assets/Uploads/" + fName);
                        fImage.SaveAs(foder);
                        obj.img = "~/Assets/Uploads/" + fName;
                    }
                    db.authors.Add(obj);
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
            Models.author existingauthor = db.authors.Find(id);

            if (existingauthor == null)
            {
                return HttpNotFound();
            }

            return View(existingauthor);
        }

        [HttpPost]
        public ActionResult Edit(Models.author obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fImage = Request.Files["fImage"];
                    if (fImage != null && fImage.ContentLength > 0)
                    {

                        string fName = fImage.FileName;
                        string folder = Server.MapPath("~/Assets/Uploads/" + fName);
                        fImage.SaveAs(folder);
                        obj.img = "~/Assets/Uploads/" + fName;
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


            return View(obj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Models.author authorToDelete = db.authors.Find(id);

            if (authorToDelete == null)
            {
                return HttpNotFound();
            }

            return View(authorToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.author authorToDelete = db.authors.Find(id);

            if (authorToDelete == null)
            {
                return HttpNotFound();
            }

            db.authors.Remove(authorToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}