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
    public class DepartmantController : Controller
    {
        ApplicationDbContext _db;

        public DepartmantController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page=1)
        {
            using (_db=new ApplicationDbContext())
            {
                var departmanList = _db.Departmants.Include("Employees").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderBy(i => i.Employees.Count()).ToPagedList(page, 20);
                return View(departmanList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departmant model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Departmants.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var editDepartmant = _db.Departmants.Where(i => i.Id == id).FirstOrDefault();
                if (editDepartmant!=null)
                {
                    return View(editDepartmant);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departmant model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Departmants.Attach(model);
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
                var deleteDepartman = _db.Departmants.Find(id);
                if (deleteDepartman!=null)
                {
                    _db.Departmants.Remove(deleteDepartman);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}