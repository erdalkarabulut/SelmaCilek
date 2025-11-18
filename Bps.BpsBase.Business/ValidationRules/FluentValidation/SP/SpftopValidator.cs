using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpftopValidator : AbstractValidator<SPFTOP>
    {
        #region ClientService

        #endregion ClientService

        public SpftopValidator()
        {
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.SPHRTP).NotNull();
            RuleFor(p => p.SPFTNO).NotNull();
            RuleFor(p => p.EVRAKN).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.MALTES).MaximumLength(25);
            RuleFor(p => p.SPKONU).MaximumLength(10);
            RuleFor(p => p.SPBASL).MaximumLength(50);
            RuleFor(p => p.DVCNKD).MaximumLength(10);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
