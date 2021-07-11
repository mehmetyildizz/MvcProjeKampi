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

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        readonly AdminValidator adminValidator = new AdminValidator();

        public ActionResult Index()
        {
            var admindeger = am.AdminListeGetir();
            return View(admindeger);
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
                //var SifresizKullaniciAdi = gizle.Compute(p.AdminUserName);
                var SifresizSifre = gizle.Compute(p.AdminPassword);

                //p.AdminUserName = SifresizKullaniciAdi;
                p.AdminPassword = SifresizSifre;
                p.AdminSalt = gizle.Salt;
                am.AdminEkle(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admindeger = am.AdminIDGetir(id);
            if (admindeger.AdminRole != "B" && admindeger.AdminUserName == (string)Session["AdminUserName"])
            {
                return View(admindeger);
            }
            // yetkisiz giriş uyarısı eklenecek
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AdminGuncelle(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                am.AdminGuncelle(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult AdminSifreGuncelle(int id)
        {
            var admindeger = am.AdminIDGetir(id);
            if (admindeger.AdminRole != "B" && admindeger.AdminUserName == (string)Session["AdminUserName"])
            {
                return View(admindeger);
            }
            // yetkisiz giriş uyarısı eklenecek
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AdminSifreGuncelle(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                var gizle = new SimpleCrypto.PBKDF2();
                var SifreliSifre = gizle.Compute(p.AdminPassword);

                p.AdminPassword = SifreliSifre;
                p.AdminSalt = gizle.Salt;

                am.AdminGuncelle(p);
                return RedirectToAction("Index");
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

        public ActionResult AdminSil(int id)
        {
            var admindeger = am.AdminIDGetir(id);
            am.AdminSil(admindeger);
            return RedirectToAction("Index");
        }
    }
}