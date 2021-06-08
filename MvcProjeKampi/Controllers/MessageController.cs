using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public ActionResult SilinenMesajlar()
        {
            var mesajlistesi = mm.MesajListeGetirSilinen();
            return View(mesajlistesi);
        }

        public ActionResult TaslakMesajlar()
        {
            var mesajlistesi = mm.MesajListeGetirTaslak();
            return View(mesajlistesi);
        }

        [HttpGet]
        public ActionResult YeniMesajGonder()
        {
            return View();
        }


        [HttpPost, ValidateInput(false)]
        [MultipleButton(Name = "mesaj", Argument = "Gonder")]
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

        [HttpPost, ValidateInput(false)]
        [MultipleButton(Name = "mesaj", Argument = "Taslak")]
        public ActionResult Taslak(Message p)
        {
            p.MessageSender = "admin@yandex.com";
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.MessageStatusDraft = true;
            mm.MesajEkle(p);
            return RedirectToAction("TaslakMesajlar");
        }


        //public ActionResult YeniMesajGonder(Message p)
        //{
        //    ValidationResult results = messageValidator.Validate(p);
        //    if (results.IsValid)
        //    {
        //        p.MessageSender = "admin@yandex.com";
        //        p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //        mm.MesajEkle(p);
        //        return RedirectToAction("GidenKutusu");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

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

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }
    }
}