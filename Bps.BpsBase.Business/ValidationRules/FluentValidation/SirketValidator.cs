using FluentValidation;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation
{
    public class SirketValidator : AbstractValidator<SIRKET>
    {
        #region ClientService

        #endregion ClientService

        public SirketValidator()
        {
            RuleFor(p => p.GNNAME).Length(1,50).NotNull();
            RuleFor(p => p.KISAAD).Length(1,10).NotNull();
            RuleFor(p => p.UNVANI).Length(1,500).NotNull();
            RuleFor(p => p.ADRESS).Length(1,500).NotNull();
            RuleFor(p => p.MAHAKD).Length(1,20).NotNull();
            RuleFor(p => p.ILCEKD).Length(1,20).NotNull();
            RuleFor(p => p.SEHRKD).Length(1,20).NotNull();
            RuleFor(p => p.ULKEKD).Length(1,20).NotNull();
            RuleFor(p => p.ISYTEL).MaximumLength(20);
            RuleFor(p => p.CEPTEL).MaximumLength(20);
            RuleFor(p => p.ISYFAX).MaximumLength(20);
            RuleFor(p => p.EPOSTA).MaximumLength(100);
            RuleFor(p => p.WEBSIT).MaximumLength(100);
            RuleFor(p => p.VERGDA).Length(1,50).NotNull();
            RuleFor(p => p.VERGNO).Length(1,15).NotNull();
            RuleFor(p => p.TSICNO).MaximumLength(50);
            RuleFor(p => p.YMMSMM).MaximumLength(50);
            RuleFor(p => p.TICODA).MaximumLength(50);
            RuleFor(p => p.ODASIC).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
