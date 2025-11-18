using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpfbasValidator : AbstractValidator<SPFBAS>
    {
        #region ClientService

        #endregion ClientService

        public SpfbasValidator()
        {
            RuleFor(p => p.SPORKD).MaximumLength(20);
            RuleFor(p => p.SPDGKD).MaximumLength(20);
            RuleFor(p => p.SPHRTP).NotNull();
            RuleFor(p => p.SPFTNO).NotNull();
            RuleFor(p => p.EVRAKN).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRHRKD).MaximumLength(20);
            RuleFor(p => p.CRKODU).MaximumLength(25);
            RuleFor(p => p.MALTES).MaximumLength(25);
            RuleFor(p => p.GRDEPO).MaximumLength(4);
            RuleFor(p => p.CKDEPO).MaximumLength(4);
            RuleFor(p => p.DVCNKD).Length(1,10).NotNull();
            RuleFor(p => p.GNACIK).MaximumLength(200);
            RuleFor(p => p.STFYNO).NotNull();
            RuleFor(p => p.TSEVRK).MaximumLength(50);
            RuleFor(p => p.TRMDKD).MaximumLength(20);
            RuleFor(p => p.TSSRKD).MaximumLength(20);
            RuleFor(p => p.TLBLNO).MaximumLength(20);
            RuleFor(p => p.TKBGNO).MaximumLength(20);
            RuleFor(p => p.TKTRKD).MaximumLength(20);
            RuleFor(p => p.SPUTKD).MaximumLength(20);
            RuleFor(p => p.SPDRKD).MaximumLength(20);
            RuleFor(p => p.TKDRKD).MaximumLength(20);
            RuleFor(p => p.KAYNAK).MaximumLength(100);
            RuleFor(p => p.DNSMKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
