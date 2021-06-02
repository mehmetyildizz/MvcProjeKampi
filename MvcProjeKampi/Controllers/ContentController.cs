﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BasligaAitYazilar(int id)
        {
            var yazideger = cm.YaziListeBaslikIDGetir(id);
            return View(yazideger);
        }
    }
}