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
    public class CustomerController : Controller
    {
        ApplicationDbContext _db;

        public CustomerController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customerList = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(customerList);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Customers.Find(id));
        }

        public ActionResult CustomerInformation(int id)
        {
            var customerInfo = _db.Customers.Where(i => i.CustomerInfoId == id).FirstOrDefault();
            return View(customerInfo);
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
                model.CustomerId = Convert.ToInt32(Session["NoteID"]);
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
                var editNote = _db.Notes.Where(i => i.Id == id).FirstOrDefault(i => i.CustomerId == id);
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
                model.CustomerId = Convert.ToInt32(Session["NoteID"]);
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
            ViewBag.Payments = _db.Payments.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Cities = _db.Cities.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Customers.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Payments = _db.Payments.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Cities = _db.Cities.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            using (_db = new ApplicationDbContext())
            {
                var editCustomer = _db.Customers.Where(i => i.Id == id);
                if (editCustomer != null)
                {
                    return View(editCustomer);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Customers.Attach(model);
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
                var deleteCustomer = _db.Customers.Find(id);
                if (deleteCustomer != null)
                {
                    _db.Customers.Remove(deleteCustomer);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}