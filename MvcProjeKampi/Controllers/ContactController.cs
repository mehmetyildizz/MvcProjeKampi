﻿using BusinessLayer.Concrete;
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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        Context context = new Context();

        public ActionResult Index()
        {
            var IletisimDegerler = cm.IletisimListeGetir();
            return View(IletisimDegerler);
        }

        public ActionResult IletisimDetay(int id)
        {
            var IletisimDetay = cm.IletisimIDGetir(id);
            IletisimDetay.ContactStatusRead = true;
            cm.IletisimGuncelle(IletisimDetay);
            return View(IletisimDetay);
        }

        public PartialViewResult MesajKlasorPartial()
        {
            var IletisimMesajSayiyisi = context.Contacts.Count().ToString();
            ViewBag.mesajsayisiIletisim = IletisimMesajSayiyisi;
            var IletisimMesajYeni = context.Contacts.Count(x => x.ContactStatusRead == false).ToString();
            ViewBag.yenimesajIletisim = IletisimMesajYeni;

            var GelenMesajSayisi = context.Messages.Count(x => x.MessageReciever == "admin@yandex.com" && x.MessageStatusReceiver == false).ToString();
            ViewBag.mesajsayisiGelen = GelenMesajSayisi;
            var GelenMesajYeni = context.Messages.Count(x => x.MessageReciever == "admin@yandex.com" && x.MessageStatusReceiver == false && x.MessageStatusRead == false).ToString();
            ViewBag.yenimesajGelen = GelenMesajYeni;

            var GidenMesajSayisi = context.Messages.Count(x => x.MessageSender == "admin@yandex.com" && x.MessageStatusSender == false).ToString();
            ViewBag.mesajsayisiGiden = GidenMesajSayisi;

            var TaslakMesajSayisi = context.Messages.Count(x => x.MessageStatusDraft == true).ToString();
            ViewBag.mesajsayisiTaslak = TaslakMesajSayisi;

            var SilinenMesajSayisi = context.Messages.Count(x => x.MessageStatusReceiver == true || x.MessageStatusSender == true).ToString();
            ViewBag.mesajsayisiSilinen = SilinenMesajSayisi;
            var SilinenMesajYeni = context.Messages.Count(x => (x.MessageStatusReceiver == true || x.MessageStatusSender == true) && x.MessageStatusRead == false).ToString();
            ViewBag.yenimesajSilinen = SilinenMesajYeni;

            return PartialView();
        }

        public ActionResult IletisimSil(int id)
        {
            var iletisimdeger = cm.IletisimIDGetir(id);
            iletisimdeger.ContactStatus = true;
            cm.IletisimSil(iletisimdeger);
            return RedirectToAction("GidenKutusu");
        }
    }
}