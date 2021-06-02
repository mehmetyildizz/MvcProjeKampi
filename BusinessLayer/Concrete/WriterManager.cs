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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void YazarEkle(Writer writer)
        {
            _writerDal.Ekle(writer);
        }

        public void YazarGuncelle(Writer writer)
        {
            _writerDal.Guncelle(writer);
        }

        public Writer YazarIDGetir(int id)
        {
            return _writerDal.AlGetir(x => x.WriterID == id);
        }

        public List<Writer> YazarListeGetir()
        {
            return _writerDal.Listele();
        }

        public void YazarSil(Writer writer)
        {
            _writerDal.Sil(writer);
        }
    }
}