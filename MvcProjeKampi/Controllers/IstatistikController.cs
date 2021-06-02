using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            var TopKtgrSayisi = context.Categories.Count();
            
            // Yazılım Kategori ID = 13
            var YzlmBslkSayisi = context.Headings.Count(x => x.CategoryID == 13);

            var YzrAdiIcindeA = context.Writers.Count(y => y.WriterName.Contains("a"));

            var MaxTitleOfCat = context.Categories.Where(z => z.CategoryID == context.Headings.GroupBy(a => a.CategoryID).OrderByDescending(b => b.Count()).Select(c => c.Key).FirstOrDefault()).Select(d => d.CategoryName).FirstOrDefault();

            var KatTFfarki = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);

            ViewBag.TopKtgrSayisi = TopKtgrSayisi;
            ViewBag.YzlmBslkSayisi = YzlmBslkSayisi;
            ViewBag.YzrAdiIcindeA = YzrAdiIcindeA;
            ViewBag.MaxTitleOfCat = MaxTitleOfCat;
            ViewBag.KatTFfarki = KatTFfarki;

            return View();
        }
    }
}