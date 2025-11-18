using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StbdrnValidator : AbstractValidator<STBDRN>
    {
        #region ClientService

        #endregion ClientService

        public StbdrnValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRYTNM).Length(1,150).NotNull();
            RuleFor(p => p.RENKKD).MaximumLength(20);
            RuleFor(p => p.BEDNKD).MaximumLength(20);
            RuleFor(p => p.DROPKD).MaximumLength(20);
            RuleFor(p => p.EANTKD).MaximumLength(20);
            RuleFor(p => p.EANKOD).MaximumLength(40);
            RuleFor(p => p.STOZEL).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
