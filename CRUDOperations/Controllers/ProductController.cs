using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CRUDOperations.Models;



namespace CRUDOperations.Controllers
{
    [HandleError]
    public class ProductController : Controller
    {
        ConstraintsEntities dc = new ConstraintsEntities();
        public ViewResult DisplayProducts()
        {
            var p = dc.Products;
            return View(p);
        }
        public ViewResult DisplayProduct(int Productid)
        {
            var product = dc.Products.Find(Productid);
            return View(product);
        }
        public ViewResult AddProduct()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public RedirectToRouteResult AddProduct(Product product)
        {
            product.Status = true;
            dc.Products.Add(product);
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
        public ViewResult EditProduct(int Productid)
        {
            Product p = dc.Products.Find(Productid);
            return View(p);
        }
        public RedirectToRouteResult UpdateProduct(Product product)
        {
            product.Status = true;
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
        public ViewResult DeleteProduct(int Productid)
        {
            Product p = dc.Products.Find(Productid);
            return View(p);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteProduct(Product product)
        {
            product.Status = false;
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
    }
}