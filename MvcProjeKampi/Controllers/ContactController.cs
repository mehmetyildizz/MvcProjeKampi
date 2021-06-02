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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var IletisimDegerler = cm.IletisimListeGetir();
            return View(IletisimDegerler);
        }

        public ActionResult IletisimDetay(int id)
        {
            var IletisimDetay = cm.IletisimIDGetir(id);
            return View(IletisimDetay);
        }

        public PartialViewResult MesajKlasorPartial()
        {
            return PartialView();
        }
    }
}