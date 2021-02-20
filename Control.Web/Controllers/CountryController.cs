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
    public class CountryController : Controller
    {
        ApplicationDbContext _db;

        public CountryController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var country = _db.Countries.Include("FromWheres").Include("Customers").Include("ToWheres").Include("Provinces").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 15);
                return View(country);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/country/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Countries.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var editCountry = _db.Countries.Where(i => i.Id == id).FirstOrDefault();
                if (editCountry!=null)
                {
                    return View(editCountry);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/country/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Countries.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteCountry = _db.Countries.Find(id);
                if (deleteCountry!=null)
                {
                    _db.Countries.Remove(deleteCountry);
                    _db.SaveChanges();
                }
                else
                {
                    HttpNotFound();
                }
                return RedirectToAction("Index");
            }
        }
    }
}