using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void IletisimEkle(Contact contact)
        {
            _contactDal.Ekle(contact);
        }

        public void IletisimGuncelle(Contact contact)
        {
            _contactDal.Guncelle(contact);
        }

        public Contact IletisimIDGetir(int id)
        {
            return _contactDal.AlGetir(x => x.ContactID == id);
        }

        public List<Contact> IletisimListeGetir()
        {
            return _contactDal.Listele();
        }

        public void IletisimSil(Contact contact)
        {
            _contactDal.Sil(contact);
        }
    }
}
