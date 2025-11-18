using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UA
{
    public class UastrtValidator : AbstractValidator<UASTRT>
    {
        #region ClientService

        #endregion ClientService

        public UastrtValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.URAKOD).Length(1,50).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.PARENT).NotNull();
            RuleFor(p => p.CHILDD).NotNull();
            RuleFor(p => p.SEVIYE).NotNull();
            RuleFor(p => p.ISOPKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
