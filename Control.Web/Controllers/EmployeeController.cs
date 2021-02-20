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
    public class EmployeeController : Controller
    {
        ApplicationDbContext _db;

        public EmployeeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employeeList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.HireDate).ToPagedList(page, 30);
                return View(employeeList);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Employees.Find(id));
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
                model.EmployeeId = Convert.ToInt32(Session["NoteID"]);
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
                var editNote = _db.Notes.Where(i => i.Id == id).FirstOrDefault(i => i.EmployeeId == id);
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
                model.EmployeeId = Convert.ToInt32(Session["NoteID"]);
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
            ViewBag.Titles = _db.Titles.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Departmants = _db.Departmants.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/employee/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Employees.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Titles = _db.Titles.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Departmants = _db.Departmants.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db = new ApplicationDbContext())
            {
                var editEmployee = _db.Employees.Where(i => i.Id == id).FirstOrDefault();
                if (editEmployee != null)
                {
                    return View(editEmployee);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/employee/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Employees.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteEmployee = _db.Employees.Find(id);
                if (deleteEmployee != null)
                {
                    _db.Employees.Remove(deleteEmployee);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}