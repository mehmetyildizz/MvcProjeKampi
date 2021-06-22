using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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

        public ActionResult Yazilarim()
        {
            Context c = new Context();
            var yazarIDdeger = c.Writers.Where(x => x.WriterMail == (string)Session["WriterMail"]).Select(y => y.WriterID).FirstOrDefault();
            // var yazideger = cm.YaziListeYazarIDGetir(Convert.ToInt32(Session["WriterID"]));
            var yazideger = cm.YaziListeYazarIDGetir(yazarIDdeger);
            return View(yazideger);
        }
    }
}