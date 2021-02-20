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
    public class OrderController : Controller
    {
        ApplicationDbContext _db;

        public OrderController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page=1)
        {
            using (_db=new ApplicationDbContext())
            {
                var orderList = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return View(orderList);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Orders.Find(id));
        }

        public ActionResult CustomerInfo(int id)
        {
            var customer = _db.Orders.Where(i => i.Id == id).FirstOrDefault(i => i.CustomerId == id);
            return View(customer);
        }

        public ActionResult ShipperInfo(int id)
        {
            var shipper = _db.Orders.Where(i => i.Id == id).FirstOrDefault(i => i.ShipperId == id);
            return View(shipper);
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
                model.OrderId = Convert.ToInt32(Session["NoteID"]);
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
                var editNote = _db.Notes.Where(i => i.Id == id).FirstOrDefault(i => i.OrderId == id);
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
                model.OrderId = Convert.ToInt32(Session["NoteID"]);
                using (_db = new ApplicationDbContext())
                {
                    _db.Notes.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateOrderDetail(int? id)
        {
            Session["orderDetailID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderDetail(OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                model.OrderId = Convert.ToInt32(Session["orderDetailID"]);
                using (_db=new ApplicationDbContext())
                {
                    _db.OrderDetails.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditOrderDetail(int? id)
        {
            using (_db=new ApplicationDbContext())
            {
                var editOrderDetail = _db.OrderDetails.Where(i => i.Id == id).FirstOrDefault(i => i.OrderId == id);
                if (editOrderDetail!=null)
                {
                    return View(editOrderDetail);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrderDetail(OrderDetail model)
        {
            if (ModelState.IsValid)
            {
                model.OrderId = Convert.ToInt32(Session["orderDetailID"]);
                using (_db = new ApplicationDbContext())
                {
                    _db.OrderDetails.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();           
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Cities = _db.Cities.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Shippers = _db.Shippers.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Payments = _db.Payments.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Orders.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Countries = _db.Countries.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();            
            ViewBag.Provinces = _db.Provinces.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Cities = _db.Cities.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Shippers = _db.Shippers.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            using (_db=new ApplicationDbContext())
            {
                var editOrder = _db.Orders.Where(i => i.Id == id).FirstOrDefault();
                if (editOrder!=null)
                {
                    return View(editOrder);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Orders.Attach(model);
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
                var deleteOrder = _db.Orders.Find(id);
                if (deleteOrder!=null)
                {
                    _db.Orders.Remove(deleteOrder);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}