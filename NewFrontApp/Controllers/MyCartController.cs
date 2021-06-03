using NewFrontApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class MyCartController : Controller
    {
        public List<Cart> cart = new List<Cart>();
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddCart(string idProduct, string name, decimal price, string chave)
        {
            var split = chave.Split('?');
            var qtde = Convert.ToInt32(split[1]);
            cart = (List<Cart>)System.Web.HttpContext.Current.Session["cart"];
            if (cart == null)
                cart = new List<Cart>();
            Cart ncart = new Cart();

            if (cart.Any(x => x.IdProduct == idProduct))
            {
                cart.Select(c => { c.Quantity += qtde; return c; }).ToList();
            }
            else
            {
                ncart.Quantity = qtde;
                ncart.Name = name;
                ncart.IdProduct = idProduct;
                ncart.Price = price;
                cart.Add(ncart);
            }
            System.Web.HttpContext.Current.Session["cart"] = cart;
            return RedirectToAction("Cart", "MyCart");
        }

        public JsonResult GetProductsCart()
        {
            var lista = (List<Cart>)System.Web.HttpContext.Current.Session["cart"];
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}