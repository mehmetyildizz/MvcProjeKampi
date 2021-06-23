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
        readonly AdminManager am = new AdminManager(new EfAdminDal());
        readonly AdminValidator adminValidator = new AdminValidator();
        readonly LoginValidator loginValidator = new LoginValidator();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Admin p, string ReturnUrl)
        {
            ValidationResult results = loginValidator.Validate(p);
            if (results.IsValid)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var adminuserinfo = am.AdminListeGetir().Where(x => x.AdminUserName == crypto.Compute(p.AdminUserName, x.AdminSalt) && x.AdminPassword == crypto.Compute(p.AdminPassword, x.AdminSalt)).FirstOrDefault();
                if (adminuserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    Session["AdminID"] = adminuserinfo.AdminID;
                    Session["AdminUserName"] = p.AdminUserName; // tekrar bakılacak, veritabanından hash den dönüştürülerek denenecek
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
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
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
                p.AdminSalt = gizle.Salt;
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

        readonly WriterManager wm = new WriterManager(new EfWriterDal());
        readonly WriterLoginValidator WriterLoginValidator = new WriterLoginValidator();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult YazarGiris()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult YazarGiris(Writer p, string ReturnUrl)
        {
            ValidationResult results = WriterLoginValidator.Validate(p);
            if (results.IsValid)
            {
                // var crypto = new SimpleCrypto.PBKDF2();
                // var writeruserinfo = wm.YazarListeGetir().Where(x => x.WriterMail == crypto.Compute(p.WriterMail, x.WriterSalt) && x.WriterPassword == crypto.Compute(p.WriterPassword, x.WriterSalt)).FirstOrDefault();
                var writeruserinfo = wm.YazarListeGetir().Where(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword).FirstOrDefault();
                if (writeruserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                    Session["WriterID"] = writeruserinfo.WriterID;
                    Session["WriterMail"] = writeruserinfo.WriterMail;
                    Session["WriterName"] = writeruserinfo.WriterName;
                    Session["WriterSurname"] = writeruserinfo.WriterSurName;
                    Session["WriterTitle"] = writeruserinfo.WriterTitle;

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Profilim", "WriterPanel");
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
    }
}