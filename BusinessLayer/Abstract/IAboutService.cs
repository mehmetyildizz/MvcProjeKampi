using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> HakkindaListeGetir();

        void HakkindaEkle(About about);

        About HakkindaIDGetir(int id);

        void HakkindaSil(About about);

        void HakkindaGuncelle(About about);
    }
}
