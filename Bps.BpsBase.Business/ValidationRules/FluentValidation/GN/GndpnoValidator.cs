using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GndpnoValidator : AbstractValidator<GNDPNO>
    {
        #region ClientService

        #endregion ClientService

        public GndpnoValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
