using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var HakkindaDegerler = am.HakkindaListeGetir();
            return View(HakkindaDegerler);
        }

        [HttpGet]
        public ActionResult HakkindaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HakkindaEkle(About p)
        {
            am.HakkindaEkle(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult HakkindaPartial()
        {
            return PartialView();
        }
    }
}