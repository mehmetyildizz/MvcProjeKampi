using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        ContentValidator contentValidator = new ContentValidator();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yazilar()
        {
            var yazideger = cm.YaziTumListeGetir();
            return View(yazideger);
        }

        public ActionResult TumYazilar(string p)
        {
            var yazideger = cm.YaziListeGetir(p);
            if (!string.IsNullOrEmpty(p))
            {
                yazideger = cm.YaziListeGetir(p);
            }
            return View(yazideger);
        }

        public ActionResult BasligaAitYazilar(int id)
        {
            var yazideger = cm.YaziListeBaslikIDGetir(id);
            return View(yazideger);
        }
    }
}