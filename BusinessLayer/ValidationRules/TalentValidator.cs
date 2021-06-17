using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TalentValidator : AbstractValidator<Talent>
    {
        public TalentValidator()
        {
            RuleFor(x => x.TalentName).NotEmpty().WithMessage("Yetenek Adı Boş Olamaz.");
            RuleFor(x => x.TalentName).MinimumLength(3).WithMessage("Yetenek Adı En Az 3 Karakter Olmalı.");
            RuleFor(x => x.TalentName).MaximumLength(25).WithMessage("Yetenek Adı En Fazla 25 Karakter Olmalı.");
            RuleFor(x => x.TalentValue).NotEmpty().WithMessage("Yetenek Seviyesi Boş Olamaz.");
            RuleFor(x => x.TalentValue).LessThan(101).WithMessage("Yetenek Seviyesi En Fazla 100 olabilir..");
            RuleFor(x => x.WriterID).NotEqual(0).WithMessage("Yazar Adı Seçmelisiniz.");
        }
    }
}
