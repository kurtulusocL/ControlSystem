using Control.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Control.Web.Controllers
{   
    public class HomeController : Controller
    {
        ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryToOrder(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderCate = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.CategoryId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return PartialView("_CategoryToOrder", orderCate);
            }
        }

        public ActionResult CountryToOrder(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderCountry = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.CountryId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return PartialView("_CountryToOrder", orderCountry);
            }
        }

        public ActionResult ProvinceToOrder(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderProvince = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.ProvinceId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return PartialView("_ProvinceToOrder", orderProvince);
            }
        }

        public ActionResult OrderToCity(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderCity = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.CityId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return PartialView("_OrderToCity", orderCity);
            }
        }

        public ActionResult ShipperToOrder(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var orderShipper = _db.Orders.Include("Country").Include("Category").Include("Province").Include("City").Include("Customer").Include("Shipper").Include("Notes").Include("OrderDetails").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.ShipperId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);

                return PartialView("_ShipperToOrder", orderShipper);
            }
        }

        public ActionResult ProductToCategory(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productCate = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.CategoryId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_ProductToCategory", productCate);
            }
        }

        public ActionResult ProductToFromWhere(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productFromWhere = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.FromWhereId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_ProductToFromWhere", productFromWhere);
            }
        }

        public ActionResult ProductToWhere(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productToWhere = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.ToWhereId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_ProductToWhere", productToWhere);
            }
        }

        public ActionResult ProductToSubcategory(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var productsubcate = _db.Products.Include("ProductDetail").Include("FromWhere").Include("ToWhere").Include("Subcategory").Include("Notes").Include("Category").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.SubcategoryId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_ProductToSubcategory", productsubcate);
            }
        }

        public ActionResult CustomerToPayment(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customerPayment = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true && i.PaymentId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_CustomerToPayment", customerPayment);
            }
        }

        public ActionResult CustomerToCountry(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customerCountry = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true && i.CountryId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_CustomerToCountry", customerCountry);
            }
        }

        public ActionResult CustomerToProvince(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customerProvince = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true && i.ProvinceId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_CustomerToProvince", customerProvince);
            }
        }

        public ActionResult CustomerToCity(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var customercity = _db.Customers.Include("Notes").Include("Payment").Include("Country").Include("City").Include("Province").Include("CustomerInfo").Include("Orders").Where(i => i.IsDeleted == false && i.IsConfirm == true && i.CityId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_CustomerToCity", customercity);
            }
        }

        public ActionResult EmployeeToTitle(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employeeTitle = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.TitleId == id).OrderByDescending(i => i.HireDate).ToPagedList(page, 30);
                return PartialView("_EmployeeToTitle", employeeTitle);
            }
        }

        public ActionResult EmployeeToDepartman(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employeeDepartman = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.DepartmantId == id).OrderByDescending(i => i.HireDate).ToPagedList(page, 30);
                return PartialView("_EmployeeToDepartman", employeeDepartman);
            }
        }

        public ActionResult NoteToEmployee(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var noteEmployee = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.EmployeeId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_NoteToEmployee", noteEmployee);
            }
        }

        public ActionResult NoteToCustomer(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var noteCustomer = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.CustomerId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_NoteToCustomer", noteCustomer);
            }
        }

        public ActionResult NoteToOrder(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var noteOrder = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.OrderId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_NoteToOrder", noteOrder);
            }
        }

        public ActionResult NoteToPayment(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var notePayment = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.PaymentId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_NoteToPayment", notePayment);
            }
        }

        public ActionResult NoteToProduct(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var noteProduct = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.ProductId == id).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return PartialView("_NoteToProduct", noteProduct);
            }
        }
    }
}