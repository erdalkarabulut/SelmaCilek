using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class SthbasValidator : AbstractValidator<STHBAS>
    {
        #region ClientService

        #endregion ClientService

        public SthbasValidator()
        {
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.EVRSER).MaximumLength(6);
            RuleFor(p => p.EVRAKN).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.GRDEPO).MaximumLength(4);
            RuleFor(p => p.CKDEPO).MaximumLength(4);
            RuleFor(p => p.GNACIK).MaximumLength(200);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
