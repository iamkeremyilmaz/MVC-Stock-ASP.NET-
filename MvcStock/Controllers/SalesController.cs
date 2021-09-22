using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MVCdbStockEntities db = new MVCdbStockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult newsale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newsale(Sales p)
        {
            db.Sales.Add(p);
            db.SaveChanges();
            return View("Index");
        }

    }
}