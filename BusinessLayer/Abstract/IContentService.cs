using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> YaziListeGetir();

        List<Content> YaziListeBaslikIDGetir(int id);

        void YaziEkle(Content content);

        Writer YaziIDGetir(int id);

        void YaziSil(Content content);

        void YaziGuncelle(Content content);
    }
}
