﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> MesajListeGetirGelen(string yazarmail);

        List<Message> MesajListeGetirGiden(string yazarmail);

        List<Message> MesajListeGetirSilinen(string yazarmail);

        List<Message> MesajListeGetirTaslak(string yazarmail);

        void MesajEkle(Message message);

        Message MesajIDGetir(int id);

        void MesajSil(Message message);

        void MesajKaliciSil(Message message);

        void MesajGuncelle(Message message);
    }
}
