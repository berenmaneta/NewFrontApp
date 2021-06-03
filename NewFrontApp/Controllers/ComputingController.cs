using NewFrontApp.API_Client;
using NewFrontApp.Common;
using NewFrontApp.Models;
using System;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class ComputingController : Controller
    {
        public ActionResult Computers()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Computers;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult ExternalHD()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.ExternalHD;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Monitors()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Monitors;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Notebooks()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Notebooks;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Printers()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Printers;
            return RedirectToAction("DefaultView", "Home");
        }
    }
}