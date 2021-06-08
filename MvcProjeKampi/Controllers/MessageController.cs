﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator messageValidator = new MessageValidator();

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

        [HttpPost, ValidateInput(false)]
        public ActionResult YeniMesajGonder(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageSender = "admin@yandex.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MesajEkle(p);
                return RedirectToAction("GidenKutusu");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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

        public ActionResult GidenMesajSil(int id)
        {
            var mesajdeger = mm.MesajIDGetir(id);
            mesajdeger.MessageStatusSender = true;
            mm.MesajSil(mesajdeger);
            return RedirectToAction("GidenKutusu");
        }

        public ActionResult GelenMesajSil(int id)
        {
            var mesajdeger = mm.MesajIDGetir(id);
            mesajdeger.MessageStatusReceiver = true;
            mm.MesajSil(mesajdeger);
            return RedirectToAction("GelenKutusu");
        }
    }
}