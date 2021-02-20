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
    public class TitleController : Controller
    {
        ApplicationDbContext _db;

        public TitleController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var titleList = _db.Titles.Include("Employees").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(titleList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Title model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Titles.Add(model);
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
                var editTitle = _db.Titles.Where(i => i.Id == id).FirstOrDefault();
                if (editTitle != null)
                {
                    return View(editTitle);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Title model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Titles.Attach(model);
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
                var deleteTitle = _db.Titles.Find(id);
                if (deleteTitle != null)
                {
                    _db.Titles.Remove(deleteTitle);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}