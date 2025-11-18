using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmhrktValidator : AbstractValidator<WMHRKT>
    {
        #region ClientService

        #endregion ClientService

        public WmhrktValidator()
        {
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.WMHRKD).MaximumLength(20);
            RuleFor(p => p.WMNKTR).MaximumLength(1);
            RuleFor(p => p.KPTIPI).MaximumLength(4);
            RuleFor(p => p.KPADRS).MaximumLength(50);
            RuleFor(p => p.HPTIPI).MaximumLength(4);
            RuleFor(p => p.HPADRS).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
