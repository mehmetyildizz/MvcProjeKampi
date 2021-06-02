using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> YazarListeGetir();

        void YazarEkle(Writer writer);

        Writer YazarIDGetir(int id);

        void YazarSil(Writer writer);

        void YazarGuncelle(Writer writer);
    }
}
