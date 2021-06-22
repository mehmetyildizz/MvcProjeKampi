using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterHeadingValidator WriterHeadingValidator = new WriterHeadingValidator();

        public ActionResult Profilim()
        {
            return View();
        }

        public ActionResult Basliklarim()
        {
            Context c = new Context();
            string p1 = (string)Session["WriterMail"];
            var yazarIDdeger = c.Writers.Where(x => x.WriterMail == p1).Select(y => y.WriterID).FirstOrDefault();
            // var myheadingdeger = hm.BaslikListeYazarIDGetir(Convert.ToInt32(Session["WriterID"]));
            var myheadingdeger = hm.BaslikListeYazarIDGetir(yazarIDdeger);
            return View(myheadingdeger);
        }

        [HttpGet]
        public ActionResult BaslikEkle()
        {
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

            ViewBag.Ktgr = kategorideger;
            return View();
        }

        [HttpPost]
        public ActionResult BaslikEkle(Heading p)
        {
            ValidationResult results = WriterHeadingValidator.Validate(p);
            if (results.IsValid)
            {
                Context c = new Context();
                string p1 = (string)Session["WriterMail"];
                var yazarIDdeger = c.Writers.Where(x => x.WriterMail == p1).Select(y => y.WriterID).FirstOrDefault();

                p.WriterID = yazarIDdeger;
                // p.WriterID = Convert.ToInt32(Session["WriterID"]);
                p.HeadingStatus = true;
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.BaslikEkle(p);
                return RedirectToAction("Basliklarim");
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

            ViewBag.Ktgr = kategorideger;

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

            var BaslikDegeri = hm.BaslikIDGetir(id);
            return View(BaslikDegeri);
        }

        [HttpPost]
        public ActionResult BaslikGuncelle(Heading p)
        {
            Context c = new Context();
            string p1 = (string)Session["WriterMail"];
            var yazarIDdeger = c.Writers.Where(x => x.WriterMail == p1).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID = yazarIDdeger;
            // p.WriterID = Convert.ToInt32(Session["WriterID"]);
            p.HeadingStatus = true;
            hm.BaslikGuncelle(p);
            return RedirectToAction("Basliklarim");
        }

        public ActionResult BaslikSil(int id)
        {
            var baslikdeger = hm.BaslikIDGetir(id);
            baslikdeger.HeadingStatus = false;
            hm.BaslikSil(baslikdeger);
            return RedirectToAction("Basliklarim");
        }
    }
}