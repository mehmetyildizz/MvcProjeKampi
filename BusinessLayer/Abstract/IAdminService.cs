﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> AdminListeGetir();
        
        List<Admin> AdminGetir(Admin admin);

        void AdminEkle(Admin admin);

        Admin AdminIDGetir(int id);

        void AdminSil(Admin admin);

        void AdminGuncelle(Admin admin);
    }
}