using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmadrsValidator : AbstractValidator<WMADRS>
    {
        #region ClientService

        #endregion ClientService

        public WmadrsValidator()
        {
            RuleFor(p => p.WMASNO).MaximumLength(20);
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.DPTIPI).Length(1,4).NotNull();
            RuleFor(p => p.DPADRS).MaximumLength(50);
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.DPBRNO).MaximumLength(20);
            RuleFor(p => p.PARTIN).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
