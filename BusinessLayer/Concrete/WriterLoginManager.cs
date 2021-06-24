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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer YazarGetir(string kullaniciadi, string sifre)
        {
            return _writerDal.AlGetir(x => x.WriterMail == kullaniciadi && x.WriterPassword == sifre);
        }
    }
}
