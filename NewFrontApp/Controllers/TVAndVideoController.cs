using NewFrontApp.Common;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class TVAndVideoController : Controller
    {
        public ActionResult SmartTV()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.SmartTV;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult MonitorTV()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Monitors;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Projectors()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Projectors;
            return RedirectToAction("DefaultView", "Home");
        }

        public ActionResult Soundbar()
        {
            System.Web.HttpContext.Current.Session["IdSubCategory"] = (int)SubCategoriesEnum.Soundbar;
            return RedirectToAction("DefaultView", "Home");
        }
    }
}