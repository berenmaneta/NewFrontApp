using NewFrontApp.API_Client;
using NewFrontApp.Common;
using NewFrontApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class HomeController : Controller
    {
        private const string uriProduct = "https://localhost:44300/product";

        public ActionResult Index()
        {
            return View();          
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult DefaultView()
        {
            ViewBag.IdSubCategory = (int)System.Web.HttpContext.Current.Session["IdSubCategory"];
            return View();
        }

        public ActionResult InsertProduct()
        {
            return View();
        }   

        public ActionResult Details(string id)
        {
            Product product = GetProductById(id);
            return View(product);
        }

        public JsonResult GetProductsAPI()
        {            
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriProduct());
            var products = endpoint.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductsAPIById(string data)
        {
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriProduct());
            var products = endpoint.GetAll();
            return Json(products.Where(x => x.Name.ToLower().Contains(data.ToLower())), JsonRequestBehavior.AllowGet);
        }

        public static byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public Product GetProductById(string id)
        {
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriById(id));
            var product = endpoint.GetAll().FirstOrDefault();
            return product;
        }

        public JsonResult GetProductBySubCategory(string id)
        {
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriBySubCategory(id));
            var products = endpoint.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public byte[] GetImageById(string id)
        {
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriById(id));
            var product = endpoint.GetAll().FirstOrDefault();
            return product.image;
        }

        public ActionResult RetrieveProductImage(string id)
        {
            byte[] cover = GetImageById(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        #region GET URI

        public Uri GetUriById(string id)
        {
            return new Uri(uriProduct + "?id=" + id);
        }

        public Uri GetUriBySubCategory(string id)
        {
            return new Uri(uriProduct + "?subCategory=" + id);
        }

        public Uri GetUriProduct()
        {
            return new Uri(uriProduct);
        }

        #endregion

    }
}