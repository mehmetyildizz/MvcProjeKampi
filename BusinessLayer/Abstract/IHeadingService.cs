﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> BaslikListeGetir();
        
        List<Heading> YazarBaslikListeGetir(int id);

        void BaslikEkle(Heading Heading);

        Heading BaslikIDGetir(int id);

        void BaslikSil(Heading Heading);

        void BaslikGuncelle(Heading Heading);
    }
}
