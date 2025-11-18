using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StdpynValidator : AbstractValidator<STDPYN>
    {
        #region ClientService

        #endregion ClientService

        public StdpynValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.DPTIPI).Length(1,4).NotNull();
            RuleFor(p => p.DPADRS).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
