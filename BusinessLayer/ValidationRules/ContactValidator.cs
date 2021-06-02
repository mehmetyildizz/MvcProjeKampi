using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Olamaz.");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçerli Bir Mail Adresi Yazınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj Başlığı Boş Olamaz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Mesaj Başlığı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Mesaj Başlığı En Fazla 20 Karakter Olmalı.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Kullanıcı Adı En Fazla 20 Karakter Olmalı.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Olamaz.");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Mesaj En Az 3 Karakter Olmalı.");
        }
    }
}
