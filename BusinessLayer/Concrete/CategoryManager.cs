using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category KategoriIDGetir(int id)
        {
            return _categoryDal.AlGetir(x => x.CategoryID == id);
        }
        
        public void KategoriEkle(Category category)
        {
            _categoryDal.Ekle(category);
        }

        public void KategoriGuncelle(Category category)
        {
            _categoryDal.Guncelle(category);
        }

        public List<Category> KategoriListeGetir()
        {
            return _categoryDal.Listele();
        }

        public void KategoriSil(Category category)
        {
            _categoryDal.Sil(category);
        }
    }
}
