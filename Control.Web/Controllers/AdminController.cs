using Control.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _db;

        public AdminController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserInfo(string userId)
        {
            userId = Convert.ToString(Session["adminID"]);
            using (_db = new ApplicationDbContext())
            {
                var admin = _db.Users.Where(i => i.Id == userId).OrderByDescending(i => i.NameLastname).ToList();
                return PartialView("_UserInfo", admin);
            }
        }

        public ActionResult UserInformation(string userId)
        {
            userId = Convert.ToString(Session["adminID"]);
            using (_db = new ApplicationDbContext())
            {
                var adminInfo = _db.Users.Where(i => i.Id == userId).OrderByDescending(i => i.NameLastname).ToList();
                return PartialView("_UserInformation", adminInfo);
            }
        }

        public ActionResult CEOList()
        {
            using (_db=new ApplicationDbContext())
            {
                var ceoList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.Title.Name == "CEO").OrderByDescending(i => i.CreatedTime).ToList();
                return PartialView("_CEOList", ceoList);
            }
        }

        public ActionResult MenagerList()
        {
            using (_db = new ApplicationDbContext())
            {
                var menagerList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.Title.Name == "Müdür").OrderByDescending(i => i.CreatedTime).ToList();
                return PartialView("_MenagerList", menagerList);
            }
        }

        public ActionResult GeneralMenagerList()
        {
            using (_db = new ApplicationDbContext())
            {
                var generalList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.Title.Name == "Genel Müdür").OrderByDescending(i => i.CreatedTime).ToList();
                return PartialView("_GeneralMenagerList", generalList);
            }
        }

        public ActionResult AdministratorList()
        {
            using (_db = new ApplicationDbContext())
            {
                var adminList = _db.Employees.Include("Notes").Include("Title").Include("EmployeeInfo").Include("Departmant").Where(i => i.IsConfirm == true && i.IsDeleted == false && i.Title.Name == "Yönetici").OrderByDescending(i => i.CreatedTime).ToList();
                return PartialView("_AdministratorList", adminList);
            }
        }

        public ActionResult TotalEmployee()
        {
            using (_db=new ApplicationDbContext())
            {
                var departman = _db.Departmants.Include("Employees").Where(i => i.IsConfirm == true && i.IsDeleted == false).ToList();
                return PartialView("_TotalEmployee", departman);
            }
        }

        public ActionResult TotalTitle()
        {
            using (_db = new ApplicationDbContext())
            {
                var title = _db.Titles.Include("Employees").Where(i => i.IsConfirm == true && i.IsDeleted == false).ToList();
                return PartialView("_TotalTitle", title);
            }
        }

        public ActionResult AdminList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var admin = _db.Users.OrderByDescending(i => i.Id).ToPagedList(page, 10);
                return View(admin);
            }
        }

        public ActionResult Author(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var admin = _db.Users.OrderByDescending(i => i.Id).ToPagedList(page, 10);
                return View(admin);
            }
        }

        public ActionResult DeleteAdmin(string id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteAdmin = _db.Users.Find(id);
                if (deleteAdmin != null)
                {
                    _db.Users.Remove(deleteAdmin);
                    _db.SaveChanges();
                }
                return RedirectToAction("AdminList");
            }
        }
    }
}