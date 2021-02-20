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
    public class ShipperController : Controller
    {
        ApplicationDbContext _db;

        public ShipperController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var shipper = _db.Shippers.Include("Orders").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(shipper);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shipper model, HttpPostedFileBase image)
        {
            if (image!=null&&image.ContentLength>0)
            {
                image.SaveAs(Server.MapPath("~/img/shipper/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Shippers.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var editShipper = _db.Shippers.Where(i => i.Id == id);
                if (editShipper!=null)
                {
                    return View(editShipper);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shipper model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/shipper/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Shippers.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteShipper = _db.Shippers.Find(id);
                if (deleteShipper!=null)
                {
                    _db.Shippers.Remove(deleteShipper);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}