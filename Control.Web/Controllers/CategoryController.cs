using Control.Data.Data;
using Control.Entities.Models.Entites;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;

        public CategoryController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var category = _db.Categories.Include("Subcategories").Include("Orders").Include("Products").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 15);
                return View(category);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Categories.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var editCate = _db.Categories.Where(i => i.Id == id).FirstOrDefault();
                if (editCate != null)
                {
                    return View(editCate);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Categories.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteCate = _db.Categories.Find(id);
                if (deleteCate != null)
                {
                    _db.Categories.Remove(deleteCate);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}