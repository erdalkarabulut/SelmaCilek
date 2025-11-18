using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StcrkdValidator : AbstractValidator<STCRKD>
    {
        #region ClientService

        #endregion ClientService

        public StcrkdValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.RENKKD).MaximumLength(20);
            RuleFor(p => p.BEDNKD).MaximumLength(20);
            RuleFor(p => p.DROPKD).MaximumLength(20);
            RuleFor(p => p.CRSTKO).MaximumLength(25);
            RuleFor(p => p.CRSTNM).MaximumLength(40);
            RuleFor(p => p.CRVRKO).MaximumLength(25);
            RuleFor(p => p.EANTKD).MaximumLength(20);
            RuleFor(p => p.EANKOD).MaximumLength(40);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
