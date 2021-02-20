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
    public class PaymentController : Controller
    {
        ApplicationDbContext _db;

        public PaymentController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var payment = _db.Payments.Include("Notes").Include("Customers").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 25);
                return View(payment);
            }
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
                model.PaymentId = Convert.ToInt32(Session["NoteID"]);
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
                var editNote = _db.Notes.Where(i => i.Id == id).FirstOrDefault(i => i.PaymentId == id);
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
                model.PaymentId = Convert.ToInt32(Session["NoteID"]);
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Payments.Add(model);
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
                var editPayment = _db.Payments.Where(i => i.Id == id);
                if (editPayment != null)
                {
                    return View(editPayment);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payment model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Payments.Attach(model);
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
                var deletePayment = _db.Payments.Find(id);
                if (deletePayment != null)
                {
                    _db.Payments.Remove(deletePayment);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}