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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());

        public ActionResult GelenKutusu()
        {
            var mesajlistesi = mm.MesajListeGetirGelen();
            return View(mesajlistesi);
        }

        public ActionResult GidenKutusu()
        {
            var mesajlistesi = mm.MesajListeGetirGiden();
            return View(mesajlistesi);
        }

        [HttpGet]
        public ActionResult YeniMesajGonder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesajGonder(Message p)
        {
            
            return RedirectToAction("Index");
        }

        public ActionResult GelenMesajDetay(int id)
        {
            var GelenMesajDetay = mm.MesajIDGetir(id);
            return View(GelenMesajDetay);
        }

        public ActionResult GidenMesajDetay(int id)
        {
            var GidenMesajDetay = mm.MesajIDGetir(id);
            return View(GidenMesajDetay);
        }
    }
}