using NewFrontApp.API_Client;
using NewFrontApp.Common;
using NewFrontApp.Models;
using System;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class CellPhonesController : Controller
    {
        public ActionResult Samsung()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Samsung;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Apple()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Apple;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Motorola()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Motorola;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult LG()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.LG;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Accessories()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Accessories;
            return RedirectToAction("DefaultView", "Home");
        }
    }
}