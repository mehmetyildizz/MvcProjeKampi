using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public T AlGetir(Expression<Func<T, bool>> Filtre)
        {
            return _object.SingleOrDefault(Filtre);
        }

        public void Ekle(T p)
        {
            var AddedEntity = c.Entry(p);
            AddedEntity.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }

        public void Guncelle(T p)
        {
            var UpdatedEntity = c.Entry(p);
            UpdatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> Listele()
        {
            return _object.ToList();
        }

        public List<T> Listele(Expression<Func<T, bool>> Filtre)
        {
            return _object.Where(Filtre).ToList();
        }

        public void Sil(T p)
        {
            var DeletedEntity = c.Entry(p);
            DeletedEntity.State = EntityState.Deleted;
            // _object.Remove(p);
            c.SaveChanges();
        }
    }
}
