using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageReciever).NotEmpty().WithMessage("Alıcı Mail Adresi Boş Olamaz.");
            RuleFor(x => x.MessageReciever).EmailAddress().WithMessage("Geçerli Bir E-mail Adersi Yazınız.");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Boş Olamaz.");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu En Az 3 Karakter Olmalı.");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu En Fazla 50 Karakter Olmalı.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Olamaz.");
            RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("Mesaj En Az 3 Karakter Olmalı.");
            RuleFor(x => x.MessageContent).MaximumLength(100).WithMessage("Mesaj En Fazla 100 Karakter Olmalı.");
        }
    }
}