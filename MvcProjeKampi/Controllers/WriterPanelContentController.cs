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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        ContentValidator contentValidator = new ContentValidator();
        int writerIDsession = 1;

        public ActionResult Yazilarim()
        {
            var yazideger = cm.YaziListeYazarIDGetir(writerIDsession); // WriterID session dan alınacak
            return View(yazideger);
        }
    }
}