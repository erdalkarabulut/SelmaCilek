using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmnksbValidator : AbstractValidator<WMNKSB>
    {
        #region ClientService

        #endregion ClientService

        public WmnksbValidator()
        {
            RuleFor(p => p.DEPOKD).Length(1,20).NotNull();
            RuleFor(p => p.NKBELG).MaximumLength(20);
            RuleFor(p => p.WMHRKD).MaximumLength(20);
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.WMNKTR).MaximumLength(1);
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.GNONAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
