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

        public ActionResult Basliklar()
        {
            var baslikListe = hm.BaslikListeGetir();
            return View(baslikListe);
        }

        public PartialViewResult Index(int id = 0)
        {
            var yaziListe = cm.YaziListeBaslikIDGetir(id);
            return PartialView(yaziListe);
        }
    }
}