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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var YazarDegerleri = wm.YazarListeGetir();
            return View(YazarDegerleri);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                //var gizle = new SimpleCrypto.PBKDF2();
                //var SifresizKullaniciAdi = gizle.Compute(p.WriterMail);
                //var SifresizSifre = gizle.Compute(p.WriterPassword);

                //p.WriterMail = SifresizKullaniciAdi;
                //p.WriterPassword = SifresizSifre;
                //p.WriterSalt = gizle.Salt;
                wm.YazarEkle(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult YazarGuncelle(int id)
        {
            var YazarDegerleri = wm.YazarIDGetir(id);
            return View(YazarDegerleri);
        }

        [HttpPost]
        public ActionResult YazarGuncelle(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.YazarGuncelle(p);
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
    }
}