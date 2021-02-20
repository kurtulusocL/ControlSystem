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
    public class ProvinceController : Controller
    {
        ApplicationDbContext _db;

        public ProvinceController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var province = _db.Provinces.Include("Cities").Include("Customers").Include("Orders").Include("Country").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 35);
                return View(province);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Countries = _db.Countries.Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.Name).ToList();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Province model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Provinces.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Countries = _db.Countries.Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.Name).ToList();
           
            using (_db=new ApplicationDbContext())
            {
                var editProvince = _db.Provinces.Where(i => i.Id == id).FirstOrDefault();
                if (editProvince!=null)
                {
                    return View(editProvince);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Province model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Provinces.Attach(model);
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
                var deleteProvince = _db.Provinces.Find(id);
                if (deleteProvince!=null)
                {
                    _db.Provinces.Remove(deleteProvince);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}