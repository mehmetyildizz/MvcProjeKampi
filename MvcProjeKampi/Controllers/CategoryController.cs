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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        public ActionResult Index()
        {
            var KategoriDegerler = cm.KategoriListeGetir();
            return View(KategoriDegerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category p)
        {
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.KategoriEkle(p);
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
        public ActionResult KategoriDuzenle(int id)
        {
            var kategorideger = cm.KategoriIDGetir(id);
            return View(kategorideger);
        }

        [HttpPost]
        public ActionResult KategoriDuzenle(Category p)
        {
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.KategoriGuncelle(p);
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

        public ActionResult KategoriSil(int id)
        {
            var kategorideger = cm.KategoriIDGetir(id);
            cm.KategoriSil(kategorideger);
            return RedirectToAction("Index");
        }
    }
}