using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        AdminValidator adminValidator = new AdminValidator();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                var adminuserinfo = am.AdminGetir(p).FirstOrDefault();
                if (adminuserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                    Session["AdminUserName"] = adminuserinfo.AdminUserName;
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    var hata = "Kullanıcı Adı yada Şifre hatalı. Kontrol edip tekrar deneyiniz.";
                    ViewBag.hata = hata;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}