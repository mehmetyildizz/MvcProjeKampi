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

        public ActionResult Index()
        {
            var baslikListe = hm.BaslikListeGetir();
            return View(baslikListe);
        }

        public ActionResult Basliklar()
        {
            return View();
        }
    }
}