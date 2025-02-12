using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator  :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(x => x.WritePassword).NotEmpty().WithMessage("Şifre  boş geçilemez");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Max 50 karakterlik veri gir");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Min 2 karakterlik veri gir");

        }
    }
}
