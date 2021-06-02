using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> IletisimListeGetir();

        void IletisimEkle(Contact contact);

        Contact IletisimIDGetir(int id);

        void IletisimSil(Contact contact);

        void IletisimGuncelle(Contact contact);
    }
}
