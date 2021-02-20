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
    public class ProductController : Controller
    {
        ApplicationDbContext _db;

        public ProductController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productList = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(productList);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Products.Find(id));
        }

        public ActionResult CreateNote(int? id)
        {
            Session["NoteID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNote(Note model)
        {
            if (ModelState.IsValid)
            {
                model.ProductId = Convert.ToInt32(Session["NoteID"]);
                using (_db = new ApplicationDbContext())
                {
                    _db.Notes.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditNote(int? id)
        {
            Session["NoteID"] = id;
            using (_db = new ApplicationDbContext())
            {
                var editNote = _db.Notes.Where(i => i.Id == id).FirstOrDefault(i => i.ProductId == id);
                if (editNote != null)
                {
                    return View(editNote);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNote(Note model)
        {
            if (ModelState.IsValid)
            {
                model.ProductId = Convert.ToInt32(Session["NoteID"]);
                using (_db = new ApplicationDbContext())
                {
                    _db.Notes.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Subcategories = _db.Subcategories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.FromWheres = _db.FromWheres.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.ToWheres = _db.ToWheres.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            //if (ModelState.IsValid)
            //{
            using (_db = new ApplicationDbContext())
            {
                _db.Products.Add(model);
                _db.Entry(model).State = EntityState.Added;
                _db.SaveChanges();
            }
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Subcategories = _db.Subcategories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.FromWheres = _db.FromWheres.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.ToWheres = _db.ToWheres.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            using (_db = new ApplicationDbContext())
            {
                var editProduct = _db.Products.Where(i => i.Id == id).FirstOrDefault();
                if (editProduct != null)
                {
                    return View(editProduct);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Products.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deleteProduct = _db.Products.Find(id);
            if (deleteProduct != null)
            {
                _db.Products.Remove(deleteProduct);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}