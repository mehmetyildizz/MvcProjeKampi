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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        HeadingValidator HeadingValidator = new HeadingValidator();
        public ActionResult Index()
        {
            var HeadingDegerleri = hm.BaslikListeGetir();
            return View(HeadingDegerleri);
        }

        [HttpGet]
        public ActionResult BaslikEkle()
        {
            List<SelectListItem> kategorideger = (from x in cm.KategoriListeGetir()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryID.ToString()
                                                  }).ToList();
            kategorideger.Insert(0, new SelectListItem()
            {
                Text = "Kategori Seçiniz...",
                Value = "0"
            });

            List<SelectListItem> yazardeger = (from x in wm.YazarListeGetir()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            yazardeger.Insert(0, new SelectListItem()
            {
                Text = "Yazar Seçiniz...",
                Value = "0"
            });

            ViewBag.Ktgr = kategorideger;
            ViewBag.Yzr = yazardeger;
            return View();
        }

        [HttpPost]
        public ActionResult BaslikEkle(Heading p)
        {
            ValidationResult results = HeadingValidator.Validate(p);
            if (results.IsValid)
            {
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.BaslikEkle(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> kategorideger = (from x in cm.KategoriListeGetir()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            kategorideger.Insert(0, new SelectListItem()
            {
                Text = "Kategori Seçiniz...",
                Value = "0"
            });

            List<SelectListItem> yazardeger = (from x in wm.YazarListeGetir()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurName,
                                                   Value = x.WriterID.ToString()
                                               }).ToList();
            yazardeger.Insert(0, new SelectListItem()
            {
                Text = "Yazar Seçiniz...",
                Value = "0"
            });

            ViewBag.Ktgr = kategorideger;
            ViewBag.Yzr = yazardeger;

            return View();
        }
        
        [HttpGet]
        public ActionResult BaslikGuncelle(int id)
        {
            List<SelectListItem> kategorideger = (from x in cm.KategoriListeGetir()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.Ktgr = kategorideger;
            
            List<SelectListItem> yazardeger = (from x in wm.YazarListeGetir()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.Yzr = yazardeger;

            var BaslikDegeri = hm.BaslikIDGetir(id);
            return View(BaslikDegeri);
        }

        [HttpPost]
        public ActionResult BaslikGuncelle(Heading p)
        {
            hm.BaslikGuncelle(p);
            return RedirectToAction("Index");
        }

        public ActionResult BaslikSil(int id)
        {
            var baslikdeger = hm.BaslikIDGetir(id);
            if (baslikdeger.HeadingStatus == false)
            {
                baslikdeger.HeadingStatus = true;
            }
            else
            {
                baslikdeger.HeadingStatus = false;
            };
            hm.BaslikSil(baslikdeger);
            return RedirectToAction("Index");
        }
    }
}