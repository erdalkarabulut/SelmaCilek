using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GndpzmValidator : AbstractValidator<GNDPZM>
    {
        #region ClientService

        #endregion ClientService

        public GndpzmValidator()
        {
            RuleFor(p => p.PERSID).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();
            RuleFor(p => p.DPTANM).Length(1,40).NotNull();
            RuleFor(p => p.MOBILE).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
