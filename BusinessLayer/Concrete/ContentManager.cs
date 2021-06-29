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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void YaziEkle(Content content)
        {
            _contentDal.Ekle(content);
        }

        public void YaziGuncelle(Content content)
        {
            throw new NotImplementedException();
        }

        public Writer YaziIDGetir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> YaziListeGetir(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return _contentDal.Listele(x => x.ContentValue.Contains(p));
            }
            return _contentDal.Listele();
        }

        public List<Content> YaziListeBaslikIDGetir(int id)
        {
            return _contentDal.Listele(x => x.HeadingID == id);
        }

        public List<Content> YaziListeYazarIDGetir(int id)
        {
            return _contentDal.Listele(x => x.WriterID == id);
        }

        public void YaziSil(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
