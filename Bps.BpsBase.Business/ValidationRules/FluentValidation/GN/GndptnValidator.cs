using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GndptnValidator : AbstractValidator<GNDPTN>
    {
        #region ClientService

        #endregion ClientService

        public GndptnValidator()
        {
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();
            RuleFor(p => p.DPTANM).Length(1,40).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
