using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        readonly MessageManager mm = new MessageManager(new EfMessageDal());
        readonly MessageValidator messageValidator = new MessageValidator();
        readonly Context context = new Context();

        public ActionResult GelenKutusu()
        {
            string yazarmail = (string)Session["WriterMail"];
            var mesajlistesi = mm.MesajListeGetirGelen(yazarmail);
            return View(mesajlistesi);
        }

        public ActionResult GidenKutusu()
        {
            string yazarmail = (string)Session["WriterMail"];
            var mesajlistesi = mm.MesajListeGetirGiden(yazarmail);
            return View(mesajlistesi);
        }

        public ActionResult SilinenMesajlar()
        {
            string yazarmail = (string)Session["WriterMail"];
            var mesajlistesi = mm.MesajListeGetirSilinen(yazarmail);
            return View(mesajlistesi);
        }

        public ActionResult TaslakMesajlar()
        {
            string yazarmail = (string)Session["WriterMail"];
            var mesajlistesi = mm.MesajListeGetirTaslak(yazarmail);
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
                p.MessageSender = Convert.ToString(Session["WriterMail"]);
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
            p.MessageSender = Convert.ToString(Session["WriterMail"]);
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.MessageStatusDraft = true;
            mm.MesajEkle(p);
            return RedirectToAction("TaslakMesajlar");
        }

        public ActionResult GelenMesajDetay(int id)
        {
            var GelenMesajDetay = mm.MesajIDGetir(id);
            GelenMesajDetay.MessageStatusRead = true;
            mm.MesajGuncelle(GelenMesajDetay);
            return View(GelenMesajDetay);
        }

        public ActionResult GidenMesajDetay(int id)
        {
            var GidenMesajDetay = mm.MesajIDGetir(id);
            GidenMesajDetay.MessageStatusRead = true;
            mm.MesajGuncelle(GidenMesajDetay);
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

        public ActionResult KaliciMesajSil(int id)
        {
            var mesajdeger = mm.MesajIDGetir(id);
            mm.MesajKaliciSil(mesajdeger);
            return RedirectToAction("SilinenMesajlar");
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

        public PartialViewResult MesajKlasorPartial()
        {
            string WriterMail = Session["WriterMail"].ToString();

            var GelenMesajSayisi = context.Messages.Count(x => x.MessageReciever == WriterMail && x.MessageStatusReceiver == false).ToString();
            ViewBag.mesajsayisiGelen = GelenMesajSayisi;
            var GelenMesajYeni = context.Messages.Count(x => x.MessageReciever == WriterMail && x.MessageStatusReceiver == false && x.MessageStatusRead == false).ToString();
            ViewBag.yenimesajGelen = GelenMesajYeni;

            var GidenMesajSayisi = context.Messages.Count(x => x.MessageSender == WriterMail && x.MessageStatusSender == false && x.MessageStatusDraft == false).ToString();
            ViewBag.mesajsayisiGiden = GidenMesajSayisi;

            var TaslakMesajSayisi = context.Messages.Count(x => x.MessageStatusDraft == true && x.MessageSender == WriterMail).ToString();
            ViewBag.mesajsayisiTaslak = TaslakMesajSayisi;

            var SilinenMesajSayisi = context.Messages.Count(x => (x.MessageStatusSender == true && x.MessageSender == WriterMail) || (x.MessageStatusReceiver == true && x.MessageReciever == WriterMail)).ToString();
            ViewBag.mesajsayisiSilinen = SilinenMesajSayisi;
            var SilinenMesajYeni = context.Messages.Count(x => ((x.MessageStatusSender == true && x.MessageSender == WriterMail) || (x.MessageStatusReceiver == true && x.MessageReciever == WriterMail)) && x.MessageStatusRead == false).ToString();
            ViewBag.yenimesajSilinen = SilinenMesajYeni;

            return PartialView();
        }
    }
}