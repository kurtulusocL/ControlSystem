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
    public class FromWhereController : Controller
    {
        ApplicationDbContext _db;

        public FromWhereController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page=1)
        {
            using (_db=new ApplicationDbContext())
            {
                var frmWhere = _db.FromWheres.Include("Products").Include("Country").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(frmWhere);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.Provinces.Count()).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FromWhere model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.FromWheres.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.Provinces.Count()).ToList();
            using (_db=new ApplicationDbContext())
            {
                var editFrmWWhere = _db.FromWheres.Where(i => i.Id == id).FirstOrDefault();
                if (editFrmWWhere!=null)
                {
                    return View(editFrmWWhere);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FromWhere model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.FromWheres.Attach(model);
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
                var deleteFrmWhere = _db.FromWheres.Find(id);
                if (deleteFrmWhere!=null)
                {
                    _db.FromWheres.Remove(deleteFrmWhere);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}