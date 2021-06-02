using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı En Az 2 Karakter Olmalı.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar Adı En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Olamaz.");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar Soyadı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar E-mail Adresi Boş Olamaz.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli Bir E-mail Adersi Yazınız.");
            RuleFor(x => x.WriterMail).MaximumLength(50).WithMessage("Yazar E-mail Adresi En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola Boş Olamaz.");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Parola En Az 6 Karakter Olmalı.");
            RuleFor(x => x.WriterPassword).MaximumLength(50).WithMessage("Parola En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı Boş Olamaz.");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Yazar Ünvanı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazar Ünvanı En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Bilgiler Boş Olamaz.");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Yazar Hakkında Bilgiler En Az 3 Karakter Olmalı.");
            RuleFor(x => x.WriterAbout).MaximumLength(50).WithMessage("Yazar Hakkında Bilgiler En Fazla 50 Karakter Olmalı."); 
            RuleFor(x => x.WriterAbout).Matches("[Aa]").WithMessage("Yazar Hakkında Bilgiler İçerisinde 'a' Harfi Olmalıdır.");
        }
    }
}
