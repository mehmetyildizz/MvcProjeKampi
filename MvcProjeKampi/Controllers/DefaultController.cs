using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public PartialViewResult Index()
        {
            var yaziListe = cm.YaziListeGetir();
            return PartialView(yaziListe);
        }

        public ActionResult Basliklar()
        {
            var baslikListe = hm.BaslikListeGetir();
            return View(baslikListe);
        }
    }
}