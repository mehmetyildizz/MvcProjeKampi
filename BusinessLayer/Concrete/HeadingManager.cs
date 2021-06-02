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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void BaslikEkle(Heading heading)
        {
            _headingDal.Ekle(heading);
        }

        public void BaslikGuncelle(Heading heading)
        {
            _headingDal.Guncelle(heading);
        }

        public Heading BaslikIDGetir(int id)
        {
            return _headingDal.AlGetir(x => x.HeadingID == id);
        }

        public List<Heading> BaslikListeGetir()
        {
            return _headingDal.Listele();
        }

        public void BaslikSil(Heading heading)
        {
            _headingDal.Guncelle(heading);
        }
    }
}
