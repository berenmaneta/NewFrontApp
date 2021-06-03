using NewFrontApp.API_Client;
using NewFrontApp.Common;
using NewFrontApp.Models;
using System;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class FurnitureController : Controller
    {
        public ActionResult Couches()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Couches;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Wardrobes()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Wardrobes;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Mattress()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Mattress;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult DinerTables()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.DinerTables;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult TVPanels()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.TVPanels;
            return RedirectToAction("DefaultView", "Home");
        }
    }
}