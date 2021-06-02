using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> Listele();

        void Ekle(T p);

        void Guncelle(T p);

        T AlGetir(Expression<Func<T, bool>> Filtre);
        void Sil(T p);

        List<T> Listele(Expression<Func<T, bool>> Filtre);
    }
}
