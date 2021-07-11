using EntityLayer.Concrete;
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
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("Admin Kullanıcı Adı, Geçerli Bir Mail Adresi Olmalıdır.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Parola Boş Olamaz.");
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Admin Adı Boş Olamaz.");
            RuleFor(x => x.AdminName).MinimumLength(3).WithMessage("Admin Adı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.AdminName).MaximumLength(20).WithMessage("Admin Adı En Fazla 20 Karakter Olmalı.");
            RuleFor(x => x.AdminSurname).NotEmpty().WithMessage("Admin Soyadı Boş Olamaz.");
            RuleFor(x => x.AdminSurname).MinimumLength(3).WithMessage("Admin Soyadı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.AdminSurname).MaximumLength(20).WithMessage("Admin Soyadı En Fazla 20 Karakter Olmalı.");
            RuleFor(x => x.AdminRole).NotEqual("0").WithMessage("Admin Rol Seçmelisiniz.");
        }
    }
    public class LoginValidator : AbstractValidator<Admin>
    {
        public LoginValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin Kullanıcı Adı Boş Olamaz.");
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("Admin Kullanıcı Adı, Geçerli Bir Mail Adresi Olmalıdır.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Parola Boş Olamaz.");
            RuleFor(x => x.AdminPassword).MinimumLength(2).WithMessage("Parola En Az 2 Karakter Olmalı.");
        }
    }
}
