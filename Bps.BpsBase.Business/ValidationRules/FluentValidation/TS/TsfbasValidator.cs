using FluentValidation;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.TS
{
    public class TsfbasValidator : AbstractValidator<TSFBAS>
    {
        #region ClientService

        #endregion ClientService

        public TsfbasValidator()
        {
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.TSHRTP).NotNull();
            RuleFor(p => p.TSFTNO).NotNull();
            RuleFor(p => p.EVRSER).MaximumLength(6);
            RuleFor(p => p.EVRAKN).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.MALTES).MaximumLength(25);
            RuleFor(p => p.GRDEPO).MaximumLength(4);
            RuleFor(p => p.CKDEPO).MaximumLength(4);
            RuleFor(p => p.GNACIK).MaximumLength(200);
            RuleFor(p => p.STFYNO).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
