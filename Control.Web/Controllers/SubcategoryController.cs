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
    public class SubcategoryController : Controller
    {
        ApplicationDbContext _db;

        public SubcategoryController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var subCate = _db.Subcategories.Include("Products").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.Products.Count() > 0).ToPagedList(page, 20);
                return View(subCate);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subcategory model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Subcategories.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db=new ApplicationDbContext())
            {
                var editSubcate = _db.Subcategories.Where(i => i.Id == id).FirstOrDefault();
                if (editSubcate!=null)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subcategory model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Subcategories.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteSubcate = _db.Subcategories.Find(id);
                if (deleteSubcate!=null)
                {
                    _db.Subcategories.Remove(deleteSubcate);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}