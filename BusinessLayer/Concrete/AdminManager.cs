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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminEkle(Admin admin)
        {
            _adminDal.Ekle(admin);
        }

        public void AdminGuncelle(Admin admin)
        {
            _adminDal.Guncelle(admin);
        }

        public Admin AdminIDGetir(int id)
        {
            return _adminDal.AlGetir(x => x.AdminID == id);
        }

        public List<Admin> AdminListeGetir()
        {
            return _adminDal.Listele();
        }

        public Admin AdminGetir(string username, string password)
        {
            return _adminDal.AlGetir(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public Admin AdminUserGetir(string username)
        {
            return _adminDal.AlGetir(x => x.AdminUserName == username);
        }

        public void AdminSil(Admin admin)
        {
            _adminDal.Sil(admin);
        }
    }
}
