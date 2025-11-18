using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsyrtnValidator : AbstractValidator<ISYRTN>
    {
        #region ClientService

        #endregion ClientService

        public IsyrtnValidator()
        {
            RuleFor(p => p.ISYKOD).MaximumLength(20);
            RuleFor(p => p.TANIMI).Length(1,50).NotNull();
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.ISBLKD).MaximumLength(20);
            RuleFor(p => p.STADBR).MaximumLength(20);
            RuleFor(p => p.GCTSUB).MaximumLength(20);
            RuleFor(p => p.BEKSUB).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
