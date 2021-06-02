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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void HakkindaEkle(About about)
        {
            _aboutDal.Ekle(about);
        }

        public void HakkindaGuncelle(About about)
        {
            _aboutDal.Guncelle(about);
        }

        public About HakkindaIDGetir(int id)
        {
            return _aboutDal.AlGetir(x => x.AboutID == id);
        }

        public List<About> HakkindaListeGetir()
        {
            return _aboutDal.Listele();
        }

        public void HakkindaSil(About about)
        {
            _aboutDal.Sil(about);
        }
    }
}