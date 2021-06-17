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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public void YetenekEkle(Talent talent)
        {
            _talentDal.Ekle(talent);
        }

        public void YetenekGuncelle(Talent talent)
        {
            _talentDal.Guncelle(talent);
        }

        public Talent YetenekIDGetir(int id)
        {
            return _talentDal.AlGetir(x => x.TalentID == id);
        }

        public List<Talent> YetenekListeGetir()
        {
            return _talentDal.Listele();
        }

        public void YetenekSil(Talent talent)
        {
            _talentDal.Sil(talent);
        }

        public void YetenekAktifPasif(Talent talent)
        {
            _talentDal.Guncelle(talent);
        }

        public List<Talent> YetenekListeYazarIDGetir(int id)
        {
            return _talentDal.Listele(x => x.WriterID == id && x.TalentStatus == true);
        }
    }
}
