using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UA
{
    public class UastbgValidator : AbstractValidator<UASTBG>
    {
        #region ClientService

        #endregion ClientService

        public UastbgValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.KLNKOD).MaximumLength(1);
            RuleFor(p => p.URAKOD).MaximumLength(50);
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
