using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı Boş Olamaz.");
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Başlık Adı En Az 2 Karakter Olmalı.");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık Adı En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.CategoryID).NotEqual(0).WithMessage("Kategori Adı Seçmelisiniz.");
            RuleFor(x => x.WriterID).NotEqual(0).WithMessage("Yazar Adı Seçmelisiniz.");
        }
    }

    public class WriterHeadingValidator : AbstractValidator<Heading>
    {
        public WriterHeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı Boş Olamaz.");
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Başlık Adı En Az 2 Karakter Olmalı.");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık Adı En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.CategoryID).NotEqual(0).WithMessage("Kategori Adı Seçmelisiniz.");
        }
    }
}