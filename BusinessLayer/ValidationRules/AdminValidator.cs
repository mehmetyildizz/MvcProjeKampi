﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin Kullanıcı Adı Boş Olamaz.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Parola Boş Olamaz.");
        }
    }
}
