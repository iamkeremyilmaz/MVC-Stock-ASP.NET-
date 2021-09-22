using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        MVCdbStockEntities db = new MVCdbStockEntities();
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }
        [HttpGet]

        public ActionResult AddProduct()
        {
            List<SelectListItem> products = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoriesName,
                                                 Value = i.CategoriesId.ToString()
                                             }).ToList();
            ViewBag.values = products;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Products p1)
        {
            var ctg = db.Categories.Where(m => m.CategoriesId == p1.Categories.CategoriesId).FirstOrDefault();

            p1.Categories = ctg;
            db.Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var prd = db.Products.Find(id);
            db.Products.Remove(prd);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult listpro(int id)
        {
            var prdct = db.Products.Find(id);

            List<SelectListItem> products = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoriesName,
                                                 Value = i.CategoriesId.ToString()
                                             }).ToList();
            ViewBag.values = products;



            return View("listpro", prdct);
        }

        public ActionResult Update(Products p)
        {
            var product = db.Products.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            product.ProductPrice = p.ProductPrice;
            var ctg = db.Categories.Where(m => m.CategoriesId == p.Categories.CategoriesId).FirstOrDefault();

            product.ProductCategories = ctg.CategoriesId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
    }
}



