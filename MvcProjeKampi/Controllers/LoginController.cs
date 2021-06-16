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
        LoginValidator loginValidator = new LoginValidator();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Admin p, string username, string password, string ReturnUrl)
        {
            ValidationResult results = loginValidator.Validate(p);
            if (results.IsValid)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var adminuserinfo = am.AdminListeGetir().Where(x => x.AdminUserName == crypto.Compute(p.AdminUserName, x.AdminPasswordSalt) && x.AdminPassword == crypto.Compute(p.AdminPassword, x.AdminPasswordSalt)).FirstOrDefault();
                //var adminuserinfo = am.AdminListeGetir().Where(x => x.AdminUserName == p.AdminUserName).FirstOrDefault();
                if (adminuserinfo != null)
                {
                    //if (adminuserinfo.AdminPassword == crypto.Compute(p.AdminPassword, adminuserinfo.AdminPasswordSalt))
                    //{
                    //    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    //    Session["AdminUserName"] = adminuserinfo.AdminUserName;
                    //    Session["AdminUserRole"] = adminuserinfo.AdminRole;
                    //    Session["AdminName"] = adminuserinfo.AdminName;
                    //    Session["AdminSurname"] = adminuserinfo.AdminSurname;

                    //    if (!string.IsNullOrEmpty(ReturnUrl))
                    //    {
                    //        return Redirect(ReturnUrl);
                    //    }
                    //    else
                    //    {
                    //        return RedirectToAction("Index", "Istatistik");
                    //    }
                    //}

                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    Session["AdminUserName"] = adminuserinfo.AdminUserName;
                    Session["AdminUserRole"] = adminuserinfo.AdminRole;
                    Session["AdminName"] = adminuserinfo.AdminName;
                    Session["AdminSurname"] = adminuserinfo.AdminSurname;

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Istatistik");
                    }
                }
                else
                {
                    TempData["HataMesaji1"] = "Kullanıcı Adı yada Şifre hatalı.";
                    TempData["HataMesaji2"] = "Kontrol edip tekrar deneyiniz.";
                    return View();
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

        public ActionResult Logout()
        {
            Session["AdminUserName"] = null;
            Session["AdminUserRole"] = null;
            Session["AdminName"] = null;
            Session["AdminSurname"] = null;
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                var gizle = new SimpleCrypto.PBKDF2();
                var SifresizKullaniciAdi = gizle.Compute(p.AdminUserName);
                var SifresizSifre = gizle.Compute(p.AdminPassword);

                p.AdminUserName = SifresizKullaniciAdi;
                p.AdminPassword = SifresizSifre;
                p.AdminPasswordSalt = gizle.Salt;
                am.AdminEkle(p);
                return RedirectToAction("AdminListe");
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

        public ActionResult AdminListe()
        {
            var AdminDegerleri = am.AdminListeGetir();
            return View(AdminDegerleri);
        }
    }
}