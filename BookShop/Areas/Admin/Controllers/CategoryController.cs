﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        Models.TestDBEntities db = new Models.TestDBEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Models.category> data = db.categories.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.category obj)
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
                    db.categories.Add(obj);
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
            Models.category existingcategory = db.categories.Find(id);

            if (existingcategory == null)
            {
                return HttpNotFound();
            }

            return View(existingcategory);
        }

        [HttpPost]
        public ActionResult Edit(Models.category obj)
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
            Models.category categoryToDelete = db.categories.Find(id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }

            return View(categoryToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.category categoryToDelete = db.categories.Find(id);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }

            db.categories.Remove(categoryToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}