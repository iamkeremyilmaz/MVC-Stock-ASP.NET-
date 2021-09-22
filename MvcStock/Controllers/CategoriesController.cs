using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStock.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories

        MVCdbStockEntities db = new MVCdbStockEntities();
        public ActionResult Index(int page=1)
        {
            //var categories = db.Categories.ToList();
            var categories = db.Categories.ToList().ToPagedList(page,4);
            return View(categories);
        }
        [HttpGet]

        public ActionResult NewCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategories(Categories p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCategories");
            }
            db.Categories.Add(p1);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id)
        {
            var categories = db.Categories.Find(id);
            db.Categories.Remove(categories);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Update(int id)
        {
            var ctgrr = db.Categories.Find(id);
            return View("Update", ctgrr);
        }
        public ActionResult Updatee(Categories p1)
        {
            var ctg = db.Categories.Find(p1.CategoriesId);
            ctg.CategoriesName = p1.CategoriesName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}