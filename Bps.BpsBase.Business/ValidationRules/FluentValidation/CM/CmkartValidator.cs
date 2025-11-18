using FluentValidation;
using Bps.BpsBase.Entities.Concrete.CM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.CM
{
    public class CmkartValidator : AbstractValidator<CMKART>
    {
        #region ClientService

        #endregion ClientService

        public CmkartValidator()
        {
            RuleFor(p => p.BELGEN).MaximumLength(20);
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.GNACIK).MaximumLength(200);
            RuleFor(p => p.CMDRKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
