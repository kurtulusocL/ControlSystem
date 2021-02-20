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
    public class CommunicateController : Controller
    {
        ApplicationDbContext _db;

        public CommunicateController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var comunicate = _db.Communicates.Where(i => i.IsDeleted == false && (i.IsConfirm == true || i.IsConfirm == false)).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 25);
                return View(comunicate);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Communicate model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Communicates.Add(model);
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
                var editCommuni = _db.Communicates.Where(i => i.Id == id).FirstOrDefault();
                if (editCommuni != null)
                {
                    return View(editCommuni);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Communicate model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Communicates.Attach(model);
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
                var deleteCommuni = _db.Communicates.Find(id);
                if (deleteCommuni != null)
                {
                    _db.Communicates.Remove(deleteCommuni);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}