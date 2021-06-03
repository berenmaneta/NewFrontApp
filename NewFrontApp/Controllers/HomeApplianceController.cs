using NewFrontApp.API_Client;
using NewFrontApp.Common;
using NewFrontApp.Models;
using System;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class HomeApplianceController : Controller
    {
        public ActionResult Fridges()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Fridges;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult AirConditioner()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.AirConditioner;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Microwaves()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Microwaves;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Washers()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Washers;
            return RedirectToAction("DefaultView", "Home");
        }
    }
}