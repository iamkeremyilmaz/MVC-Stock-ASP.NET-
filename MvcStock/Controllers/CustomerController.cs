using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        MVCdbStockEntities db = new MVCdbStockEntities();
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(Customers p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Customers.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var cust = db.Customers.Find(id);
            db.Customers.Remove(cust);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       public ActionResult custshow(int id )
        {
            var custt = db.Customers.Find(id);
            return View("custshow", custt);
        }
        public ActionResult update(Customers p1)
        {
            var cust= db.Customers.Find(p1.CustomerId);
            cust.CustomerName = p1.CustomerName;
            cust.CustomerSurname = p1.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}