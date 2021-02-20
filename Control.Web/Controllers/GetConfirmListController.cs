using Control.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class GetConfirmListController : Controller
    {
        ApplicationDbContext _db;

        public GetConfirmListController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult CategoryConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var category = _db.Categories.Include("Subcategories").Include("Orders").Include("Products").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 15);
                return View(category);
            }
        }

        public ActionResult CategoryConfirm(int id)
        {
            var confirm = _db.Categories.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("CategoryConfirmList");
        }

        public ActionResult CityConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var city = _db.Cities.Include("Province").Include("Customers").Include("Orders").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(city);
            }
        }

        public ActionResult CityConfirm(int id)
        {
            var confirm = _db.Cities.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("CityConfirmList");
        }

        public ActionResult CountryConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var country = _db.Countries.Include("FromWheres").Include("Customers").Include("ToWheres").Include("Provinces").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 15);
                return View(country);
            }
        }

        public ActionResult CountryConfirm(int id)
        {
            var confirm = _db.Countries.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("CountryConfirmList");
        }

        public ActionResult CustomerConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customerList = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("Region").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(customerList);
            }
        }

        public ActionResult CustomerConfirm(int id)
        {
            var confirm = _db.Customers.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("CustomerConfirmList");
        }

        public ActionResult DepartmantConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var departmanList = _db.Departmants.Include("Employees").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderBy(i => i.Employees.Count()).ToPagedList(page, 20);
                return View(departmanList);
            }
        }

        public ActionResult DepartmantConfirm(int id)
        {
            var confirm = _db.Departmants.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("DepartmantConfirmList");
        }

        public ActionResult EmployeeConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employeeList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.HireDate).ToPagedList(page, 30);
                return View(employeeList);
            }
        }

        public ActionResult EmployeeConfirm(int id)
        {
            var confirm = _db.Employees.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("EmployeeConfirmList");
        }

        public ActionResult FromWhereConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var frmWhere = _db.FromWheres.Include("Products").Include("Country").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(frmWhere);
            }
        }

        public ActionResult FromWhereConfirm(int id)
        {
            var confirm = _db.FromWheres.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("FromWhereConfirmList");
        }

        public ActionResult NoteConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var noteList = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(noteList);
            }
        }

        public ActionResult NoteConfirm(int id)
        {
            var confirm = _db.Notes.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("NoteConfirmList");
        }

        public ActionResult OrderConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderList = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return View(orderList);
            }
        }

        public ActionResult OrderConfirm(int id)
        {
            var confirm = _db.Orders.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("OrderConfirmList");
        }

        public ActionResult PaymentConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var payment = _db.Payments.Include("Notes").Include("Customers").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 25);
                return View(payment);
            }
        }

        public ActionResult PaymentConfirm(int id)
        {
            var confirm = _db.Payments.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("PaymentConfirmList");
        }

        public ActionResult ProductConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productList = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(productList);
            }
        }

        public ActionResult ProductConfirm(int id)
        {
            var confirm = _db.Products.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("ProductConfirmList");
        }

        public ActionResult ProvinceConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var province = _db.Provinces.Include("Cities").Include("Customers").Include("Orders").Include("Country").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 35);
                return View(province);
            }
        }

        public ActionResult ProvinceConfirm(int id)
        {
            var confirm = _db.Provinces.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("ProvinceConfirmList");
        }        

        public ActionResult ShipperConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var shipper = _db.Shippers.Include("Orders").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 20);
                return View(shipper);
            }
        }

        public ActionResult ShipperConfirm(int id)
        {
            var confirm = _db.Shippers.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("ShipperConfirmList");
        }

        public ActionResult SubcategoryConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var subCate = _db.Subcategories.Include("Products").Include("Category").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.Products.Count() > 0).ToPagedList(page, 20);
                return View(subCate);
            }
        }

        public ActionResult SubcategoryConfirm(int id)
        {
            var confirm = _db.Subcategories.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("SubcategoryConfirmList");
        }

        public ActionResult TitleConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var titleList = _db.Titles.Include("Employees").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(titleList);
            }
        }

        public ActionResult TitleConfirm(int id)
        {
            var confirm = _db.Titles.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("TitleConfirmList");
        }

        public ActionResult ToWhereConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var toWhere = _db.ToWheres.Include("Country").Include("Products").Where(i => i.IsConfirm == false && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 25);
                return View(toWhere);
            }
        }

        public ActionResult ToWhereConfirm(int id)
        {
            var confirm = _db.ToWheres.FirstOrDefault(i => i.Id == id);
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("ToWhereConfirmList");
        }
    }
}