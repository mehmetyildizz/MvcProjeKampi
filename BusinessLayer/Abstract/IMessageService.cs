using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMessageService
    {
        List<Message> MesajListeGetirGelen();
        
        List<Message> MesajListeGetirGiden();

        void MesajEkle(Message message);

        Message MesajIDGetir(int id);

        void MesajSil(Message message);

        void MesajGuncelle(Message message);
    }
}
