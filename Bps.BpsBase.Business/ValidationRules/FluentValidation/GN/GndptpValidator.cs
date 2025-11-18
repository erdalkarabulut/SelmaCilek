using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GndptpValidator : AbstractValidator<GNDPTP>
    {
        #region ClientService

        #endregion ClientService

        public GndptpValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.DPTIPI).Length(1,4).NotNull();
            RuleFor(p => p.DPTIPT).MaximumLength(50);
            RuleFor(p => p.DGSTKD).MaximumLength(20);
            RuleFor(p => p.DCSTKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
