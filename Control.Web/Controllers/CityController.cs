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
    public class CityController : Controller
    {
        ApplicationDbContext _db;

        public CityController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var city = _db.Cities.Include("Province").Include("Customers").Include("Orders").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(city);
            }
        }

        public ActionResult Create(int? id)
        {           
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.CreatedTime).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Cities.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {          
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.CreatedTime).ToList();
            using (_db = new ApplicationDbContext())
            {
                var editCity = _db.Cities.Where(i => i.Id == id).FirstOrDefault();
                if (editCity != null)
                {
                    return View(editCity);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Cities.Attach(model);
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
                var deleteCity = _db.Cities.Find(id);
                if (deleteCity != null)
                {
                    _db.Cities.Remove(deleteCity);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}