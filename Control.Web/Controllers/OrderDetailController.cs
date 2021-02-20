using Control.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        ApplicationDbContext _db;

        public OrderDetailController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var orderDetail = _db.OrderDetails.Include("Order").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.Order.OrderNo).ToPagedList(page, 30);
                return View(orderDetail);
            }
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteOrder = _db.OrderDetails.Find(id);
                if (deleteOrder!=null)
                {
                    _db.OrderDetails.Remove(deleteOrder);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}