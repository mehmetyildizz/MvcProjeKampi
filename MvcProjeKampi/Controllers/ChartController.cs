using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult PastaGrafik()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(KategoriList(), JsonRequestBehavior.AllowGet);
        }

        public List<ChartClass> KategoriList()
        {
            List<ChartClass> ct = new List<ChartClass>();
            ct.Add(new ChartClass()
            {
                KategoriAdi = "Yazılım",
                KategoriSayisi = 8
            });

            ct.Add(new ChartClass()
            {
                KategoriAdi = "Seyahat",
                KategoriSayisi = 4
            });

            ct.Add(new ChartClass()
            {
                KategoriAdi = "Teknoloji",
                KategoriSayisi = 7
            });

            ct.Add(new ChartClass()
            {
                KategoriAdi = "Spor",
                KategoriSayisi = 1
            });

            return ct;
        }

        public ActionResult SutunGrafik()
        {
            return View();
        }

        public ActionResult BaslikChart()
        {
            return Json(BaslikList(), JsonRequestBehavior.AllowGet);
        }

        public List<ChartClass> BaslikList()
        {
            List<ChartClass> ct = new List<ChartClass>();
            using (var context = new Context())
            {
                var BaslikDegerleri = context.Headings.Select(x => new ChartClass
                {
                    BaslikAdi = x.HeadingName,
                    BaslikYaziSayisi = x.Contents.Count(),
                });
                ct = BaslikDegerleri.ToList();
                return ct;
            }
        }

        public ActionResult CizgiGrafik()
        {
            return View();
        }

        public ActionResult YazarChart()
        {
            return Json(YazarList(), JsonRequestBehavior.AllowGet);
        }

        public List<ChartClass> YazarList()
        {
            List<ChartClass> ct = new List<ChartClass>();
            using (var context = new Context())
            {
                var YazarDegerleri = context.Writers.Select(x => new ChartClass
                {
                    YazarAdi = x.WriterName + " " + x.WriterSurName,
                    YazarYaziSayisi = x.Contents.Count(),
                });
                ct = YazarDegerleri.ToList();
                return ct;
            }
        }
    }
}