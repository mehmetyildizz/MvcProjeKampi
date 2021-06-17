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
    public class TalentController : Controller
    {
        TalentManager tm = new TalentManager(new EfTalentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        TalentValidator talentValidator = new TalentValidator();

        public ActionResult Index()
        {
            var yetenekdegerleri = tm.YetenekListeGetir();
            return View(yetenekdegerleri);
        }

        public ActionResult YetenekKarti(int id)
        {
            var yetenekdeger = tm.YetenekListeYazarIDGetir(id);
            return View(yetenekdeger);
        }

        public ActionResult YetenekAktifPasif(int id)
        {
            var yetenekdeger = tm.YetenekIDGetir(id);
            if (yetenekdeger.TalentStatus == false)
            {
                yetenekdeger.TalentStatus = true;
            }
            else
            {
                yetenekdeger.TalentStatus = false;
            };
            tm.YetenekAktifPasif(yetenekdeger);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
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

            ViewBag.Yzr = yazardeger;
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(Talent p)
        {
            ValidationResult results = talentValidator.Validate(p);
            if (results.IsValid)
            {
                p.TalentStatus = true;
                tm.YetenekEkle(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

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

            ViewBag.Yzr = yazardeger;

            return View();
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            List<SelectListItem> yazardeger = (from x in wm.YazarListeGetir()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName,
                                                   Value = x.WriterID.ToString()
                                               }).ToList();
            ViewBag.Yzr = yazardeger; 
            
            var YetenekDegeri = tm.YetenekIDGetir(id);
            return View(YetenekDegeri);
        }

        [HttpPost]
        public ActionResult YetenekGuncelle(Talent p)
        {
            tm.YetenekGuncelle(p);
            return RedirectToAction("Index");
        }
    }
}