using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> YetenekListeGetir();

        void YetenekEkle(Talent talent);

        Talent YetenekIDGetir(int id);

        void YetenekSil(Talent talent);

        void YetenekGuncelle(Talent talent);
    }
}
