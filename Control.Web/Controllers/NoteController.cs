using Control.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.Web.Controllers
{
    public class NoteController : Controller
    {
        ApplicationDbContext _db;

        public NoteController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page=1)
        {
            using (_db=new ApplicationDbContext())
            {
                var noteList = _db.Notes.Include("Employee").Include("Customer").Include("Order").Include("Payment").Include("Product").Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedTime).ToPagedList(page, 30);
                return View(noteList);
            }
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteNote = _db.Notes.Find(id);
                if (deleteNote!=null)
                {
                    _db.Notes.Remove(deleteNote);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}