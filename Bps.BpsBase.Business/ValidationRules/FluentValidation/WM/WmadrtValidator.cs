using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmadrtValidator : AbstractValidator<WMADRT>
    {
        #region ClientService

        #endregion ClientService

        public WmadrtValidator()
        {
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.DPTIPI).Length(1,4).NotNull();
            RuleFor(p => p.DPADRS).MaximumLength(50);
            RuleFor(p => p.DPALKD).MaximumLength(20);
            RuleFor(p => p.DPATKD).MaximumLength(20);
            RuleFor(p => p.DPACKD).MaximumLength(20);
            RuleFor(p => p.DPASRL).MaximumLength(6);
            RuleFor(p => p.DPCSRL).MaximumLength(6);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
