using NewFrontApp.API_Client;
using NewFrontApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFrontApp.Controllers
{
    public class AdminController : Controller
    {
        private const string uriProduct = "https://localhost:44300/product/";
        private const string uriUser = "https://localhost:44300/user/";
        private const string uriSub = "https://localhost:44300/subcategory/";
        // GET: Admin
        public ActionResult Index()
        {
            return View("Index", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult Products()
        {
            return View("Products", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult Users()
        {
            return View("Users", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult InsertProduct()
        {
            return View("InsertProduct", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult InsertUser()
        {
            return View("InsertUser", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult Delete()
        {
            return View("Index", "~/Views/Admin/_Layout2.cshtml");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult LoginError()
        {
            return View("LoginError");
        }

        public ActionResult UserSignUp()
        {
            return View("UserSignUp");
        }

        [HttpPost]
        public ActionResult ValidateUser(string email, string password)
        {
            LoginModel model = new LoginModel();
            model.validated = false;
            model.ErrorMessage = "User not found!";

            User novo = new User();
            model = GetUserLogin(email, password);

            if (model.validated)
                return View("Index", "~/Views/Admin/_Layout2.cshtml");
            else                
                return View("LoginError", model);
        }

        [HttpPost]
        public ActionResult SaveProduct(HttpPostedFileBase file, string id, string name, string description, decimal? price, int category, int subCategory)
        {
            GenericWebApiClient<Product> endpoint = new GenericWebApiClient<Product>(GetUriProduct());
            if (file != null && file.ContentLength > 0)
            {
                Product novo = new Product();
                if (id != null && !id.Equals(string.Empty))
                {
                    novo = GetProductById(id);
                    novo.image = ConvertToBytes(file);
                    novo.Name = name;
                    novo.Description = description;
                    novo.Price = price.Value;
                    novo.IdCategory = category;
                    novo.IdSubCategory = subCategory;
                    endpoint.Edit(novo, id);
                }
                else
                {
                    novo.image = ConvertToBytes(file);
                    novo.Name = name;
                    novo.Description = description;
                    novo.IdCategory = category;
                    novo.IdSubCategory = subCategory;
                    novo.Price = price.Value;
                    endpoint.Create(novo);
                }
            }

            return View("Products", "~/Views/Admin/_Layout2.cshtml");
        }

        [HttpPost]
        public ActionResult SaveUser(string id, string name, string email, string password, string confirmPassword)
        {
            GenericWebApiClient<User> endpoint = new GenericWebApiClient<User>(GetUriUser());
           
            if (!password.Equals(confirmPassword))
            {
                LoginModel model = new LoginModel();
                model.validated = false;
                model.ErrorMessage = "Passwords do not macth!";
                return View("LoginError", model);
            }
            User novo = new User();
            novo.Name = name;
            novo.Email = email;
            novo.Password = password;
            endpoint.Create(novo);

            return View("Index", "~/Views/Admin/_Layout2.cshtml");
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

        public User GetUserById(string id)
        {
            GenericWebApiClient<User> endpoint = new GenericWebApiClient<User>(GetUserUriById(id));
            var user = endpoint.GetAll().FirstOrDefault();
            return user;
        }

        public LoginModel GetUserLogin(string email, string password)
        {
            LoginModel model = new LoginModel();
            model.validated = true;
            GenericWebApiClient<User> endpoint = new GenericWebApiClient<User>(GetUserUriForLogin(email, password));
            var user = endpoint.GetAll().ToList();

            if (user.Count == 0)
            {
                model.validated = false;
                model.ErrorMessage = "User not found!";
            }
            else if(!user.FirstOrDefault().Password.Equals(password))
            {
                model.validated = false;
                model.ErrorMessage = "Password is not correct!";
            }

            return model;
        }

        public JsonResult GetUsersAPI()
        {
            GenericWebApiClient<User> endpoint = new GenericWebApiClient<User>(GetUriUser());
            var users = endpoint.GetAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubCategoryByIdCategory(string id)
        {
            GenericWebApiClient<SubCategory> endpoint = new GenericWebApiClient<SubCategory>(GetUriSubCategoryByCategory(id));
            var sub = endpoint.GetAllByCategory().ToList();
            return Json(sub.Where(x => x.IdCategory.ToString().Equals(id)), JsonRequestBehavior.AllowGet);
        }

        #region GET URI
        public Uri GetUriProduct()
        {
            return new Uri(uriProduct);
        }  

        public Uri GetUriUser()
        {
            return new Uri(uriUser);
        }  

        public Uri GetUriSubCategory()
        {
            return new Uri(uriSub);
        } 

        public Uri GetUriSubCategoryByCategory(string idCategory)
        {
            return new Uri(uriSub + "?idCategory=" + idCategory);
        }   

        public Uri GetUriById(string id)
        {
            return new Uri(uriProduct + "?id=" + id);
        }  

        public Uri GetUriSubByIdCategory(string id)
        {
            return new Uri(uriProduct + "?idCategory=" + id);
        }

        public Uri GetUserUriById(string id)
        {
            return new Uri(uriUser + "?id=" + id);
        }

        public Uri GetUserUriForLogin(string email, string password)
        {
            return new Uri(uriUser + "?email=" + email + "&password=" + password);
        }

        #endregion
    }
}